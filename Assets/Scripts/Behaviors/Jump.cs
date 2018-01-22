using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : AbstractBehaviour {
    public float jumpSpeed = 200f;

    public float jumpDelay = .1f;
    public int jumpCount = 2;
    public GameObject dusteffectPrefab;
    protected float lastJumpTime = 0;
    protected int jumpsRemaining = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected virtual void Update () {
        var canJump = inputState.GetButtonValue(inputButtons[0]);
        var holdTime = inputState.GetButtonHoldTime(inputButtons[0]);

        if (collisionState.standing)
        {
            if (canJump && holdTime < .1f)
            {
                jumpsRemaining = jumpCount - 1;
                OnJump();
            }
        } else
        {
            if (canJump && holdTime < .1f && Time.time - lastJumpTime > jumpDelay)
            {
                if (jumpsRemaining > 0)
                {
                    OnJump();
                    jumpsRemaining = jumpCount - 1;
                    var clone = Instantiate(dusteffectPrefab);
                    clone.transform.position = transform.position;
                }

            }
        }
	}

    protected virtual void OnJump()
    {
        var vel = body2D.velocity;
        lastJumpTime = Time.time; 
        body2D.velocity = new Vector2(vel.x, jumpSpeed);
    }
}
