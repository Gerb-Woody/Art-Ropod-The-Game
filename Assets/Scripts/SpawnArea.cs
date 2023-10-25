
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{


    [Header("Launch Constraints")]
    public float launchPower = 1.0f;
    public float launchFrequency = 3.0f;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minZ;
    public float maxZ;

    [Header("Objects to Summon")]
    public GameObject[] randomObstacles;

    [Header("Interactive Child Components")]
    public Transform oneEnd;
    public Transform otherEnd;
    public BoxCollider startZone;
    public BoxCollider stopZone;

    //Vector3 spawnPos = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        BeginSpawning();
    }

    public void BeginSpawning()
    {
        InvokeRepeating("ObjectSummoner", 0f, launchFrequency);
    }

    public void StopSpawning()
    {

    }


    // Update is called once per frame
    void ObjectSummoner()
    {
        GameObject newestGuy = Instantiate(ObjectChooser(), ChoosePos(), RandomRotator());
        newestGuy.GetComponent<Rigidbody>().velocity = newestGuy.transform.forward * launchPower;
    }

    Vector3 ChoosePos()
    {
        return Vector3.Lerp(oneEnd.position, otherEnd.position, UnityEngine.Random.value);
    }

    GameObject ObjectChooser()
    {
        return randomObstacles[UnityEngine.Random.Range(0, randomObstacles.Length)];
    }

    Quaternion RandomRotator()
    {
        float rotX = UnityEngine.Random.Range(minX, maxX);
        float rotY = UnityEngine.Random.Range(minY, maxY);
        float rotZ = UnityEngine.Random.Range(minZ, maxZ);
        return new Quaternion(rotX, rotY, rotZ, 0f);
    }
}
