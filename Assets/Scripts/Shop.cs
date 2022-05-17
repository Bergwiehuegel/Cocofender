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
        Debug.Log("Balliste ausgewählt");
        buildManager.SetTurretToBuild(buildManager.ballistaTurretPrefab);
    }

    public void PurchaseCannon()
    {
        Debug.Log("Kanone ausgewählt");
        buildManager.SetTurretToBuild(buildManager.cannonTurretPrefab);
    }

    public void PurchaseBlaster()
    {
        Debug.Log("Blaster ausgewählt");
        buildManager.SetTurretToBuild(buildManager.blasterTurretPrefab);
    }
}
