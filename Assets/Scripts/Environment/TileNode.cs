using UnityEngine;
using UnityEngine.EventSystems;

public class TileNode : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 spawnPosition;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.materials[1].color;
        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if (buildManager.GetTurretToBuild() == null)
            return;

        if(turret != null)
        {
            Debug.Log("Cannot Build here!!!");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + spawnPosition, transform.rotation);

        buildManager.RemoveTurretToBuild();
    }


    void OnMouseEnter()
    {
        //if (EventSystem.current.IsPointerOverGameObject())
        //    return;

        if (buildManager.GetTurretToBuild() == null)
            return;

        rend.materials[1].color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.materials[1].color = startColor;
    }
}
