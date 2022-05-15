using UnityEngine;

public class TileNode : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 spawnPosition;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    // Start is called before the first frame update

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.materials[1].color;
        //Debug.Log(startMaterial);
    }

    void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("Cannot Build here!!!");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + spawnPosition, transform.rotation);
    }


    // Update is called once per frame
    void OnMouseEnter()
    {
        //Debug.Log("MouseEntered?");
        rend.materials[1].color = hoverColor;
        //rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        //Debug.Log("Mouse Exited?");
        rend.materials[1].color = startColor;
        //rend.material.color = startColor;
    }
}
