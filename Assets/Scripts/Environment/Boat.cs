using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    public float posX = 75f;
    private float max = 75f, min = 40f, speed = 0.01f;
    private bool dir = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dir)
        {
            posX -= speed;
            dir = posX >= min ? true : false;
        }
        else
        {
            posX += speed;
            dir = posX <= max ? false : true;
        }
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
    }
}
