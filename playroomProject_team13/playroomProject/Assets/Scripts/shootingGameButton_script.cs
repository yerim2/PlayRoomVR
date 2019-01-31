using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shootingGameButton_script : MonoBehaviour {


    AudioSource button_sound;
    public AudioClip button_sound_clip;
    public AudioClip gameStart_sound_clip;

    Animator anim;
    int buttonDefaultHash;
    int buttonPressedHash;
    int buttonUnpressedHash;
    bool pressed;
    public Text scoreBirds;
    public Image shootingPoint;
    public GameObject livingBirdsController;
    public GameObject howToShoot;



    private void OnEnable()
    {
        //panel.gameObject.SetActive(false);
        anim = gameObject.GetComponent<Animator>();
        pressed = false;
        buttonDefaultHash = Animator.StringToHash("Base Layer.buttonDefault_animation");
        buttonPressedHash = Animator.StringToHash("Base Layer.buttonPressed_animation");
        buttonUnpressedHash = Animator.StringToHash("Base Layer.buttonUnpressed_animation");
    }

    //vive로 터치하면 동작하는 그 함수 안에 이 내용 쓰기.
    void OnTriggerEnter(Collider other)
    {

        if(other.tag == "GameController")
        {
            if (pressed == false) {
                button_sound.PlayOneShot(button_sound_clip, 1);
                anim.Play(buttonPressedHash); pressed = true;
                scoreBirds.enabled = true;
                shootingPoint.enabled = true;
                button_sound.PlayOneShot(gameStart_sound_clip, 1);
                livingBirdsController.SetActive(true);
                howToShoot.gameObject.SetActive(false);
                //panel.gameObject.SetActive(true);
            }
            else if(pressed==true){
                button_sound.PlayOneShot(button_sound_clip, 1);
                scoreBirds.enabled = false;
                shootingPoint.enabled = false;
                anim.Play(buttonUnpressedHash); pressed = false;
                livingBirdsController.SetActive(false);

            }
        }

       
        
    }
    // Use this for initialization
    void Start () {
     
        anim.Play(buttonDefaultHash);
        livingBirdsController.SetActive(false);
        button_sound = GetComponent<AudioSource>();
        //pressed = false;
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
