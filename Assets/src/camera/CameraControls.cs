using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour {

    public new Camera camera;
    public float rotationSpeed;

    private bool rotateAble = false;
    private float worldSize;
    private double x = 0;
    private double y = 0;
    private double z = 0;
    private int distance;

    private void Awake()
    {
        worldSize = GetComponent<CreateWorld>().worldSize;

        Vector3 angle = camera.transform.eulerAngles;
        distance = (int)worldSize + (int)worldSize - 2;

        x = angle.x;
        y = angle.y;
        z = angle.z;
    }

    // Use this for initialization
    void Start () {
        var rotation = Quaternion.Euler((float)x, (float)y, 0);
        var position = rotation * new Vector3(0, 0, -distance);

        camera.transform.rotation = rotation;
        camera.transform.position = position;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1))
            rotateAble = true;

        if (Input.GetMouseButtonUp(1))
            rotateAble = false;

    }

    private void LateUpdate()
    {
        if (rotateAble == true)
        {
            x -= Input.GetAxis("Mouse Y") * rotationSpeed * distance;
            y += Input.GetAxis("Mouse X") * rotationSpeed * distance;

            var rotation = Quaternion.Euler((float)x, (float) y, 0);
            var position = rotation * new Vector3(0, 0, -distance);

            camera.transform.rotation = rotation;
            camera.transform.position = position;
        }
    }
}
