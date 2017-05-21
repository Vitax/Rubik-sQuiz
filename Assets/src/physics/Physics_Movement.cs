using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics_Movement : MonoBehaviour {
    public GameObject player;
    public float moveSpeed;

    private bool once;

    public float WorldSize;
    public float step;

    private int Boarder;

    private int xBoarder = 0;
    private int yBoarder = 0;
    private int zBoarder = 0;
    
    private float offSet = 0.02f;
    private float startTime;
    private float distCovered;

    private void Awake()
    {
        player = GameObject.Find("Player(Clone)");
        
        moveSpeed = 1f;
    }

    // Use this for initialization
    void Start () {
        Physics.gravity = new Vector3(0, -10, 0);
        Boarder = (int) (WorldSize / 2);
    }

    private void LateUpdate()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update () {
         distCovered = Time.deltaTime * moveSpeed;

        if (Physics.gravity == new Vector3(0, -10, 0))
        {
            MoveNegativeYPhysics();
        }
        else if (Physics.gravity == new Vector3(0, 10, 0))
        {
            MovePositiveYPhysics();
        }
        else if (Physics.gravity == new Vector3(0, 0, -10))
        {
            MoveNegativeZPhysics();
        }
        else if (Physics.gravity == new Vector3(0, 0, 10))
        {
            MovePositiveZPhysics();
        }
        else if (Physics.gravity == new Vector3(-10, 0, 0))
        {
            MoveNegativeXPhysics();
        } else if (Physics.gravity == new Vector3(10, 0, 0))
        {
            MovePositiveXPhysics();
        }
    }

    private void MoveNegativeXPhysics()
    {
        if (Input.GetKeyDown(KeyCode.W) && yBoarder == -Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x - step, player.transform.position.y - step, player.transform.position.z);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            Physics.gravity = new Vector3(0, 10, 0);

            xBoarder = Boarder;
            yBoarder = -Boarder;
        }
        else if (Input.GetKeyDown(KeyCode.W) && yBoarder > -Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x + offSet, player.transform.position.y - step, player.transform.position.z);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);
            yBoarder--;
        }

        if (Input.GetKeyDown(KeyCode.S) && yBoarder == Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x - step, player.transform.position.y + step, player.transform.position.z);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            Physics.gravity = new Vector3(0, -10, 0);

            xBoarder = Boarder;
            yBoarder = Boarder;
        }
        else if (Input.GetKeyDown(KeyCode.S) && yBoarder < Boarder)
        {

            Vector3 nextStep = new Vector3(player.transform.position.x + offSet, player.transform.position.y + step, player.transform.position.z);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            yBoarder++;
        }

        if (Input.GetKeyDown(KeyCode.A) && zBoarder == Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x - step, player.transform.position.y, player.transform.position.z + step);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            Physics.gravity = new Vector3(0, 0, -10);

            xBoarder = Boarder;
            zBoarder = Boarder;
        }
        else if (Input.GetKeyDown(KeyCode.A) && zBoarder < Boarder)
        {

            Vector3 nextStep = new Vector3(player.transform.position.x + offSet, player.transform.position.y, player.transform.position.z + step);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            zBoarder++;
        }

        if (Input.GetKeyDown(KeyCode.D) && zBoarder == -Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x - step, player.transform.position.y, player.transform.position.z - step);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            Physics.gravity = new Vector3(0, 0, 10);

            xBoarder = Boarder;
            zBoarder = -Boarder;
        }
        else if (Input.GetKeyDown(KeyCode.D) && zBoarder > -Boarder)
        {

            Vector3 nextStep = new Vector3(player.transform.position.x + offSet, player.transform.position.y, player.transform.position.z - step);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            zBoarder--;
        }
    }

    private void MovePositiveXPhysics()
    {
        if (Input.GetKeyDown(KeyCode.W) && yBoarder == -Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x + step, player.transform.position.y - step, player.transform.position.z);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            Physics.gravity = new Vector3(0, 10, 0);

            xBoarder = -Boarder;
            yBoarder = -Boarder;
        }
        else if (Input.GetKeyDown(KeyCode.W) && yBoarder > -Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x + offSet, player.transform.position.y - step, player.transform.position.z);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);
            Debug.Log(yBoarder);
            yBoarder--;
        }

        if (Input.GetKeyDown(KeyCode.S) && yBoarder == Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x + step, player.transform.position.y + step, player.transform.position.z);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            Physics.gravity = new Vector3(0, -10, 0);

            xBoarder = -Boarder;
            yBoarder = Boarder;
        }
        else if (Input.GetKeyDown(KeyCode.S) && yBoarder < Boarder)
        {

            Vector3 nextStep = new Vector3(player.transform.position.x + offSet, player.transform.position.y + step, player.transform.position.z);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            yBoarder++;
        }

        if (Input.GetKeyDown(KeyCode.A) && zBoarder == -Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x + step, player.transform.position.y, player.transform.position.z - step);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            Physics.gravity = new Vector3(0, 0, 10);

            xBoarder = -Boarder;
            zBoarder = -Boarder;
        }
        else if (Input.GetKeyDown(KeyCode.A) && zBoarder > -Boarder)
        {

            Vector3 nextStep = new Vector3(player.transform.position.x + offSet, player.transform.position.y, player.transform.position.z - step);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            zBoarder--;
        }

        if (Input.GetKeyDown(KeyCode.D) && zBoarder == Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x + step, player.transform.position.y, player.transform.position.z + step);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            Physics.gravity = new Vector3(0, 0, -10);

            xBoarder = -Boarder;
            zBoarder = Boarder;
        }
        else if (Input.GetKeyDown(KeyCode.D) && zBoarder < Boarder)
        {

            Vector3 nextStep = new Vector3(player.transform.position.x + offSet, player.transform.position.y, player.transform.position.z + step);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            zBoarder++;
        }
    }

    private void MoveNegativeYPhysics()
    {
        if (Input.GetKeyDown(KeyCode.W) && zBoarder == Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x, player.transform.position.y - step, player.transform.position.z + step);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            Physics.gravity = new Vector3(0, 0, -10);
            
            yBoarder = Boarder;
            zBoarder = Boarder;
        }
        else if (Input.GetKeyDown(KeyCode.W) && zBoarder < Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x, player.transform.position.y + offSet, player.transform.position.z + step);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            zBoarder++;
        }

        if(Input.GetKeyDown(KeyCode.S) && zBoarder == -Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x, player.transform.position.y - step, player.transform.position.z - step);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            Physics.gravity = new Vector3(0, 0, 10);

            yBoarder = Boarder;
            zBoarder = -Boarder;
        }
        else if (Input.GetKeyDown(KeyCode.S) && zBoarder > -Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x, player.transform.position.y + offSet, player.transform.position.z - step);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            zBoarder--;
        }

        if (Input.GetKeyDown(KeyCode.A) && xBoarder == -Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x - step, player.transform.position.y - step, player.transform.position.z);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            Physics.gravity = new Vector3(10, 0, 0);

            xBoarder = -Boarder;
            yBoarder = Boarder;
        }
        else if (Input.GetKeyDown(KeyCode.A) && xBoarder > -Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x - step, player.transform.position.y + offSet, player.transform.position.z);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            xBoarder--;
        }

        if (Input.GetKeyDown(KeyCode.D) && xBoarder == Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x + step, player.transform.position.y - step, player.transform.position.z);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            Physics.gravity = new Vector3(-10, 0, 0);

            xBoarder = Boarder;
            yBoarder = Boarder;
        }
        else if (Input.GetKeyDown(KeyCode.D) && xBoarder < Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x + step, player.transform.position.y + offSet, player.transform.position.z);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            xBoarder++;
        }
    }

    private void MovePositiveYPhysics()
    {
        if (Input.GetKeyDown(KeyCode.W) && zBoarder == -Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x, player.transform.position.y + step, player.transform.position.z - step);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            Physics.gravity = new Vector3(0, 0, 10);

            yBoarder = -Boarder;
            zBoarder = -Boarder;
        }
        else if (Input.GetKeyDown(KeyCode.W) && zBoarder > -Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x, player.transform.position.y + offSet, player.transform.position.z - step);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            zBoarder--;
        }

        if (Input.GetKeyDown(KeyCode.S) && zBoarder == Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x, player.transform.position.y + step, player.transform.position.z + step);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            Physics.gravity = new Vector3(0, 0, -10);

            yBoarder = -Boarder;
            zBoarder = Boarder;
        }
        else if (Input.GetKeyDown(KeyCode.S) && zBoarder < Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x, player.transform.position.y + offSet, player.transform.position.z + step);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            zBoarder++;
        }

        if (Input.GetKeyDown(KeyCode.A) && xBoarder == -Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x - step, player.transform.position.y + step, player.transform.position.z);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            Physics.gravity = new Vector3(10, 0, 0);

            xBoarder = -Boarder;
            yBoarder = -Boarder;
        }
        else if (Input.GetKeyDown(KeyCode.A) && xBoarder > -Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x - step, player.transform.position.y + offSet, player.transform.position.z);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            xBoarder--;
        }

        if (Input.GetKeyDown(KeyCode.D) && xBoarder == Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x + step, player.transform.position.y + step, player.transform.position.z);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            Physics.gravity = new Vector3(-10, 0, 0);

            xBoarder = Boarder;
            yBoarder = -Boarder;
        }
        else if (Input.GetKeyDown(KeyCode.D) && xBoarder < Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x + step, player.transform.position.y + offSet, player.transform.position.z);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            xBoarder++;
        }
    }

    private void MoveNegativeZPhysics()
    {
        if (Input.GetKeyDown(KeyCode.W) && yBoarder == -Boarder)
        { 
            Vector3 nextStep = new Vector3(player.transform.position.x , player.transform.position.y - step, player.transform.position.z - step);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            Physics.gravity = new Vector3(0, 10, 0);

            yBoarder = -Boarder;
            zBoarder = Boarder;
        }
        else if (Input.GetKeyDown(KeyCode.W) && yBoarder > -Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x, player.transform.position.y - step, player.transform.position.z + offSet);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            yBoarder--;
        }

        if (Input.GetKeyDown(KeyCode.S) && yBoarder == Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x, player.transform.position.y + step, player.transform.position.z - step);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            Physics.gravity = new Vector3(0, -10, 0);
            
            yBoarder = Boarder;
            zBoarder = Boarder;
        }
        else if (Input.GetKeyDown(KeyCode.S) && yBoarder < Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x, player.transform.position.y + step, player.transform.position.z + offSet);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            yBoarder++;
        }

        if (Input.GetKeyDown(KeyCode.A) && xBoarder == -Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x - step, player.transform.position.y , player.transform.position.z - step);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            Physics.gravity = new Vector3(10, 0, 0);

            xBoarder = -Boarder;
            zBoarder = Boarder;
        }
        else if (Input.GetKeyDown(KeyCode.A) && xBoarder > -Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x - step, player.transform.position.y + offSet, player.transform.position.z);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            xBoarder--;
        }

        if (Input.GetKeyDown(KeyCode.D) && xBoarder == Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x + step, player.transform.position.y, player.transform.position.z - step);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);
            player.transform.Rotate(new Vector3(0, 0, 1), 90);

            Physics.gravity = new Vector3(-10, 0, 0);

            xBoarder = Boarder;
            zBoarder = Boarder;
        }
        else if (Input.GetKeyDown(KeyCode.D) && xBoarder < Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x + step, player.transform.position.y + offSet, player.transform.position.z);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            xBoarder++;
        }
    }

    private void MovePositiveZPhysics()
    {
        if (Input.GetKeyDown(KeyCode.W) && yBoarder == Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x, player.transform.position.y + step, player.transform.position.z + step);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            Physics.gravity = new Vector3(0, -10, 0);

            yBoarder = Boarder;
            zBoarder = -Boarder;
        }
        else if (Input.GetKeyDown(KeyCode.W) && yBoarder < Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x, player.transform.position.y + step, player.transform.position.z + offSet);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            yBoarder++;
        }

        if (Input.GetKeyDown(KeyCode.S) && yBoarder == -Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x, player.transform.position.y - step, player.transform.position.z + step);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            Physics.gravity = new Vector3(0, 10, 0);

            yBoarder = -Boarder;
            zBoarder = -Boarder;
        }
        else if (Input.GetKeyDown(KeyCode.S) && yBoarder > -Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x, player.transform.position.y - step, player.transform.position.z + offSet);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            yBoarder--;
        }

        if (Input.GetKeyDown(KeyCode.A) && xBoarder == -Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x - step, player.transform.position.y , player.transform.position.z + step);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            Physics.gravity = new Vector3(10, 0, 0);
           

            xBoarder = -Boarder;
            zBoarder = -Boarder;
        }
        else if (Input.GetKeyDown(KeyCode.A) && xBoarder > -Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x - step, player.transform.position.y + offSet, player.transform.position.z);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            xBoarder--;
        }

        if (Input.GetKeyDown(KeyCode.D) && xBoarder == Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x + step, player.transform.position.y, player.transform.position.z + step);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            Physics.gravity = new Vector3(-10, 0, 0);

            xBoarder = Boarder;
            zBoarder = -Boarder;
        }
        else if (Input.GetKeyDown(KeyCode.D) && xBoarder < Boarder)
        {
            Vector3 nextStep = new Vector3(player.transform.position.x + step, player.transform.position.y + offSet, player.transform.position.z);

            float journey = Vector3.Distance(player.transform.position, nextStep);
            float frac = journey / distCovered;

            player.transform.position = Vector3.Lerp(player.transform.position, nextStep, frac);

            xBoarder++;
        }
    }
}