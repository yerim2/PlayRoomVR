using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball_generator : MonoBehaviour {

    public GameObject basketball2;
    public GameObject basketball3;
    public GameObject basketball4;
    AudioSource snd;
    public AudioClip Audio1;
    public Text scoreText;
    int score = 0;

    // Use this for initialization
    void Start () {
        snd = GetComponent<AudioSource>();
        scoreText.text="Score: 0";
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "basketball1" || other.gameObject.tag == "basketball3")
        {
            snd.PlayOneShot(Audio1, 1);
            basketball2.gameObject.SetActive(true);
            basketball4.gameObject.SetActive(true);
            score += 10;
            scoreText.text = "Score: " + score.ToString();

        }
        else if (other.gameObject.tag == "basketball2")
        {
            snd.PlayOneShot(Audio1, 1);
            basketball3.gameObject.SetActive(true);
            score += 10;
            scoreText.text = "Score: " + score.ToString();
        }


    }
}
