using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint balliste;
    public TurretBlueprint kanone;
    public TurretBlueprint blaster;

    BuildManager buildManager;

    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectBalliste()
    {
        Debug.Log("Balliste ausgewählt");
        buildManager.SelectTurretToBuild(balliste);
    }

    public void SelectCannon()
    {
        Debug.Log("Kanone ausgewählt");
        buildManager.SelectTurretToBuild(kanone);
    }

    public void SelectBlaster()
    {
        Debug.Log("Blaster ausgewählt");
        buildManager.SelectTurretToBuild(blaster);
    }
}
