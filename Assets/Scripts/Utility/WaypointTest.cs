using BoatAttack;
using UnityEngine;

public class WaypointTest : MonoBehaviour
{
    public WaypointGroup wpGroup;

    private void OnDrawGizmosSelected()
    {
        if (!wpGroup) return;
        
        var position = transform.position;
        var closestWp = wpGroup.GetClosestWaypoint(position);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(position, closestWp.point);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(position, wpGroup.GetClosestPointOnPath(position));
    }
}
