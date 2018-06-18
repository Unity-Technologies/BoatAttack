using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeGenerator : MonoBehaviour {

    //public Vector3 wakeGenPoint;
    public List<Wake> _wakes = new List<Wake>();
    private List<GameObject> _lrs = new List<GameObject>();
    public GameObject _wakePrefab;
    public float _genDistance = 0.5f;
    public float _maxAge = 5f;

    void OnEnable () 
	{
		foreach(Wake w in _wakes)
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
                //go.hideFlags = HideFlags.HideAndDontSave;
            }
        }
    }

	void OnDisable()
	{
        for (int i = _lrs.Count - 1; i >= 0; i--)
		{
            DestroyImmediate(_lrs[i]);
        }
        _lrs.Clear();
    }

	void Update () 
	{
        Vector3 origin;
        //For each wake pair
        for (int w = 0; w < _wakes.Count; w++)
        {
            Wake _wake = _wakes[w];
            int s = 0;
            for (int x = -1; x <= 1; x+=2)
			{
                origin = _wake.origin;
                origin.x *= x;
                origin = transform.TransformPoint(origin);
                origin.y = 0;//flatten origin in world
                //create points, if needed
                if (_wake.lines[s].points.Count == 0)
                {
                    _wake.lines[s].points.Insert(0, CreateWakePoint(origin, x));
                }
                else if (Vector3.Distance(_wake.lines[s].points[0].pos, origin) > _genDistance)
                {
                    _wake.lines[s].points.Insert(0, CreateWakePoint(origin, x));
                }
                //kill points, if needed
                for (int i = _wake.lines[s].points.Count - 1; i >= 0; i--)
				{
					if(_wake.lines[s].points[i].age > _maxAge)
					{
                        _wake.lines[s].points.RemoveAt(i);
                    }
					else
					{
                        _wake.lines[s].points[i].age += Time.deltaTime;
                        _wake.lines[s].points[i].pos += _wake.lines[s].points[i].dir * 3 * Time.deltaTime;
                    }
                }
                Vector3[] points = new Vector3[_wake.lines[s].points.Count + 1];
                points[0] = origin;
                for (var p = 1; p < points.Length - 1; p++)
                    points[p] = _wake.lines[s].points[p - 1].pos;

                _wake.lines[s]._lineRenderer.positionCount = _wake.lines[s].points.Count;
                _wake.lines[s]._lineRenderer.SetPositions(points);
                s++;
            }
        }
    }

	WakePoint CreateWakePoint(Vector3 pos, float sign)
	{
        WakePoint wp = new WakePoint(pos);
        wp.dir = transform.right * sign;
        wp.dir.y = 0;
        return wp;
	}

	void OnDrawGizmos()
	{
        Gizmos.color = Color.green;
        foreach (Wake w in _wakes)
        {
            Gizmos.DrawSphere(transform.TransformPoint(w.origin.x, w.origin.y, w.origin.z), 0.1f);
            Gizmos.DrawSphere(transform.TransformPoint(-w.origin.x, w.origin.y, w.origin.z), 0.1f);
        }

        foreach(Wake w in _wakes)
		{
            //Vector3 o = w.origin;
            
            foreach(WakeLine wl in w.lines)
			{
				int side = 0;
                //Vector3 oPoint = OffsetGenPoint(o, side);
				foreach(WakePoint wp in wl.points)
				{
                    Gizmos.DrawSphere(wp.pos, (_maxAge - wp.age) * 0.05f);
                }
                side++;
            }

        }
    }

	Vector3 OffsetGenPoint(Vector3 point, int side)
	{
        float sideVal = side == 0 ? point.x : -point.x;
        Vector3 v = transform.TransformPoint(sideVal, point.y, point.z);
        return v;
    }

	[System.Serializable]
	public class Wake
	{
        public Vector3 origin;
        public List<WakeLine> lines = new List<WakeLine>();
    }

    [System.Serializable]
	public class WakeLine
	{
        public LineRenderer _lineRenderer;
        public List<WakePoint> points = new List<WakePoint>();
    }

    [System.Serializable]
	public class WakePoint
	{
    	public Vector3 pos;
        public Vector3 dir;
        public float age;

		public WakePoint(Vector3 p)
		{
            pos = p;
            age = 0f;
        }
    }

}
