using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseBalliste()
    {
        Debug.Log("Balliste ausgew�hlt");
        buildManager.SetTurretToBuild(buildManager.ballistaTurretPrefab);
    }

    public void PurchaseCannon()
    {
        Debug.Log("Kanone ausgew�hlt");
        buildManager.SetTurretToBuild(buildManager.cannonTurretPrefab);
    }

    public void PurchaseBlaster()
    {
        Debug.Log("Blaster ausgew�hlt");
        buildManager.SetTurretToBuild(buildManager.blasterTurretPrefab);
    }
}
