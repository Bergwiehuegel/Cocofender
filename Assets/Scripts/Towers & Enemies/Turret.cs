using UnityEngine;

public class Turret : MonoBehaviour
{

    protected GameObject target;

    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    protected float fireCountdown = 0f;
    public float turnSpeed = 10f;

    [Header("Unity Setup Fields")]
    public GameObject projectilePrefab;
    public Transform partToRotate;
    public Transform firePoint;
    public Transform firePointTwo;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    protected void UpdateTarget()
    {
        //find enemy in range and set it to target
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        LockOnTarget();

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void LockOnTarget() //rotates the turret towards its target
    {
        Vector3 dir = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    public virtual void Shoot() //instance a bullet shooting at the current target
    {
        GameObject projectileObject = (GameObject)Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Projectile projectile = projectileObject.GetComponent<Projectile>();

        if (projectile != null)
        {
            projectile.Seek(target);
        }

        if (firePointTwo != null)
        {
            GameObject projectileObjectTwo = (GameObject)Instantiate(projectilePrefab, firePointTwo.position, firePointTwo.rotation);
            Projectile projectileTwo = projectileObjectTwo.GetComponent<Projectile>();
            if (projectileTwo != null)
            {
                projectileTwo.Seek(target);
            }
        }
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
