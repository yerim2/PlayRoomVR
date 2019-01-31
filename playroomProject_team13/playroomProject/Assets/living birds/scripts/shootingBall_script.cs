using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shootingBall_script : MonoBehaviour {
    public int count;
    public Text finished;
    public GameObject ball;

    lb_Bird bird01;


    private void OnTriggerEnter(Collider bird)
    {
        if (bird.gameObject.CompareTag("lb_bird"))
        {
            //여기 collider타입의 bird를 어떻게 lb_bird와 연결시켜주는지 아직 못함
            //Destroy(bird.gameObject);
            //bird01 = bird.GetComponent<lb_Bird>();
            //bird01.KillBird();
            //Destroy(bird.gameObject);
            ball.gameObject.SetActive(false);
            count++;
            finished.text = "score: " + count * 10;
        }

        if (count == 5)
        {
            //finished.text = "Hurray! :D";
        }
        else
        {
            //finished.text = "";
        }

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
