using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int waypointIndex = 0;

    void Start()
    {
        target = Waypoints.points[0];
    }

    void Update()
    {

        Vector3 dir = target.position - transform.position;
        float frameTime = speed * Time.deltaTime;
        transform.Translate(dir.normalized * frameTime, Space.World);
        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time * 5f) * 0.7f + 2.5f, transform.position.z);
        transform.Rotate(0, 180*Time.deltaTime, 0);

        Vector3 dist = target.position - transform.position;
        dist.y = 0;
        //Debug.Log(dist.magnitude);

        if (dist.magnitude <= 1f)//Vector3.Distance(transform.position, target.position) <= 0.5f)
        {
            GetNextWaypoint();
        }

        
    }
        void GetNextWaypoint()
        {
            if(waypointIndex >= Waypoints.points.Length - 1)
            {
                Destroy(gameObject);
                return;
            }
            waypointIndex++;
            target = Waypoints.points[waypointIndex];
        }

}
