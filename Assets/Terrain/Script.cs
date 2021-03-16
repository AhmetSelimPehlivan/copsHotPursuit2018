using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour {

    Rigidbody rigidbodychar;


    public float axisx;
    public float axisy;

	void Start () {
        rigidbodychar = GetComponent<Rigidbody>();
        rigidbodychar.freezeRotation = true;
    }
	
	void FixedUpdate () {
        yurume();
        rigidbodychar.velocity= new Vector3(axisx,rigidbodychar.velocity.y,axisy);
       
	}
     void yurume()  
    {
        axisy = 20*Input.GetAxisRaw("Horizontal"); 
        axisx = -20*Input.GetAxisRaw("Vertical");
    }

}