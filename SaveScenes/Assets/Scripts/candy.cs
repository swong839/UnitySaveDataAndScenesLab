using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class candy : MonoBehaviour {

    public Text candyText;
    GameObject player;
    playerController controller;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        controller = player.GetComponent<playerController>();
	}
	
	// Update is called once per frame
	void Update () {
        candyText.text = "Candies: " + controller.checkCandy().ToString();
	}
}
