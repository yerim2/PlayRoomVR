using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textManager : MonoBehaviour {
    public Text scoreBirds;
    public Text scoreBasketball;
    public Image shootingPoint;

	// Use this for initialization
	void Start () {
        scoreBirds.enabled = false;
        scoreBasketball.enabled = false;
        shootingPoint.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
