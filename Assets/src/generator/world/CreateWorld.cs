using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWorld : MonoBehaviour {

    public GameObject cube;

    public float worldSize;
    public float gap;

    [HideInInspector]
    public List<GameObject> objectList;

    // Use this for initialization
    void Start () {
        GenerateWorld();
        ColorWorld();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void GenerateWorld()
    {
        for(float x = -(worldSize / 2); x < (worldSize / 2); x += gap)
        {
            for (float y = -(worldSize / 2); y < (worldSize / 2); y += gap)
            {
                for (float z = -(worldSize / 2); z < (worldSize / 2); z += gap)
                {
                    objectList.Add(Instantiate(cube, new Vector3(x, y, z), Quaternion.identity));
                }
            }
        }
    }
    
    private void ColorWorld()
    {
        foreach(GameObject cube in objectList)
        {
            if(cube.transform.position.x == (-(worldSize / 2) + (worldSize - 1) * gap))
            {
                cube.GetComponent<Renderer>().material.color = Color.blue;
            }
            else if (cube.transform.position.x == -(worldSize / 2))
            {
                cube.GetComponent<Renderer>().material.color = Color.green;
            }

            if (cube.transform.position.y == (-(worldSize / 2) + (worldSize - 1) * gap))
            {
                cube.GetComponent<Renderer>().material.color = Color.yellow;
            }
            else if (cube.transform.position.y == -(worldSize / 2))
            {
                cube.GetComponent<Renderer>().material.color = Color.cyan;
            }

            if (cube.transform.position.z == (-(worldSize / 2) + (worldSize - 1) * gap))
            {
                cube.GetComponent<Renderer>().material.color = Color.magenta;
            }
            else if (cube.transform.position.z == -(worldSize / 2))
            {
                cube.GetComponent<Renderer>().material.color = Color.grey;
            }
        }
    }
}
