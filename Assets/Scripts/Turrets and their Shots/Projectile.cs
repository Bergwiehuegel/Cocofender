using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected Transform target;
    protected Vector3 targetPosition;
    
    protected Rigidbody pro;
    protected Vector3 myVel; 

    public GameObject impactEffect;

    public float speed = 50f;

    public void Seek (Transform _target)
    {
        target = _target;
        pro = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            DropDead();
            return;
        }
        targetPosition = target.position;

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Environment")
        {
            //Debug.Log("Boden getroffen!");
            GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectIns, 0.2f);
            Destroy(gameObject);
        }

    }

    protected void HitTarget()
    {
        //Debug.Log("Hit target "+target);
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 0.2f);
        Destroy(target.gameObject);
        Destroy(gameObject);

    }

    public virtual void DropDead()
    {
        Vector3 targetDir = new Vector3(targetPosition.x, 0, targetPosition.z);
        Vector3 toMove = targetDir - transform.position;
        float distancePerFrame = speed * Time.deltaTime;
        Debug.Log("MyPos: " + transform.position);

        transform.Translate(toMove.normalized * distancePerFrame, Space.World);
    }
}
