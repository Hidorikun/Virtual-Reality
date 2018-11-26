using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tidy : MonoBehaviour {

    public float timeout = 20f; 
	// Use this for initialization
	void Start () {
        Destroy(gameObject, timeout); 
	}
	
}
