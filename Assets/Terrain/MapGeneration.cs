using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{

    // Objects
    public GameObject[] objects;
    public GameObject mapGenerator;

    // object rate 
    public int obj1;
    public int obj2;
    public int obj3;
    public int obj4;
    public int obj5;
    public int obj6;
    public int obj7;

    //
    public GameObject[] SFObjects;


    //How many divider:
    public int RowsandCowsAmt;


    //Start and Finish :

    private Vector3 MapStartPos;
    private Vector3 CurrentPos;

    //Terrain Width and Height

    private float terrainWidth;

    //Object Amount
    private float objectIncAmt;



   void Start()
    {
        terrainWidth = -(SFObjects[0].transform.position.x - SFObjects[1].transform.position.x);
        objectIncAmt = terrainWidth / RowsandCowsAmt;
        MapStartPos = new Vector3(SFObjects[0].transform.position.x + 3, SFObjects[0].transform.position.y + 1, SFObjects[0].transform.position.z - 3);

        CurrentPos = MapStartPos;

        for (int i = 1; i <= RowsandCowsAmt; i++)
        {
            for (int j = 1; j <= RowsandCowsAmt; j++)
            {
                Spawn(CurrentPos);
                CurrentPos = new Vector3(CurrentPos.x, CurrentPos.y, CurrentPos.z - objectIncAmt);
            }
            CurrentPos = new Vector3(CurrentPos.x + objectIncAmt, CurrentPos.y, MapStartPos.z);
        }

    }

    private void Spawn(Vector3 spawnPosition)
    {
        int a;
        a = Random.Range(0, objects.Length);
        int b = Random.Range(1, 100);

        if (a == 0 && obj1 >= b)
        {         
            GameObject go = Instantiate(objects[a], spawnPosition, Quaternion.Euler(-90, 0, b * 4));
            go.transform.SetParent(mapGenerator.transform);
        }
        else if (a == 1 && obj2 >= b)
        {
            GameObject go = Instantiate(objects[a], spawnPosition, Quaternion.Euler(-90, 0, b * 6));
            go.transform.SetParent(mapGenerator.transform);
        }
        else if (a == 2 && obj3 >= b)
        {
            GameObject go = Instantiate(objects[a], spawnPosition, Quaternion.Euler(-90, 0, b * 4));
            go.transform.SetParent(mapGenerator.transform);
        }
        else if (a == 3 && obj4 >= b)
        {
            GameObject go = Instantiate(objects[a], spawnPosition, Quaternion.Euler(0, 0, 0));
            go.transform.SetParent(mapGenerator.transform);     
        }
        else if (a == 4 && obj4 >= b && objects.Length > 4)
        {
            GameObject go = Instantiate(objects[a], spawnPosition, Quaternion.Euler(-90, 0, b * 4));
            go.transform.SetParent(mapGenerator.transform);      
        }
        else if (a == 5 && obj4 >= b && objects.Length > 5)
        {
            GameObject go = Instantiate(objects[a], spawnPosition, Quaternion.Euler(-90, 0, b * 4));
            go.transform.parent = this.transform;
        }
        else if (a == 6 && obj4 >= b && objects.Length > 6)
        {
            GameObject go = Instantiate(objects[a], spawnPosition, Quaternion.Euler(-90, 0, b * 4));
            go.transform.parent = this.transform;
        }
    }
}
