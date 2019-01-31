using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird_motion : MonoBehaviour {

    public Transform player;
    int MoveSpeed = 1;
    int MaxDist = 100;
    int MinDist = 1;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(player);

        //transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, player.position) >= MinDist)
        {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            transform.Rotate(new Vector3(5, 5, 0));
            if (Vector3.Distance(transform.position, player.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
            }
            else
            {
                transform.position = new Vector3(Random.Range(-5, 5), -2, Random.Range(-5, 5));
            }
        }
    }
}
