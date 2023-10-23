
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    [Header("Child Positions")]
    public Transform oneEnd;
    public Transform otherEnd;

    [Header("Objects to Summon")]
    public GameObject[] randomObstacles;

    //Vector3 spawnPos = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        BeginSpawning();
    }

    public void BeginSpawning()
    {
        InvokeRepeating("ObjectSummoner", 0f, 9f);
    }

    public void StopSpawning()
    {

    }


    // Update is called once per frame
    void ObjectSummoner()
    {
        Instantiate(ObjectChooser(), ChoosePos(), Quaternion.identity);
        print("Wow this location sure is " + ChoosePos());
    }

    Vector3 ChoosePos()
    {
        return Vector3.Lerp(oneEnd.position, otherEnd.position, Random.value);
    }

    GameObject ObjectChooser()
    {
        return randomObstacles[Random.Range(0, randomObstacles.Length)];
    }
}
