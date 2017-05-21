using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatePath : MonoBehaviour {

    private List<GameObject> wholeList;

    private void Awake()
    {
        wholeList = GetComponent<CreateWorld>().objectList;
    }

    // Use this for initialization
    void Start () {
        wholeList = GetComponent<CreateWorld>().objectList;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
