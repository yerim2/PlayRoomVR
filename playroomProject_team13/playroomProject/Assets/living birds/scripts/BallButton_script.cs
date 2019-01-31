using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallButton_script : MonoBehaviour
{

    AudioSource basket_ball;
    public AudioClip basket_music;

    AudioSource button_sound;
    public AudioClip button_sound_clip;

    Animator anim;
    int buttonDefaultHash;
    int buttonPressedHash;
    int buttonUnpressedHash;
    bool pressed;

    public GameObject basketball1;
    public GameObject basketball2;
    public GameObject basketball3;
    public GameObject basketball4;

    public GameObject wall1;
    public GameObject wall2;
    public Text scoreText;
    public GameObject howto;

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

        if (other.tag == "GameController")
        {
            if (pressed == false)
            {
                button_sound.PlayOneShot(button_sound_clip, 1);
                anim.Play(buttonPressedHash); pressed = true;
                basketball1.gameObject.SetActive(true);
                wall1.gameObject.SetActive(true);
                wall2.gameObject.SetActive(true);
                howto.gameObject.SetActive(false);
                scoreText.enabled = true;
                basket_ball.PlayOneShot(basket_music, 1); //음악시작
                scoreText.text = "Score: 0";
                //panel.gameObject.SetActive(true);
            }
            else if (pressed == true)
            {
                
                anim.Play(buttonUnpressedHash); pressed = false;
                basketball1.gameObject.SetActive(false);
                basketball2.gameObject.SetActive(false);
                basketball3.gameObject.SetActive(false);
                basketball4.gameObject.SetActive(false);

                wall1.gameObject.SetActive(false);
                wall2.gameObject.SetActive(false);

                scoreText.enabled = false;

                basket_ball.Stop(); //음악중지
                button_sound.PlayOneShot(button_sound_clip, 1);

            }
        }



    }
    // Use this for initialization
    void Start()
    {
        basket_ball = GetComponent<AudioSource>();
        button_sound = GetComponent<AudioSource>();
        anim.Play(buttonDefaultHash);
       
        //pressed = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}