/*
 * Copyright (c) 2016 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using UnityEngine;

public class ControllerGrabObject : MonoBehaviour
{
    AudioSource slingshot_shoot;
    public AudioClip shoot_sound;
    public AudioClip shoot_ready_sound;
    private SteamVR_TrackedObject trackedObj;

    private GameObject collidingObject;
    private GameObject objectInHand;

    public GameObject livingBirdsController;

    public GameObject ball;
    public Transform player;
    Vector3 ballPos;
    Collider ballCol;
    Rigidbody ballRb;
    public Camera cam;
    public float handPower;

    private Rigidbody rigidbodyOfCamerarig;
    private Rigidbody rigidbodyOfPlayer;
    public GameObject camerarig;
    //bool isflying = false;


    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }


    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }

    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }

    private void SetCollidingObject(Collider col)
    {
        /*
        if(col.gameObject.tag == "parachute")
        {
            isflying = true;
            player.transform.position = new Vector3((float)-4.82, (float)-2.2, (float)13.69);
            rigidbodyOfCamerarig.useGravity = true;
            //rigidbodyOfCamerarig.velocity = Vector3.down;
            //rigidbodyOfCamerarig.isKinematic = true;
            rigidbodyOfPlayer.useGravity = true;
            //rigidbodyOfPlayer.velocity = Vector3.down;
                // rigidbodyOfPlayer.isKinematic = true;

        }*/
        
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }

        collidingObject = col.gameObject;
    }

    void Update()
    {


        if (Controller.GetHairTriggerDown())
        {
            if (livingBirdsController.activeSelf)
            {
                //새총 당기는 소리재생
                slingshot_shoot.PlayOneShot(shoot_ready_sound, 1);
            }

            if (collidingObject)
            {
                GrabObject();
            }
            /*
            if (isflying)
            {
                rigidbodyOfCamerarig.drag = 10;
                rigidbodyOfPlayer.drag = 10;
            }*/
        }

        if (Controller.GetHairTriggerUp())
        {

            if (livingBirdsController.activeSelf)
            {
                ball.gameObject.SetActive(true);
                ball.transform.SetParent(cam.transform);
                ball.transform.localPosition = new Vector3(0, 0, 0);
                ballCol.isTrigger = true;
                slingshot_shoot.PlayOneShot(shoot_sound, 1);
                ballRb.velocity = cam.transform.rotation * Vector3.forward * handPower;
                

                
            }

            if (objectInHand)
            {
                ReleaseObject();
            }
        }
    }

    void Start()
    {
        ballPos = ball.transform.position;
        ballCol = ball.GetComponent<SphereCollider>();
        ballRb = ball.GetComponent<Rigidbody>();
        slingshot_shoot = GetComponent<AudioSource>();
        rigidbodyOfCamerarig = camerarig.GetComponent<Rigidbody>();
        rigidbodyOfPlayer = player.GetComponent<Rigidbody>();
        
        //cam = GetComponentInParent<Camera>();
    }

    private void GrabObject()
    {
        objectInHand = collidingObject;
        collidingObject = null;
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
            objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
        }

        objectInHand = null;
    }
}
