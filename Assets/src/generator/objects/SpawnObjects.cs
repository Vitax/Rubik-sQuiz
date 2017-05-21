using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour {

    public GameObject item;

    private List<GameObject> world;
    private bool once = false;
    private float worldSize;
    private float gap;

    // Use this for initialization
    void Start()
    {
        world = GetComponent<CreateWorld>().objectList;
        worldSize = GetComponent<CreateWorld>().worldSize;
        gap = GetComponent<CreateWorld>().gap;

        item.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
    }
    
    // Update is called once per frame
    void Update () {
        SpawnItems();
    }

    private void SpawnItems()
    {
        if(once == false) { 
            foreach (GameObject cube in world)
            {
                if (cube.transform.position.x == 0 && cube.transform.position.y == 1 + gap) {

                    Debug.Log("position x: " + cube.transform.position.x + " y: " + cube.transform.position.y);
                    Instantiate(item, new Vector3(cube.transform.position.x, cube.transform.position.y + (cube.transform.localScale.y / 2), cube.transform.position.z), Quaternion.identity);
                } else if(cube.transform.position.x == -(worldSize / 2) && cube.transform.position.z == -(worldSize / 2))
                {
                    Instantiate(item, new Vector3(cube.transform.position.x - (cube.transform.localScale.x / 2), cube.transform.position.y, cube.transform.position.z), item.transform.rotation * Quaternion.Euler(new Vector3(0,0,90)));
                }
            }
        }

        once = true;
    }
}
