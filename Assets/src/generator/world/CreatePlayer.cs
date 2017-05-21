using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayer : MonoBehaviour {
    public GameObject player;

    private float worldSize;

    private void Awake()
    {
        worldSize = GetComponent<CreateWorld>().worldSize;
        InstantiatePlayer();
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void InstantiatePlayer()
    {
        player.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        Instantiate(player, new Vector3(-0.395f, worldSize / 2 + player.transform.localScale.y / 2 + 0.5f, -0.395f), Quaternion.identity);
    }
}
