using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public float playerHealth = 3f;
    float crashDuration = 0f;

    void Start()
    {
    }

    void Update()
    {
        if (crashDuration >= playerHealth)
        {
            Explode();
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            crashDuration += Time.deltaTime;
        }
    }

    public void Explode()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("GameEnd");
        
    }
}
