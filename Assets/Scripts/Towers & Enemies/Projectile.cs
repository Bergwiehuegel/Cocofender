using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected GameObject target;
    
    
    [Header("Attributes")]
    public float speed = 50f;
    public float damage = 10f;
    public float damageRadius = 0f; //radius of damage, if 0 weapon has no explosion damage
    public float slowPercent = 0f; //blaster can slow enemies

    [Header("Unity Setup Fields")]
    public GameObject impactEffect;
    public Transform pivot;

    public void Seek (GameObject enemy)
    {
        target = enemy;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) //prevent projectiles from flying around when loosing their target
        {
            DropDead();
            return;
        }

        //move projectile towards its target
        Vector3 dir = target.transform.position - pivot.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

        //rotate projectiles around their pivot point facing its target
        dir = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        transform.rotation = Quaternion.Euler(90f, rotation.y, 0f);
    }

    void OnCollisionEnter(Collision collision) //destroyes the projectile after it collides with the environment
    {
        if (collision.gameObject.tag == "Environment")
        {
            GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectIns, 0.2f);
            Destroy(gameObject);
        }

    }

    protected void HitTarget() //creates a hit-effect and calls either explode (if aoe) or damage
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 0.2f);

        if (damageRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

    protected void Explode() //checks for enemy hitboxes in damageRadius and damages them
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, damageRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.gameObject);
            }
        }
    }

    protected void Damage(GameObject enemy) //calls the damage function from enemy, also applies slow and destroyes armor if fitting
    {
        Enemy enemyScript = enemy.GetComponent<Enemy>();

        if (enemy != null)
        {
            if (slowPercent > 0f)
            {
                enemyScript.Slow(slowPercent);
            }
            if (damageRadius > 0f)
            {
                enemyScript.removeArmor();
            }

            enemyScript.TakeDamage(damage);
        }
    }

    public virtual void DropDead() //let the bullet drop to the ground where it collides with the environment
    {
        Vector3 targetDir = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 dir = targetDir - pivot.position;

        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        dir = targetDir - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        transform.rotation = Quaternion.Euler(90f, rotation.y, 0f);
    }
}
