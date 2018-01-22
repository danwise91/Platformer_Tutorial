using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    private InputState inputState;
    private Walk walkBehavior;
	private Animator animator;
    private CollisionState collisionState;
    private Duck duckBehaviour;

    void Awake()
    {
        inputState = GetComponent<InputState>();
		walkBehavior = GetComponent<Walk>();
		animator = GetComponent<Animator> ();
        collisionState = GetComponent<CollisionState>();
        duckBehaviour = GetComponent<Duck>();

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (collisionState.standing)
        {
            ChangeAnimationState(0);
        }


		if(inputState.absVelx == 0){
			ChangeAnimationState(0);
		}

		if (inputState.absVelx > 0) {
			ChangeAnimationState (1);
		}

        if (inputState.absVely > 0)
        {
            ChangeAnimationState(2);
        }

		animator.speed = walkBehavior.running ? walkBehavior.runMultiplyer : 1;

        if (duckBehaviour.ducking)
        {
            ChangeAnimationState(3);
        }

        if (!collisionState.standing && collisionState.onWall)
        {
            ChangeAnimationState(4);
        }
	}

	void ChangeAnimationState(int value){
		animator.SetInteger ("AnimState", value);
	}
}
