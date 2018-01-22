using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : AbstractBehaviour {
    public float speed = 50f;
    public float runMultiplyer = 2f; 
	public bool running; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		running = false; 
        var right = inputState.GetButtonValue(inputButtons[0]);
        var left = inputState.GetButtonValue(inputButtons[1]);
        var run = inputState.GetButtonValue(inputButtons[2]);


        if (right || left)
        {
            var tempSpeed = speed;

            if (run && runMultiplyer > 0)
            {
                tempSpeed *= runMultiplyer;
				running = true; 
            }

            var velX = tempSpeed * (float)inputState.direction;
            body2D.velocity = new Vector2(velX, body2D.velocity.y);
        }

    }
}
