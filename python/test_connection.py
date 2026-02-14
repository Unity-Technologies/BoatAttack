#!/usr/bin/env python3
"""Test Unity TCP connection"""

import socket
import json
import time
import sys


def test_connection(host='localhost', port=9876, timeout=5):
    print(f"Testing connection to Unity at {host}:{port}...")

    # 1. TCP connection test
    print("\n[1] TCP Connection Test")
    sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    sock.settimeout(timeout)
    try:
        sock.connect((host, port))
        print("  -> Connected successfully!")
    except ConnectionRefusedError:
        print("  -> FAILED: Connection refused.")
        print("     Make sure Unity is running with SocketServer or MultiAgentServer.")
        return False
    except socket.timeout:
        print(f"  -> FAILED: Timeout after {timeout}s.")
        return False
    except Exception as e:
        print(f"  -> FAILED: {e}")
        return False

    # 2. Receive data test
    print("\n[2] Receive Data Test")
    try:
        sock.settimeout(5)
        data = sock.recv(4096).decode('utf-8')
        if data:
            print(f"  -> Received {len(data)} bytes")
            lines = data.strip().split('\n')
            for line in lines[:3]:
                try:
                    parsed = json.loads(line)
                    print(f"  -> Valid JSON: {list(parsed.keys())}")
                    if 'ships' in parsed:
                        print(f"     Ships: {len(parsed['ships'])}")
                        for ship in parsed['ships'][:5]:
                            print(f"       - {ship.get('id', '?')} ({ship.get('tag', '?')})")
                except json.JSONDecodeError:
                    print(f"  -> Raw data: {line[:100]}...")
        else:
            print("  -> No data received (empty)")
    except socket.timeout:
        print("  -> No data within 5s (server may need FixedUpdate)")
    except Exception as e:
        print(f"  -> Error: {e}")

    # 3. Send action test
    print("\n[3] Send Action Test")
    try:
        action = {'throttle': 0.5, 'steering': 0.0, 'fire': False}
        msg = json.dumps(action) + '\n'
        sock.sendall(msg.encode('utf-8'))
        print(f"  -> Sent: {msg.strip()}")
    except Exception as e:
        print(f"  -> Send error: {e}")

    # 4. Continuous receive test
    print("\n[4] Continuous Receive Test (3 seconds)...")
    msg_count = 0
    start = time.time()
    sock.settimeout(1)
    while time.time() - start < 3:
        try:
            data = sock.recv(4096).decode('utf-8')
            if data:
                msg_count += data.count('\n')
        except socket.timeout:
            pass
        except Exception:
            break

    elapsed = time.time() - start
    print(f"  -> Received {msg_count} messages in {elapsed:.1f}s")
    if msg_count > 0:
        print(f"  -> Rate: {msg_count / elapsed:.1f} msg/s")

    sock.close()
    print("\n[Result] Connection test PASSED!")
    return True


if __name__ == '__main__':
    host = sys.argv[1] if len(sys.argv) > 1 else 'localhost'
    port = int(sys.argv[2]) if len(sys.argv) > 2 else 9876
    test_connection(host, port)
