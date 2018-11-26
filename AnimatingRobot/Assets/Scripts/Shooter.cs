using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public Rigidbody projectile;
    public GameObject cannonHead; 
    public Transform shotPosition;
    public float shotForce = 40000f;
    public float moveSpeed = 20f;
    public GameObject muzzleFlash; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float v = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        cannonHead.transform.Rotate(v, h, 0);

        if (Input.GetButtonUp("Jump"))
        {
            Rigidbody shot = Instantiate(projectile, shotPosition.position, shotPosition.rotation) as Rigidbody;
            Destroy(Instantiate(muzzleFlash, shotPosition.position, shotPosition.rotation), 1);
            shot.AddForce(shotPosition.forward * shotForce); 
        }
	}
}
