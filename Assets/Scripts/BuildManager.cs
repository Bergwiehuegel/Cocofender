using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

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

    void Start()
    {
        turretToBuild = ballistaTurretPrefab;
    }

    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
