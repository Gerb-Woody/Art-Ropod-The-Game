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
    [SerializeField] private float maxCrawlSpeed;
    [SerializeField] private float upNewRotValue;

    public KeyCode[] leftMoveButton;
    public KeyCode[] rightMoveButton;
    public Vector2 curVol;

    [SerializeField] private bool[] leftSteps;
    [SerializeField] private bool[] rightSteps;
    [SerializeField] private bool climbingWall;



    [SerializeField] float speedMult = .1f;  //Speed multiplier for rescaled character
    private void Start()
    {
        leftSteps = new bool[4];
        rightSteps = new bool[4];

        newRotValue = transform.rotation.y;
        upNewRotValue = transform.rotation.eulerAngles.x;
    }

    private void Update()
    {
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * Mathf.Clamp(GetComponent<Rigidbody>().velocity.magnitude, 0f, maxCrawlSpeed);

        leftMoveSpeed = Mathf.Lerp(leftMoveSpeed, 0, Time.deltaTime * decayRate);
        rightMoveSpeed = Mathf.Lerp(rightMoveSpeed, 0, Time.deltaTime * decayRate);

        leftMoveSpeed = Mathf.Clamp(leftMoveSpeed, 0, maxMoveSpeed);
        rightMoveSpeed = Mathf.Clamp(rightMoveSpeed, 0, maxMoveSpeed);
        float combinedMoveSpeed = (leftMoveSpeed + rightMoveSpeed);
        GetComponent<Rigidbody>().velocity += GetComponent<Transform>().forward * combinedMoveSpeed * moveSpeed;
        combinedMoveSpeed *= speedMult;



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

        if (!climbingWall)
        {
            newRotValue = Mathf.Lerp(newRotValue, newRotValue + testRotValue, Time.deltaTime);
            Mathf.Clamp(newRotValue, trg.rotation.x - rotMax, trg.rotation.x + rotMax);

            trg.localRotation = Quaternion.Euler(currentRotation.eulerAngles.x, newRotValue, currentRotation.eulerAngles.z);
        }
        else if (climbingWall)
        {
            newRotValue = Mathf.Lerp(newRotValue, newRotValue + testRotValue, Time.deltaTime);
            Mathf.Clamp(newRotValue, trg.rotation.z - rotMax, trg.rotation.z + rotMax);
            trg.GetComponent<Rigidbody>().AddForce(0f, 0f, 2f);
           // trg.rotation = Quaternion.Euler( newRotValue, currentRotation.eulerAngles.x, currentRotation.eulerAngles.x);
        }



        /*newRotValue = Mathf.Lerp(newRotValue, newRotValue + testRotValue, Time.deltaTime);
        Mathf.Clamp(newRotValue, trg.rotation.x - rotMax, trg.rotation.x + rotMax);

        trg.localRotation = Quaternion.Euler(currentRotation.eulerAngles.x, newRotValue, currentRotation.eulerAngles.z);*/

        //trg.localRotation *= Quaternion.Euler(0f, newRotValue, 0f);
        /*  Quaternion hopefullyFunctionalTurning = Quaternion.AngleAxis(newRotValue, trg.up);
          trg.rotation = hopefullyFunctionalTurning;*/
        //  trg.Rotate(Vector3.up, newRotValue, Space.Self);

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


    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object tagged as "Wall"
        if (collision.gameObject.CompareTag("Wall"))
        {
            climbingWall = true;
            // Calculate the rotation to align the "Down" direction with the collision normal
            // Quaternion targetRotation = Quaternion.FromToRotation(transform.up, collision.contacts[0].normal) * transform.rotation;
             Quaternion targetRotation = Quaternion.Euler(-90f, 0f, 0f);
            // Apply the rotation to your object
            transform.rotation = targetRotation;
        }
        if (collision.gameObject.CompareTag("Floor"))
        {
            climbingWall = false;
            // Calculate the rotation to align the "Down" direction with the collision normal
            Quaternion targetRotation = Quaternion.FromToRotation(transform.up, collision.contacts[0].normal) * transform.rotation;
            // Apply the rotation to your object
            transform.rotation = targetRotation;
        }
    }

}