using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_script : MonoBehaviour {
    public GameObject ball;
    public Transform player;
    //bool inHands = false;
    bool shootingGameStarted = false;
    Vector3 ballPos;
    Collider ballCol;
    Rigidbody ballRb;
    Camera cam;
    public float handPower;
    private SteamVR_TrackedObject trackedObj;
    public GameObject livingBirdsController;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    /*
    private void OnMouseDown()
    {
        ball.gameObject.SetActive(true);
        ball.transform.SetParent(player.transform);
        ball.transform.localPosition = new Vector3(0, -0.6f, 0);
        ballCol.isTrigger = true;
        ballRb.velocity = cam.transform.rotation * Vector3.forward * handPower;
    }*/

    // Use this for initialization
    void Start () {
        ballPos = ball.transform.position;
        ballCol = ball.GetComponent<SphereCollider>();
        ballRb = ball.GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update() {
        /*
        // requires you to set up axes "Joy0X" - "Joy3X" and "Joy0Y" - "Joy3Y" in the Input Manger
        for (int i = 0; i < 4; i++)
        {
            if (Mathf.Abs(Input.GetAxis("Joy" + i + "X")) > 0.2 ||
                Mathf.Abs(Input.GetAxis("Joy" + i + "Y")) > 0.2)
            {
                Debug.Log(Input.GetJoystickNames()[i] + " is moved");
            }
        }*/
        if (livingBirdsController.activeSelf)
        {
            shootingGameStarted = true;
        }

        if (shootingGameStarted) { 
            if (Controller.GetHairTriggerDown())
            {
                //새총 당기는 소리재생
            }

            if (Controller.GetHairTriggerUp())
            {
                ball.gameObject.SetActive(true);
                ball.transform.SetParent(player.transform);
                ball.transform.localPosition = new Vector3(0, 0, 0);
                ballCol.isTrigger = true;
                ballRb.velocity = cam.transform.rotation * Vector3.forward * handPower;
            }
        }

        /*
        if (Input.GetMouseButtonDown(0))
        {
            ball.gameObject.SetActive(true);
            ball.transform.SetParent(player.transform);
            ball.transform.localPosition = new Vector3(0, 0, 0);
            ballCol.isTrigger = true;
            ballRb.velocity = cam.transform.rotation * Vector3.forward * handPower;
        }*/
	}
}
