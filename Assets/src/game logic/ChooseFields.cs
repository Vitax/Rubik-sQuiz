using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseFields : MonoBehaviour {
    
    private List<GameObject> world;
    private List<GameObject> list = new List<GameObject>();

    private string[,,] cube;

    private bool hasTarget = false;
    private int rayLength = 100;

    private float width;
    private float height;
    private float depth;
    private float gap;

    private Color currentColor;

	// Use this for initialization
	void Start () {
        world = GetComponent<CreateWorld>().objectList;

        width = GetComponent<CreateWorld>().worldSize;
        height = width;
        depth = width;

        gap = GetComponent<CreateWorld>().gap;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasTarget == false) { 
            Target();
        } else if (hasTarget == true)
        {

        }
    }


    private void Target()
    {
        Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(raycast, out hit, rayLength) && Input.GetMouseButtonDown(0) && hasTarget == false)
        {
            Debug.Log(hit.transform.position.x + " " + hit.transform.position.y + " " + hit.transform.position.z);

            foreach (GameObject cube in world)
            {
                if(cube.transform.position.x == hit.transform.position.x && cube.transform.position.y == hit.transform.position.y)
                {
                    list.Add(cube);    
                } else if(cube.transform.position.z == hit.transform.position.z && cube.transform.position.y == hit.transform.position.y)
                {
                    list.Add(cube);
                } else if (cube.transform.position.z == hit.transform.position.z && cube.transform.position.x == hit.transform.position.x)
                {
                    list.Add(cube);
                }

                foreach (GameObject obj in list)
                {
                    
                    obj.GetComponent<Renderer>().material.color = Color.red;
                    hasTarget = true;
                }
            }
        }
    }

    private void Untarget()
    {

    }
}
