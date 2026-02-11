"""
Unity 실행 중인 객체들의 위치를 실시간으로 plot하는 스크립트
"""

import numpy as np
import matplotlib.pyplot as plt
import matplotlib.animation as animation
import matplotlib.font_manager as fm
from mlagents_envs.environment import UnityEnvironment
from mlagents_envs.side_channel.side_channel import SideChannel, IncomingMessage
import uuid
import threading
import time
import warnings

class PositionSideChannel(SideChannel):
    """Unity에서 위치 정보를 받는 커스텀 Side Channel"""
    
    def __init__(self):
        super().__init__(uuid.UUID("621f0a70-4f87-11d2-a976-00c04f8e1488"))
        self.position_data = {}
        self.lock = threading.Lock()
    
    def on_message_received(self, msg: IncomingMessage) -> None:
        """Unity에서 메시지를 받을 때 호출됨 - 이 함수가 호출되는지 확인!"""
        print(f"🔔 [PositionSideChannel] on_message_received 호출됨!")  # 무조건 출력
        try:
            with self.lock:
                # 메시지 형식: [객체 개수] [객체1 이름] [x] [y] [z] [객체2 이름] [x] [y] [z] ...
                count = msg.read_int32()
                print(f"🔔 [PositionSideChannel] 메시지에서 읽은 객체 수: {count}")
                
                self.position_data = {}
                for i in range(count):
                    obj_name = msg.read_string()
                    x = msg.read_float32()
                    y = msg.read_float32()
                    z = msg.read_float32()
                    self.position_data[obj_name] = (x, y, z)
                    print(f"🔔 [PositionSideChannel] 객체 {i+1}: {obj_name} = ({x:.2f}, {y:.2f}, {z:.2f})")
                
                # 디버깅: 첫 메시지 수신 시 로그 출력
                if count > 0 and not hasattr(self, '_first_message_logged'):
                    print(f"[PositionSideChannel] ✅ 첫 메시지 수신! 객체 수: {count}")
                    for name, pos in self.position_data.items():
                        print(f"  - {name}: ({pos[0]:.2f}, {pos[1]:.2f}, {pos[2]:.2f})")
                    self._first_message_logged = True
                elif count > 0:
                    # 주기적으로 메시지 수신 확인
                    if not hasattr(self, '_message_count'):
                        self._message_count = 0
                    self._message_count += 1
                    if self._message_count % 60 == 0:  # 약 3초마다
                        print(f"[PositionSideChannel] 메시지 수신 중... (총 {self._message_count}개, 현재 객체 수: {count})")
        except Exception as e:
            print(f"❌ PositionSideChannel 메시지 수신 오류: {e}")
            print(f"   메시지 타입: {type(msg)}")
            print(f"   메시지 속성: {dir(msg)}")
            import traceback
            traceback.print_exc()
    
    def get_positions(self):
        """현재 위치 데이터를 안전하게 반환"""
        with self.lock:
            return dict(self.position_data)


class UnityPositionPlotter:
    """Unity 객체 위치를 실시간으로 plot하는 클래스"""
    
    def __init__(self, port=5004, update_interval=50):
        """
        Args:
            port: Unity ML-Agents 연결 포트
            update_interval: 그래프 업데이트 간격 (밀리초)
        """
        self.port = port
        self.update_interval = update_interval
        self.env = None
        
        # Side Channel 생성 (UnityEnvironment 생성 전에 반드시 생성해야 함)
        self.position_channel = PositionSideChannel()
        print(f"[초기화] PositionSideChannel 생성 완료. UUID: {self.position_channel.channel_id}")
        
        self.behavior_name = None
        
        # Plot 관련 변수
        self.fig = None
        self.ax = None
        self.positions_history = {}  # {객체명: [(x, z), ...]}
        self.max_history = 100  # 최대 저장할 위치 개수
        
        # 성능 최적화: Line2D 객체들을 미리 생성
        self.trajectory_lines = {}  # {객체명: Line2D} - 궤적 선
        self.marker_points = {}     # {객체명: Line2D} - 현재 위치 마커
        self.legend_handles = []    # 범례 핸들
        self.colors = None          # 색상 배열
        
        # Unity 환경 스텝을 별도 스레드에서 실행
        self.env_thread = None
        self.running = False
        self.env_lock = threading.Lock()
        
    def connect_unity(self, timeout=60, max_retries=3):
        """Unity 환경에 연결 (재시도 로직 포함)"""
        print(f"Unity 환경에 연결 중... (포트: {self.port})")
        print("주의: Unity 에디터에서 Play 버튼을 누른 후 Python 스크립트를 실행하세요!")
        print("또는 Python 스크립트를 먼저 실행한 후 Unity에서 Play 버튼을 누르세요.")
        
        for attempt in range(max_retries):
            try:
                print(f"\n연결 시도 {attempt + 1}/{max_retries}...")
                
                # UnityEnvironment 생성 (타임아웃 설정)
                # 중요: side_channels는 UnityEnvironment 생성 시 반드시 전달해야 함
                # 생성 후에 등록하면 인식되지 않음!
                print(f"[연결] UnityEnvironment 생성 중... Side Channel UUID: {self.position_channel.channel_id}")
                self.env = UnityEnvironment(
                    file_name=None,
                    base_port=self.port,
                    side_channels=[self.position_channel],  # 생성 시점에 전달 필수!
                    timeout_wait=timeout
                )
                
                print("✅ UnityEnvironment 생성 완료.")
                print(f"   → Side Channel이 UnityEnvironment에 등록되었습니다.")
                print("  → Unity 연결 대기 중...")
                print("\n  ⚠️  중요: Unity 설정 확인!")
                print("     Unity 씬에 다음이 있는지 확인하세요:")
                print("     1. ML-Agents Academy GameObject")
                print("     2. Agent GameObject (Behavior Parameters 포함)")
                print("     3. Unity에서 Play 버튼 클릭")
                print("     4. Unity Console에 에러가 없는지 확인")
                print(f"\n  → Unity 초기화 응답 대기 중... (최대 {timeout}초)")
                print("     Unity가 응답하지 않으면 타임아웃 후 재시도합니다...")
                
                # reset() 호출로 초기화 (이 부분에서 Unity 응답을 기다림)
                # 타임아웃은 UnityEnvironment 생성 시 설정한 timeout_wait를 사용
                try:
                    print("  → env.reset() 시도 중... Unity 에디터가 Play 상태여야 합니다.")
                    self.env.reset()
                    print("  ✅ Unity 초기화 완료!")
                    print(f"  → PositionSideChannel UUID: {self.position_channel.channel_id}")
                    
                    # 중요: reset() 직후 강제로 한 스텝 진행해서 데이터 흐름 물꼬 트기
                    # 이렇게 하면 Unity의 Side Channel 메시지가 Python으로 전달됨
                    print("  → 데이터 흐름 시작을 위해 env.step() 호출 중...")
                    self.env.step()
                    print("  ✅ 초기 스텝 완료!")
                except Exception as reset_error:
                    error_str = str(reset_error)
                    print(f"\n  ❌ Unity 초기화 실패: {error_str}")
                    
                    # 더 자세한 에러 메시지 제공
                    if "timeout" in error_str.lower() or "took too long" in error_str.lower():
                        print("\n  🔍 타임아웃 원인 분석:")
                        print("     Unity가 Python에 연결하지 못했습니다.")
                        print("\n  📋 확인 체크리스트:")
                        print("     □ Unity에서 Play 버튼을 눌렀나요?")
                        print("     □ Unity 씬에 ML-Agents Academy가 있나요?")
                        print("     □ Unity 씬에 Agent가 있나요?")
                        print("     □ Agent에 Behavior Parameters 컴포넌트가 있나요?")
                        print("     □ Unity Console에 에러 메시지가 있나요?")
                        print("     □ 포트 5004가 다른 프로그램에 의해 사용 중인가요?")
                        raise Exception(
                            f"Unity 응답 타임아웃 ({timeout}초 초과).\n"
                            "Unity가 Python에 연결하지 못했습니다.\n"
                            "자세한 내용은 UNITY_SETUP_CHECK.md 파일을 참고하세요."
                        )
                    else:
                        raise Exception(f"Unity 초기화 실패: {reset_error}")
                
                # Behavior 이름 가져오기
                if len(self.env.behavior_specs) == 0:
                    raise Exception("Behavior가 없습니다. Unity 씬에 Agent가 있는지 확인하세요.")
                
                self.behavior_name = list(self.env.behavior_specs)[0]
                print(f"✅ 연결 성공! Behavior: {self.behavior_name}")
                print("  → 그래프 창을 여는 중...")
                return True
                
            except Exception as e:
                error_msg = str(e)
                print(f"❌ 연결 실패 (시도 {attempt + 1}/{max_retries}): {error_msg}")
                
                if attempt < max_retries - 1:
                    wait_time = 2 * (attempt + 1)  # 2초, 4초, 6초...
                    print(f"{wait_time}초 후 재시도...")
                    time.sleep(wait_time)
                else:
                    print("\n" + "="*60)
                    print("❌ 연결 실패 원인 진단:")
                    print("="*60)
                    print("\n[필수 확인 사항]")
                    print("1. Unity 에디터가 실행 중인가요?")
                    print("2. Unity에서 Play 버튼을 눌렀나요? (Play 모드가 활성화되어야 함)")
                    print("3. Unity 씬에 ML-Agents Academy가 있나요?")
                    print("   → Hierarchy에서 'Academy' 또는 'ML-Agents' GameObject 확인")
                    print("4. Unity 씬에 Agent가 있나요?")
                    print("   → Hierarchy에서 Agent GameObject 확인")
                    print("5. Agent에 Behavior Parameters 컴포넌트가 있나요?")
                    print("   → Agent 선택 → Inspector에서 'Behavior Parameters' 확인")
                    print("\n[추가 확인 사항]")
                    print(f"6. 포트 {self.port}가 다른 프로그램에 의해 사용 중인가요?")
                    print("   → PowerShell에서 확인: netstat -ano | findstr :5004")
                    print("7. Unity Console에 에러 메시지가 있나요?")
                    print("   → Unity Console 창 확인 (Window → General → Console)")
                    print("\n[Unity Console에서 확인할 메시지]")
                    print("  ✅ '[UnityPositionSender] PositionSideChannel 초기화 완료'")
                    print("  ✅ ML-Agents 관련 에러 메시지")
                    print("="*60)
                    
                    # 이전 연결 시도 정리
                    if self.env is not None:
                        try:
                            self.env.close()
                        except:
                            pass
                        self.env = None
                    
                    return False
        
        return False
    
    def setup_plot(self):
        """matplotlib 그래프 설정"""
        self.fig, self.ax = plt.subplots(figsize=(10, 10))
        self.ax.set_xlabel('X 위치', fontsize=12)
        self.ax.set_ylabel('Z 위치', fontsize=12)
        self.ax.set_title('Unity 객체 위치 실시간 추적', fontsize=14)
        self.ax.grid(True, alpha=0.3)
        self.ax.set_aspect('equal', adjustable='box')
        
        # 한글 폰트 설정 (Windows)
        # tkinter 폰트 경고 억제
        warnings.filterwarnings('ignore', category=UserWarning, module='tkinter')
        
        # 한글 폰트 찾기 및 설정
        korean_fonts = ['Malgun Gothic', 'NanumGothic', 'Nanum Gothic', 'Gulim', 'Batang']
        font_found = False
        
        for font_name in korean_fonts:
            try:
                # 폰트가 시스템에 있는지 확인
                font_list = [f.name for f in fm.fontManager.ttflist]
                if font_name in font_list:
                    plt.rcParams['font.family'] = font_name
                    font_found = True
                    break
            except:
                continue
        
        if not font_found:
            # 기본 폰트로 폴백
            plt.rcParams['font.family'] = 'DejaVu Sans'
        
        plt.rcParams['axes.unicode_minus'] = False
        
        # 초기 빈 데이터로 Line2D 객체들 생성 (성능 최적화)
        # 실제 데이터가 들어오면 set_data()로 업데이트만 하면 됨
        self.trajectory_lines = {}
        self.marker_points = {}
        self.legend_handles = []
    
    def _unity_step_loop(self):
        """Unity 환경 스텝을 별도 스레드에서 실행 (GUI 블로킹 방지)"""
        step_count = 0
        last_position_count = 0
        
        while self.running:
            try:
                with self.env_lock:
                    if self.env is not None and self.behavior_name is not None:
                        # Unity 환경 스텝 진행
                        # 주의: Behavior Type이 "Heuristic Only"면 행동을 보내지 않아도 됩니다.
                        self.env.step()
                        step_count += 1
                        
                        # Side Channel 메시지 처리 확인
                        current_positions = self.position_channel.get_positions()
                        current_count = len(current_positions)
                        
                        # 디버깅: 주기적으로 스텝 수 및 위치 데이터 출력
                        if step_count % 60 == 0:  # 약 3초마다
                            print(f"[디버그] Unity 스텝 진행 중... (총 {step_count} 스텝)")
                            print(f"[디버그] 현재 위치 데이터 개수: {current_count}")
                            if current_count > 0:
                                print(f"[디버그] 위치 데이터 샘플: {list(current_positions.items())[:2]}")
                            elif last_position_count > 0:
                                print(f"⚠️ [경고] 이전에는 {last_position_count}개였는데 지금은 0개입니다!")
                        
                        last_position_count = current_count
                            
                time.sleep(0.02)  # 약 50 FPS (Unity와 동기화)
            except Exception as e:
                if self.running:  # 종료 중이 아닐 때만 에러 출력
                    print(f"Unity 스텝 오류: {e}")
                    import traceback
                    traceback.print_exc()
                break
    
    def update_plot(self, frame):
        """그래프 업데이트 함수 (animation callback) - 성능 최적화 버전"""
        if self.env is None:
            return
        
        try:
            # Side Channel에서 위치 데이터 읽기 (스레드 안전)
            positions = self.position_channel.get_positions()
            
            # 디버깅: 위치 데이터 확인
            if frame % 60 == 0:  # 약 3초마다 출력
                print(f"[디버그] 받은 위치 데이터 개수: {len(positions)}")
                if len(positions) > 0:
                    print(f"[디버그] 위치 데이터 샘플: {list(positions.items())[:3]}")
            
            # 위치 히스토리 업데이트
            for obj_name, (x, y, z) in positions.items():
                if obj_name not in self.positions_history:
                    self.positions_history[obj_name] = []
                
                # XZ 평면에 투영 (Unity는 Y가 위쪽)
                self.positions_history[obj_name].append((x, z))
                
                # 최대 개수 제한
                if len(self.positions_history[obj_name]) > self.max_history:
                    self.positions_history[obj_name].pop(0)
            
            # 색상 배열 업데이트 (새 객체가 추가되었을 때)
            if len(self.positions_history) > 0:
                if self.colors is None or len(self.colors) < len(self.positions_history):
                    self.colors = plt.cm.tab10(np.linspace(0, 1, len(self.positions_history)))
            
            # set_data() 방식으로 업데이트 (성능 최적화)
            # 기존 Line2D 객체의 데이터만 업데이트하므로 ax.clear()보다 훨씬 빠름
            active_objects = []
            
            for idx, (obj_name, history) in enumerate(self.positions_history.items()):
                if len(history) == 0:
                    continue
                
                active_objects.append(obj_name)
                xs, zs = zip(*history)
                color = self.colors[idx] if self.colors is not None else 'blue'
                
                # 궤적 선 업데이트 또는 생성
                if obj_name not in self.trajectory_lines:
                    line, = self.ax.plot([], [], '-', color=color, alpha=0.5, linewidth=1)
                    self.trajectory_lines[obj_name] = line
                
                self.trajectory_lines[obj_name].set_data(xs, zs)
                
                # 현재 위치 마커 업데이트 또는 생성
                if obj_name not in self.marker_points:
                    marker, = self.ax.plot([], [], 'o', color=color, markersize=8, label=obj_name)
                    self.marker_points[obj_name] = marker
                
                self.marker_points[obj_name].set_data([xs[-1]], [zs[-1]])
                self.marker_points[obj_name].set_color(color)
            
            # 사용하지 않는 객체의 Line2D 제거
            for obj_name in list(self.trajectory_lines.keys()):
                if obj_name not in active_objects:
                    self.trajectory_lines[obj_name].remove()
                    del self.trajectory_lines[obj_name]
                    if obj_name in self.marker_points:
                        self.marker_points[obj_name].remove()
                        del self.marker_points[obj_name]
            
            # 축 범위 자동 조정
            if active_objects:
                all_xs = []
                all_zs = []
                for obj_name in active_objects:
                    if obj_name in self.positions_history and len(self.positions_history[obj_name]) > 0:
                        xs, zs = zip(*self.positions_history[obj_name])
                        all_xs.extend(xs)
                        all_zs.extend(zs)
                
                if all_xs and all_zs:
                    margin = 0.1  # 10% 여백
                    x_range = max(all_xs) - min(all_xs) if len(set(all_xs)) > 1 else 1.0
                    z_range = max(all_zs) - min(all_zs) if len(set(all_zs)) > 1 else 1.0
                    
                    self.ax.set_xlim(min(all_xs) - x_range * margin, max(all_xs) + x_range * margin)
                    self.ax.set_ylim(min(all_zs) - z_range * margin, max(all_zs) + z_range * margin)
            
            # 타이틀 업데이트
            title = f'Unity 객체 위치 실시간 추적 (객체 수: {len(active_objects)})'
            self.ax.set_title(title, fontsize=14)
            
            # 범례 업데이트
            if active_objects:
                handles = [self.marker_points[obj_name] for obj_name in active_objects if obj_name in self.marker_points]
                if handles:
                    self.ax.legend(handles, active_objects, loc='upper right', fontsize=8)
            else:
                # 데이터가 없을 때 메시지 표시
                if not hasattr(self, '_waiting_text') or self._waiting_text is None:
                    self._waiting_text = self.ax.text(0.5, 0.5, 
                        '위치 데이터를 기다리는 중...\nUnity에서 객체를 추적하고 있는지 확인하세요.', 
                        ha='center', va='center', transform=self.ax.transAxes, fontsize=12)
                elif active_objects:
                    self._waiting_text.remove()
                    self._waiting_text = None
            
        except Exception as e:
            print(f"업데이트 오류: {e}")
            import traceback
            traceback.print_exc()
    
    def start_plotting(self):
        """실시간 plotting 시작"""
        if self.env is None:
            print("Unity에 연결되지 않았습니다!")
            return
        
        print("\n그래프 설정 중...")
        self.setup_plot()
        print("  → 그래프 창 준비 완료")
        
        # Unity 환경 스텝을 별도 스레드에서 실행 (GUI 블로킹 방지)
        self.running = True
        self.env_thread = threading.Thread(target=self._unity_step_loop, daemon=True)
        self.env_thread.start()
        print("  → Unity 환경 스텝 스레드 시작됨 (GUI 블로킹 방지)")
        
        print("\n" + "="*60)
        print("✅ 실시간 plotting 시작!")
        print("="*60)
        print("그래프 창이 곧 열립니다...")
        print("종료하려면 그래프 창을 닫으세요.")
        print("="*60 + "\n")
        
        # Animation 시작
        ani = animation.FuncAnimation(
            self.fig,
            self.update_plot,
            interval=self.update_interval,
            blit=False,  # set_data() 사용 시 blit=False 권장
            cache_frame_data=False
        )
        
        # matplotlib 창 표시 (블로킹)
        plt.show()
        
        # 창이 닫히면 스레드 종료
        print("\n그래프 창이 닫혔습니다. 종료 중...")
        self.running = False
    
    def cleanup(self):
        """리소스 정리"""
        # Unity 스텝 스레드 종료
        self.running = False
        if self.env_thread is not None:
            self.env_thread.join(timeout=2.0)  # 최대 2초 대기
        
        # Unity 환경 종료
        if self.env is not None:
            with self.env_lock:
                self.env.close()
            print("Unity 연결 해제됨")


def main():
    """메인 함수"""
    import argparse
    
    parser = argparse.ArgumentParser(description='Unity 객체 위치 실시간 plot')
    parser.add_argument('--port', type=int, default=5004, help='Unity ML-Agents 포트 (기본: 5004)')
    parser.add_argument('--interval', type=int, default=50, help='업데이트 간격(ms) (기본: 50)')
    parser.add_argument('--timeout', type=int, default=60, help='연결 타임아웃(초) (기본: 60)')
    parser.add_argument('--retries', type=int, default=3, help='최대 재시도 횟수 (기본: 3)')
    args = parser.parse_args()
    
    print("="*60)
    print("Unity 객체 위치 실시간 Plotter")
    print("="*60)
    print("\n사용 방법:")
    print("방법 1: Python 스크립트를 먼저 실행한 후 Unity에서 Play 버튼 클릭")
    print("방법 2: Unity에서 Play 버튼을 먼저 누른 후 Python 스크립트 실행")
    print("\n연결을 기다리는 중...")
    print("="*60 + "\n")
    
    plotter = UnityPositionPlotter(port=args.port, update_interval=args.interval)
    
    if not plotter.connect_unity(timeout=args.timeout, max_retries=args.retries):
        print("\n❌ Unity 연결에 실패했습니다.")
        print("\n문제 해결 체크리스트:")
        print("  □ Unity 에디터가 실행 중인가요?")
        print("  □ Unity에서 Play 버튼을 눌렀나요?")
        print("  □ Unity 씬에 ML-Agents Academy가 있나요?")
        print("  □ Unity 씬에 Agent가 있나요?")
        print("  □ Agent의 Behavior Parameters가 올바르게 설정되어 있나요?")
        print("  □ 포트 5004가 다른 프로그램에 의해 사용 중이 아닌가요?")
        print("\nUnity Console의 에러 메시지를 확인하세요.")
        return
    
    try:
        plotter.start_plotting()
    except KeyboardInterrupt:
        print("\n사용자에 의해 중단되었습니다.")
    except Exception as e:
        print(f"\n오류 발생: {e}")
        import traceback
        traceback.print_exc()
    finally:
        plotter.cleanup()


if __name__ == "__main__":
    main()
