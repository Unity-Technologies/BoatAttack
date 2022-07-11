using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace BoatAttack
{
    /// <summary>
    /// Used to generate two wakes (linerenderers) for the boats
    /// </summary>
    public class WakeGenerator : MonoBehaviour
    {
        public List<Wake> wakes = new List<Wake>(); // Wakes to create
        private readonly List<GameObject> _lrs = new List<GameObject>(); // line renderers
        public AssetReference wakePrefab; // the wake prefab, preset linerenderer
        public float genDistance = 0.5f; // distance to make new segments
        public float maxAge = 5f; // how long the wake lasts for

        void OnEnable()
        {
            // Initial setup for wakes
            foreach (var wake in wakes)
            {
                StartCoroutine(GenerateWake(wake));
            }
        }

        private IEnumerator GenerateWake(Wake wake)
        {
            for (var i = 0; i < 2; i++)
            {
                var wl = new WakeLine {points = new List<WakePoint>()};
                var wakeLoading = wakePrefab.InstantiateAsync(Vector3.zero, Quaternion.Euler(90f, 0, 0));

                yield return wakeLoading;

                _lrs.Add(wakeLoading.Result);
                wakeLoading.Result.TryGetComponent(out wl.lineRenderer);
                wakeLoading.Result.hideFlags = HideFlags.HideAndDontSave;

                wake.lines.Add(wl);
            }
        }

        private void OnDisable()
        {
            for (var i = _lrs.Count - 1; i >= 0; i--)
            {
                DestroyImmediate(_lrs[i]); // kill wake objects
            }
            _lrs.Clear();
        }

        private void Update()
        {
            //For each wake pair
            foreach (var wake in wakes.Where(wake => wake != null && wake.lines.Count == 2))
            {
                DoWake(-1, wake, wake.lines[0]);
                DoWake(1, wake, wake.lines[1]);
            }
        }

        private void DoWake(int side, Wake wake, WakeLine wakeLine)
        {
            var origin = wake.origin;
            origin.x *= side;
            origin = transform.TransformPoint(origin);
            origin.y = 0;//flatten origin in world
            var pointCount = wakeLine.points.Count;
            //////////////////////////// create points, if needed ///////////////////////////////
            if (pointCount == 0)
            {
                wakeLine.points.Insert(0, CreateWakePoint(origin, side));
                pointCount++;
            }
            else if (Vector3.Distance(wakeLine.points[0].pos, origin) > genDistance)
            {
                wakeLine.points.Insert(0, CreateWakePoint(origin, side));
                pointCount++;
            }
            ///////////////////////////// kill points, if needed ////////////////////////////////
            for (int i = wakeLine.points.Count - 1; i >= 0; i--)
            {
                if (wakeLine.points[i].age > maxAge)
                {
                    wakeLine.points.RemoveAt(i);
                    pointCount--;
                }
                else
                {
                    wakeLine.points[i].age += Time.deltaTime; // increment age
                    wakeLine.points[i].pos += Time.deltaTime * 3 * wakeLine.points[i].dir; // move points by dir
                }
            }
            ///////////////////// Create the line renderer points ///////////////////////////////
            
            wakeLine.lineRenderer.positionCount = pointCount + 1;
            wakeLine.lineRenderer.SetPosition(0, origin);
            for (var i = 0; i < pointCount; i++)
            {
                wakeLine.lineRenderer.SetPosition(i + 1, wakeLine.points[i].pos);
            }
        }

        /// <summary>
        /// Creates a WakePoint and sets the direction
        /// </summary>
        /// <param name="pos">Where to make the wake point in world coords</param>
        /// <param name="sign">Side of the wake this is on</param>
        /// <returns></returns>
        private WakePoint CreateWakePoint(Vector3 pos, float sign)
        {
            // the point gets the direction of the side of the boat, this is then used to move the wake as it ages
            WakePoint wp = new WakePoint(pos) {dir = transform.right * sign};
            wp.dir.y = 0;
            return wp;
        }

        // Draw helper Gizmos
        private void OnDrawGizmosSelected()
        {
            var c = Color.blue;
            c.a = 0.5f;
            Gizmos.color = c;
            foreach (var w in wakes)
            {
                Gizmos.DrawSphere(transform.TransformPoint(w.origin.x, w.origin.y, w.origin.z), 0.1f);
                Gizmos.DrawSphere(transform.TransformPoint(-w.origin.x, w.origin.y, w.origin.z), 0.1f);
            }
            foreach (var w in wakes)
            {
                foreach (var wl in w.lines)
                {
                    var pre = Vector3.zero;
                    foreach (var wp in wl.points)
                    {
                        Gizmos.DrawSphere(wp.pos, (maxAge - wp.age) * 0.01f);
                        if(pre != Vector3.zero)
                            Gizmos.DrawLine(wp.pos, pre);
                        pre = wp.pos;
                    }
                }
            }
        }

        /// <summary>
        /// Wake is a pair of line renderers stored in WakeLines
        /// </summary>
        [System.Serializable]
        public class Wake
        {
            public Vector3 origin; // Where the wake originates from in local coords
            public List<WakeLine> lines = new List<WakeLine>(); // Wake Lines
        }

        /// <summary>
        /// WakeLine is a single side of a wake, it contains a line renderer and list of wakepoints
        /// </summary>
        [System.Serializable]
        public class WakeLine
        {
            public LineRenderer lineRenderer; // the line renderer
            public List<WakePoint> points = new List<WakePoint>(); // list of points
        }

        /// <summary>
        /// A single wake point
        /// </summary>
        [System.Serializable]
        public class WakePoint
        {
            public Vector3 pos; // The current position
            public Vector3 dir; // the directions of movement
            public float age; // the age of the point

            public WakePoint(Vector3 p)
            {
                pos = p;
                age = 0f;
            }
        }
    }
}
