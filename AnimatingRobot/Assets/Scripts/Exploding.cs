using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploding : MonoBehaviour {

    public GameObject explosionEffect;
    public float radius = 5f;
    public float force = 700000f; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp("Fire1"))
        {
            Explode(); 
        }
	}


    void Explode()
    {
        Destroy(Instantiate(explosionEffect, transform.position, transform.rotation), 4);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius); 

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>(); 
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }

        Destroy(gameObject); 
    }
}
