using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterState
{
    idle,
    walking, 
    running, 
    jumping
}

public class SteveController : MonoBehaviour {

    public MemberController left_arm; 
    public MemberController right_arm; 
    public MemberController left_leg; 
    public MemberController right_leg;

    public CharacterState _state;
    public float normalSpeed = 10.0f;
    public float runningSpeed = 20.0f; 

    public float rotationSpeed = 100.0f;

    public float membersNormalSpeed = 200.0f; 
    public float membersRunningSpeed = 300.0f; 

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        GetState();

        if (_state == CharacterState.walking)
            this.Move(this.normalSpeed, this.membersNormalSpeed);

        if (_state == CharacterState.running)
            this.Move(this.runningSpeed, this.membersRunningSpeed); 

        if (_state == CharacterState.jumping)
            this.Jump();

        if (_state == CharacterState.idle)
            this.ReturnToIdle(this.membersRunningSpeed);
    }

    void GetState()
    {

        if (Input.GetButton("Vertical"))
        {
            if (Input.GetButton("Sprint"))
            {
                _state = CharacterState.running; 
            }
            else
            {
                _state = CharacterState.walking;
            }
        }
        else if (Input.GetButton("Jump"))
        {
            _state = CharacterState.walking;
        }
        else
        {
            _state = CharacterState.idle;
        }
    }

    void Move(float playerSpeed, float membersSpeed)
    {
        this.MoveMembers(membersSpeed);

        float translation = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * this.rotationSpeed * Time.deltaTime; 
        
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
    }

    private void MoveMembers(float speed)
    {
        this.left_arm.Move(speed); 
        this.right_arm.Move(speed); 
        this.left_leg.Move(speed); 
        this.right_leg.Move(speed); 

    }

    private void ReturnToIdle(float speed)
    {
        this.left_arm.ReturnToIdle(speed); 
        this.right_arm.ReturnToIdle(speed); 
        this.left_leg.ReturnToIdle(speed); 
        this.right_leg.ReturnToIdle(speed); 
    }

    private void Jump()
    {
        throw new NotImplementedException();
    }
   
}
