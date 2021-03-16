using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCrash : MonoBehaviour
{
    public float eDestroyTime = 0.5f;
    public float pDestroyTime = 1f;

    float enemyCrashDuration;
    float playerCrashDuration;
    float timeMultiplier = 1.0f;

    [System.Serializable]
    public class DropItem
    {
        public string name;
        public GameObject item;
        public int dropRarity;
    }
    public List<DropItem> DropBox = new List<DropItem>();
    public int dropChance;
    Vector3 dropPos;

    GameObject explosionEffect;
    public List<GameObject> explosions;
    public float blastRadius = 5f;
    public float explosionForce = 3f;

    void Update()
    {
        dropPos = transform.position;
        if (enemyCrashDuration >= eDestroyTime )
        {            
            Explode();
        }

        if (playerCrashDuration >= pDestroyTime )
        {
            Explode();
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyCrashDuration += timeMultiplier * Time.deltaTime;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            playerCrashDuration += timeMultiplier * Time.deltaTime;
        }
    }
    
    void Explode()
    {
        int randomValue = Random.Range(0, explosions.Count);
        explosionEffect = explosions[randomValue];

        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponentInParent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, blastRadius);
            }
        }
        Destroy(gameObject);
        calculateLoot(true);
    }

    public void calculateLoot(bool value)
    {
        int calc_dropChance = Random.Range(0, 101);

        if (calc_dropChance > dropChance)
        {
            return;
        }

        if (calc_dropChance <= dropChance)
        {
            int itemWeight = 0;

            for (int i = 0; i < DropBox.Count; i++)
            {
                itemWeight += DropBox[i].dropRarity;
            }

            int randomValue = Random.Range(0, itemWeight);

            for (int j = 0; j < DropBox.Count; j++)
            {
                if (randomValue <= DropBox[j].dropRarity)
                {
                    Instantiate(DropBox[j].item, dropPos, Quaternion.identity);
                    return;
                }
                randomValue -= DropBox[j].dropRarity;
            }
        }
    }
}
