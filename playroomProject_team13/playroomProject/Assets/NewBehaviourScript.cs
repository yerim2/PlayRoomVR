using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    AudioSource snd1;
    AudioSource snd2;
    AudioSource snd3;
    Vector3 humanPosition;
    public AudioClip Audio1;
    public AudioClip Audio2;
    public AudioClip intro;
    public GameObject HowToMusic;
    public GameObject HowToMusic2;

    // Use this for initialization
    void Start () {
        snd1 = GetComponent<AudioSource>();
        snd2 = GetComponent<AudioSource>();
        snd3 = GetComponent<AudioSource>();
        humanPosition = transform.localPosition;

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "red_Ball")
        {
            snd2.Stop();
            snd1.PlayOneShot(Audio1, 1);
            //HowToMusic.gameObject.SetActive(false);
            HowToMusic2.gameObject.SetActive(false);
        }
        if(coll.gameObject.tag == "blue_Ball")
        {
            snd1.Stop();
            snd2.PlayOneShot(Audio2, 1);
            //HowToMusic.gameObject.SetActive(false);
            HowToMusic2.gameObject.SetActive(false);
        }
        if (coll.gameObject.tag == "startball")
        {
            snd1.Stop();
            snd2.PlayOneShot(intro, 1);
            HowToMusic.gameObject.SetActive(false);
        }
    }
}
