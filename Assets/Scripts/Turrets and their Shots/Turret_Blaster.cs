using UnityEngine;

public class Turret_Blaster : Turret
{

    public Transform firePointTwo;

    public override void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Projectile bullet = bulletGO.GetComponent<Projectile>();
        if (bullet != null)
        {
            bullet.Seek(target);
        }

        GameObject bulletGOTwo = (GameObject)Instantiate(bulletPrefab, firePointTwo.position, firePointTwo.rotation);
        Projectile bulletTwo = bulletGOTwo.GetComponent<Projectile>();
        if (bulletTwo != null)
        {
            bulletTwo.Seek(target);
        }
    }

}
