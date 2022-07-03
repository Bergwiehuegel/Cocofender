using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    [SerializeField] private AudioSource not_enough_mula;
    [SerializeField] private AudioSource buy_sound;
    [SerializeField] private AudioSource place_tower;
    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More Than One BuildManager in scene!");
            return;
        }
        instance = this;
    }

    [Header("Available Towers")]
    public GameObject ballistaTurretPrefab;
    public GameObject cannonTurretPrefab;
    public GameObject blasterTurretPrefab;

    private TurretBlueprint turretToBuild;
    
    public bool CanBuild { get { return turretToBuild != null;  } }
    public bool CanAfford { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        if(PlayerStats.Money < turretToBuild.cost)
        {
            not_enough_mula.Play();
        }
        else
        {
            buy_sound.Play();
        }

    }

    public void UnselectTurretToBuild()
    {
        turretToBuild = null;
    }

    public void BuildTurretOn(TileNode node)
    {
        if(PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not Enough Moneeeyyy!");
            
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
        place_tower.Play();
        Debug.Log("Turret built! Money left: " + PlayerStats.Money);
    }
}
