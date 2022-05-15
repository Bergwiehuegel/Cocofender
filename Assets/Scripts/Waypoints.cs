using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;

    void Awake()
    {
        points = new Transform[transform.childCount];

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }

    void OnDrawGizmosSelected()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if (i == transform.childCount - 1)
                break;
            Transform kind = transform.GetChild(i);
            Transform nextKind = transform.GetChild(i + 1);

            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(kind.position, nextKind.position);
        }
    }

}
