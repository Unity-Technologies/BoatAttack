using System;
using BoatAttack;
using UnityEngine;

public class WaypointTest : MonoBehaviour
{
    public WaypointGroup wpGroup;

    public float segmentPercentage;
    public float trackPercentage;

    private void OnDrawGizmosSelected()
    {
        if (!wpGroup) return;

        var position = transform.position;
        var closestWp = wpGroup.GetClosestWaypoint(position);


        Gizmos.color = Color.blue;
        Gizmos.DrawLine(position, closestWp.point);
        Gizmos.color = Color.red;
        var closestPoint =
            wpGroup.GetClosestPointOnPath(position, out Tuple<WaypointGroup.Waypoint, WaypointGroup.Waypoint> wps);
        Gizmos.DrawLine(position, closestPoint);

        var loop = wps.Item2.normalizedDistance <= 0;

        segmentPercentage = (loop ? 1f : wps.Item2.normalizedDistance) - wps.Item1.normalizedDistance;
        var segmentDistance = wpGroup.length * segmentPercentage;
        var positionSegmentPercentage = Vector3.Distance(closestPoint, wps.Item1.point) / segmentDistance;
        trackPercentage = Mathf.Lerp(wps.Item1.normalizedDistance, (loop ? 1f : wps.Item2.normalizedDistance), positionSegmentPercentage);
    }
}
