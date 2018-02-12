using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeGenerator : MonoBehaviour {

    //public Vector3 wakeGenPoint;
    public List<Wake> _wakes = new List<Wake>();
    private List<GameObject> _lrs = new List<GameObject>();
    public GameObject _wakePrefab;
    public Transform _wakeContainer;
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
                go.hideFlags = HideFlags.HideAndDontSave;
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
        //For each wake pair
        for (int w = 0; w < _wakes.Count; w++)
        {
            Wake _wake = _wakes[w];
            int s = 0;
            for (int x = -1; x <= 1; x+=2)
			{
                Vector3 origin = _wake.origin;
                origin.x *= x;
                origin = transform.TransformPoint(origin);
                origin.y = 0;//flatten origin in world
                List<WakePoint> wps = _wake.lines[s].points;
                List<Vector3> points = new List<Vector3>();
                points.Add(origin);
                //create points, if needed
                if (wps.Count == 0)
                {
                    wps.Insert(0, CreateWakePoint(origin));
                }
                else if (Vector3.Distance(wps[0].pos, origin) > _genDistance)
                {
                    wps.Insert(0, CreateWakePoint(origin));
                }
                //kill points, if needed

                for (int i = wps.Count - 1; i >= 0; i--)
				{
					if(wps[i].age > _maxAge)
					{
                        wps.RemoveAt(i);
                    }
					else
					{
						
						wps[i].age += Time.deltaTime;
                        wps[i].pos += (wps[i].dir * (2f * x)) * Time.deltaTime;
                        points.Insert(1, wps[i].pos);
                    }
                }
                _wake.lines[s]._lineRenderer.positionCount = points.Count;
                _wake.lines[s]._lineRenderer.SetPositions(points.ToArray());
                s++;
            }
        }
    }

	WakePoint CreateWakePoint(Vector3 pos)
	{
        WakePoint wp = new WakePoint(pos);
        wp.dir = transform.right;
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
            Vector3 o = w.origin;
            
            foreach(WakeLine wl in w.lines)
			{
				int side = 0;
                Vector3 oPoint = OffsetGenPoint(o, side);
				foreach(WakePoint wp in wl.points)
				{
                    Gizmos.DrawSphere(wp.pos, (_maxAge - wp.age) * 0.2f);
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

	public class WakeLine
	{
        public LineRenderer _lineRenderer;
        public List<WakePoint> points = new List<WakePoint>();
    }

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
