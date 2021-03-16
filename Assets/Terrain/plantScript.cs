using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantScript : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "player")
        {
            Delete();
            var bxcldr = GetComponent<BoxCollider>();
            Destroy(bxcldr);

        }
    }
    IEnumerator Delete()
    {

        yield return new WaitForSeconds(3f);
        

    }

}
