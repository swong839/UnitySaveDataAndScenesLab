using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour {

    Vector3 initPos;
    Transform tr;
    GameObject player;
    Transform plTr;
    Vector3 playerPos;

    private float scale;
    private float dampen = 1;
    Vector3 velocity = Vector3.zero;
    public float smoothTime = 0.25f;
    private float maxSpeed = 10;

    // Use this for initialization
    void Start () {
        tr = GetComponent<Transform>();
        initPos = tr.position;
        player = GameObject.Find("Player");
        plTr = player.GetComponent<Transform>();
        scale = Screen.width / 723;
    }
	
	// Update is called once per frame
	void Update () {
        playerPos = plTr.position;
        if (checkPos() && playerPos.x > -6)
        {
            transform.position = Vector3.SmoothDamp(initPos, new Vector3(playerPos.x, initPos.y, initPos.z), ref velocity, smoothTime * scale, maxSpeed);
            initPos = transform.position;
        }
    }

    private bool checkPos()
    {
        return playerPos.x > initPos.x + (scale * dampen) || playerPos.x < initPos.x - (scale * dampen);
    }
}
