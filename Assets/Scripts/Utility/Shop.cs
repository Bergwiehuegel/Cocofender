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
        Debug.Log("Balliste ausgew�hlt");
        
        buildManager.SelectTurretToBuild(balliste);
    }

    public void SelectCannon()
    {
        Debug.Log("Kanone ausgew�hlt");
        
        buildManager.SelectTurretToBuild(kanone);
    }

    public void SelectBlaster()
    {
        Debug.Log("Blaster ausgew�hlt");
        
        buildManager.SelectTurretToBuild(blaster);
    }
}
