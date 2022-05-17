using UnityEngine;

public class Projectile_Blast : Projectile
{
    public Transform blastTip;


    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            //Debug.Log("Target: "+targetPosition);
            DropDead();
            return;
        }
        targetPosition = target.position;

        Vector3 dir = target.position - blastTip.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

        dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        transform.rotation = Quaternion.Euler(90f, rotation.y, 0f);
    }

    public override void DropDead()
    {
        Vector3 targetDir = new Vector3(targetPosition.x, 0, targetPosition.z);
        Vector3 dir = targetDir - blastTip.position;
        float distanceThisFrame = speed * Time.deltaTime;

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

        dir = targetDir - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        transform.rotation = Quaternion.Euler(90f, rotation.y, 0f);
    }
}
