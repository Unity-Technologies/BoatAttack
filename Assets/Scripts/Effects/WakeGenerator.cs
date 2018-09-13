using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace BoatAttack.Boat
{
    /// <summary>
    /// Used to generate two wakes (linerenderers) for the boats
    /// </summary>
    public class WakeGenerator : MonoBehaviour
    {
        public List<Wake> _wakes = new List<Wake>(); // Wakes to create
        private List<GameObject> _lrs = new List<GameObject>(); // line renderers
        public GameObject _wakePrefab; // the wake prefab, preset linerenderer
        public float _genDistance = 0.5f; // distance to make new segments
        public float _maxAge = 5f; // how long the wake lasts for

        void OnEnable()
        {
            // Initial setup for wakes
            foreach (Wake w in _wakes)
            {
                for (int i = 0; i < 2; i++)
                {
                    WakeLine wl = new WakeLine();
                    GameObject go = GameObject.Instantiate(_wakePrefab, Vector3.zero, Quaternion.Euler(90f, 0, 0));
                    _lrs.Add(go);
                    LineRenderer LR = go.GetComponent<LineRenderer>();
                    wl.points = new List<WakePoint>();
                    wl._lineRenderer = LR;
                    w.lines.Add(wl);
                    go.hideFlags = HideFlags.HideAndDontSave;
                }
            }
        }

        void OnDisable()
        {
            for (int i = _lrs.Count - 1; i >= 0; i--)
            {
                DestroyImmediate(_lrs[i]); // kill wake objects
            }
            _lrs.Clear();
        }

        void Update()
        {
            Vector3 origin;
            //For each wake pair
            var wCount = _wakes.Count;
            for (int w = 0; w < wCount; w++)
            {
                Wake _wake = _wakes[w];
                int s = 0;
                for (int x = -1; x <= 1; x += 2)
                {
                    origin = _wake.origin;
                    origin.x *= x;
                    origin = transform.TransformPoint(origin);
                    origin.y = 0;//flatten origin in world
                    var pointCount = _wake.lines[s].points.Count;
                    //////////////////////////// create points, if needed ///////////////////////////////
                    if (pointCount == 0)
                    {
                        _wake.lines[s].points.Insert(0, CreateWakePoint(origin, x));
                        pointCount++;
                    }
                    else if (Vector3.Distance(_wake.lines[s].points[0].pos, origin) > _genDistance)
                    {
                        _wake.lines[s].points.Insert(0, CreateWakePoint(origin, x));
                        pointCount++;
                    }
                    ///////////////////////////// kill points, if needed ////////////////////////////////
                    for (int i = _wake.lines[s].points.Count - 1; i >= 0; i--)
                    {
                        if (_wake.lines[s].points[i].age > _maxAge)
                        {
                            _wake.lines[s].points.RemoveAt(i);
                            pointCount--;
                        }
                        else
                        {
                            _wake.lines[s].points[i].age += Time.deltaTime; // increment age
                            _wake.lines[s].points[i].pos += _wake.lines[s].points[i].dir * 3 * Time.deltaTime; // move points by dir
                        }
                    }
                    ///////////////////// Create the line renderer points ///////////////////////////////
                    
                    _wake.lines[s]._lineRenderer.positionCount = pointCount + 1;
                    _wake.lines[s]._lineRenderer.SetPosition(0, origin);
                    for (var i = 0; i < pointCount; i++)
                    {
                        _wake.lines[s]._lineRenderer.SetPosition(i + 1, _wake.lines[s].points[i].pos);
                    }
                    s++;
                }
            }
        }

        /// <summary>
        /// Creates a WakePoint and sets the direction
        /// </summary>
        /// <param name="pos">Where to make the wake point in world coords</param>
        /// <param name="sign">Side of the wake this is on</param>
        /// <returns></returns>
        WakePoint CreateWakePoint(Vector3 pos, float sign)
        {
            WakePoint wp = new WakePoint(pos);
            wp.dir = transform.right * sign; // the point gets the direction of the side of the boat, thhis is then used to move the wake as it ages
            wp.dir.y = 0;
            return wp;
        }

        // Draw helper Gizmos
        void OnDrawGizmosSelected()
        {
            var c = Color.blue;
            c.a = 0.5f;
            Gizmos.color = c;
            foreach (Wake w in _wakes)
            {
                Gizmos.DrawSphere(transform.TransformPoint(w.origin.x, w.origin.y, w.origin.z), 0.1f);
                Gizmos.DrawSphere(transform.TransformPoint(-w.origin.x, w.origin.y, w.origin.z), 0.1f);
            }
            foreach (Wake w in _wakes)
            {
                
                foreach (WakeLine wl in w.lines)
                {
                    int side = 0;
                    var pre = Vector3.zero;
                    foreach (WakePoint wp in wl.points)
                    {
                        Gizmos.DrawSphere(wp.pos, (_maxAge - wp.age) * 0.01f);
                        if(pre != Vector3.zero)
                            Gizmos.DrawLine(wp.pos, pre);
                        pre = wp.pos;
                    }
                    side++;
                }
            }
        }

        /// <summary>
        /// Wake is a pair of line renderers stored in WakeLines
        /// </summary>
        [System.Serializable]
        public class Wake
        {
            public Vector3 origin; // Wehre the wake originates from in local coords
            public List<WakeLine> lines = new List<WakeLine>(); // Wake Lines
        }

        /// <summary>
        /// WakeLine is a single side of a wake, it contains a line renderer and list of wakepoints
        /// </summary>
        [System.Serializable]
        public class WakeLine
        {
            public LineRenderer _lineRenderer; // the linerenderer
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
