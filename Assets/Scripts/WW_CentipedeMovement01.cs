using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WW_CentipedeMovement01 : MonoBehaviour
{


    [SerializeField] private float moveSpeed;
    [SerializeField] private float leftMoveSpeed;
    [SerializeField] private float rightMoveSpeed;
    [SerializeField] private float maxMoveSpeed;
    [SerializeField] private float testRotValue;
    [SerializeField] private float newRotValue;
    [SerializeField] private float rotMax;
    [SerializeField] private float decayRate;

    public KeyCode[] leftMoveButton;
    public KeyCode[] rightMoveButton;
    public Vector2 curVol;

    [SerializeField] private bool[] leftSteps;
    [SerializeField] private bool[] rightSteps;

    private void Start()
    {
        leftSteps = new bool[4];
        rightSteps = new bool[4];

        newRotValue = GetComponent<Transform>().rotation.x;
    }

    private void Update()
    {


        leftMoveSpeed = Mathf.Lerp(leftMoveSpeed, 0, Time.deltaTime * decayRate);
        rightMoveSpeed = Mathf.Lerp(rightMoveSpeed, 0, Time.deltaTime * decayRate);

        leftMoveSpeed = Mathf.Clamp(leftMoveSpeed, 0, maxMoveSpeed);
        rightMoveSpeed = Mathf.Clamp(rightMoveSpeed, 0, maxMoveSpeed);
        float combinedMoveSpeed = (leftMoveSpeed + rightMoveSpeed);
        GetComponent<Rigidbody>().velocity += GetComponent<Transform>().forward * combinedMoveSpeed * moveSpeed;


        float tempRatio = Mathf.InverseLerp(0, leftMoveSpeed + rightMoveSpeed, leftMoveSpeed);
        testRotValue = Mathf.Lerp(-rotMax, rotMax, tempRatio);
        Transform trg = GetComponent<Transform>();

        Quaternion currentRotation = trg.rotation;
        if (leftMoveSpeed <= 0.1 && rightMoveSpeed <= 0.1)
        {
            testRotValue = 0f;
            leftMoveSpeed = 0f;
            rightMoveSpeed = 0f;
        }
        newRotValue = Mathf.Lerp(newRotValue, newRotValue + testRotValue, Time.deltaTime);
        Mathf.Clamp(newRotValue, trg.rotation.x - rotMax, trg.rotation.x + rotMax);

        trg.rotation = Quaternion.Euler(currentRotation.eulerAngles.x, newRotValue, currentRotation.eulerAngles.z);


        curVol = GetComponent<Rigidbody>().velocity;



        if (Input.anyKeyDown)
        {
            buttCheck();
        }

    }
    void buttCheck()
    {
        if (Input.GetKeyDown(leftMoveButton[0]))
        {
            print(1);
            if (!leftSteps[0])
            {
                leftMoveSpeed++;
            }
            else if (leftMoveButton.Any(key => Input.GetKey(key)))
            {
                leftMoveSpeed--;
            }
            ResetSteps(leftSteps);
            leftSteps[0] = true;
        }

        if (Input.GetKeyDown(leftMoveButton[1]))
        {
            print(2);
            if (leftSteps[0])
            {
                leftMoveSpeed++;

            }
            else if (leftMoveButton.Any(key => Input.GetKey(key)))
            {
                leftMoveSpeed--;
            }
            ResetSteps(leftSteps);
            leftSteps[1] = true;
        }

        if (Input.GetKeyDown(leftMoveButton[2]))
        {
            print(3);
            if (leftSteps[0] || leftSteps[1])
            {
                leftMoveSpeed++;
            }
            else if (leftMoveButton.Any(key => Input.GetKey(key)))
            {
                leftMoveSpeed--;
            }
            ResetSteps(leftSteps);
            leftSteps[2] = true;
        }

        if (Input.GetKeyDown(leftMoveButton[3]))
        {
            print(4);
            if (leftSteps[1] || leftSteps[2])
            {
                leftMoveSpeed++;
            }
            else if (leftMoveButton.Any(key => Input.GetKey(key)))
            {
                leftMoveSpeed--;
            }
            ResetSteps(leftSteps);
            leftSteps[3] = true;
        }

        if (Input.GetKeyDown(rightMoveButton[0]))
        {
            print(1);
            if (!rightSteps[0])
            {
                rightMoveSpeed++;
            }
            else if (rightMoveButton.Any(key => Input.GetKey(key)))
            {
                rightMoveSpeed--;
            }
            ResetSteps(rightSteps);
            rightSteps[0] = true;
        }

        if (Input.GetKeyDown(rightMoveButton[1]))
        {
            print(2);
            if (rightSteps[0])
            {
                rightMoveSpeed++;

            }
            else if (rightMoveButton.Any(key => Input.GetKey(key)))
            {
                rightMoveSpeed--;
            }
            ResetSteps(rightSteps);
            rightSteps[1] = true;
        }

        if (Input.GetKeyDown(rightMoveButton[2]))
        {
            print(3);
            if (rightSteps[0] || rightSteps[1])
            {
                rightMoveSpeed++;

            }
            else if (rightMoveButton.Any(key => Input.GetKey(key)))
            {
                rightMoveSpeed--;
            }
            ResetSteps(rightSteps);
            rightSteps[2] = true;
        }

        if (Input.GetKeyDown(rightMoveButton[3]))
        {
            print(4);
            if (rightSteps[1] || rightSteps[2])
            {
                rightMoveSpeed++;
            }
            else if (rightMoveButton.Any(key => Input.GetKey(key)))
            {
                rightMoveSpeed--;
            }
            ResetSteps(rightSteps);
            rightSteps[3] = true;
        }
    }

    private void MoveCentipede()
    {
        GetComponent<Rigidbody>().velocity += Vector3.forward * moveSpeed;
        // GetComponent<Rigidbody>().AddForce(Vector3.forward * moveSpeed);
    }

    private void SlowCentipede()
    {
        GetComponent<Rigidbody>().velocity -= Vector3.forward * moveSpeed;
    }

    private void ResetSteps(bool[] steps)
    {
        for (int i = 0; i < steps.Length; i++)
        {
            steps[i] = false;
        }
    }

}