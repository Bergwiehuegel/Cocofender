using UnityEngine;
using UnityEngine.EventSystems;

public class TileNode : MonoBehaviour
{
    public Color cannotBuildColor;
    public Color canBuildColor;
    public Vector3 spawnPosition;

    [Header ("Optional")]
    public GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.materials[1].color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + spawnPosition;
    }

    void OnMouseDown()
    {
        if (!buildManager.CanBuild)
            return;

        if(turret != null)
        {
            Debug.Log("Cannot Build here!!!");
            return;
        }

        buildManager.BuildTurretOn(this);
        buildManager.UnselectTurretToBuild();
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.CanAfford)
            rend.materials[1].color = canBuildColor;
        else
            rend.materials[1].color = cannotBuildColor;
    }

    void OnMouseExit()
    {
        rend.materials[1].color = startColor;
    }
}
