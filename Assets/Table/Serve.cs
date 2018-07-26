using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Serve : MonoBehaviour {

    static Vector3 BALL_VELOCITY = new Vector3(4.0f, 0.0f, 5.0f);

    public void HandleClick() {
        var ball = GameObject.Find("Ball(Clone)");
        var rb = ball.GetComponent<Rigidbody>();
        rb.velocity = BALL_VELOCITY;
    }

	private void Start()
	{
        var button = GetComponent<Button>();
        button.interactable = false;
	}
}
