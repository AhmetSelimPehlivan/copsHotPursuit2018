using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTerrain : MonoBehaviour {

    public GameObject stterrain;
    GameObject child;
    public Vector3 offset;
    private bool check;
	void Start () {
         check = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player")
        {
            if (check)
            {
                Vector3 newPos = transform.position + offset;
                child = Instantiate(stterrain, newPos, Quaternion.identity);
                check = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            check = true;
            Destroy(child);
        }
    }
}
