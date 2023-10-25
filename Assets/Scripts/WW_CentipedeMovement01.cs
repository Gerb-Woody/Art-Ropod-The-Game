using UnityEngine;

public class WW_CentipedeMovement01 : MonoBehaviour
{
    //
    //                      THIS SCRIPT STARTED AS AN EDIT OF CAMERON MOORE'S ORIGINAL SCRIPT CREDIT TO THEM
    //                                  THOUGH QUICKLY BECAME MOSTLY A NEW SCRIPT
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;


    public KeyCode[] moveButton;

    [SerializeField] private bool[] steps;

    private void Start()
    {
        steps = new bool[4];
    }

    private void Update()
    {

        if (Input.GetKeyDown(moveButton[0]))
        {
            print(1);
            if (!steps[0])
            {
                MoveCentipede();
            }
            else
            {
                SlowCentipede();
            }
            ResetSteps();
            steps[0] = true;
        }

        if (Input.GetKeyDown(moveButton[1]))
        {
            print(2);
            if (steps[0])
            {
                MoveCentipede();
            }
            else
            {
                SlowCentipede();
            }
            ResetSteps();
            steps[1] = true;
        }

        if (Input.GetKeyDown(moveButton[2]))
        {
            print(3);
            if (steps[0] || steps[1])
            {
                MoveCentipede();
            }
            else
            {
                SlowCentipede();
            }
            ResetSteps();
            steps[2] = true;
        }

        if (Input.GetKeyDown(moveButton[3]))
        {
            print(4);
            if (steps[1] || steps[2])
            {
                MoveCentipede();
            }
            else
            {
                SlowCentipede();
            }
            ResetSteps();
            steps[3] = true;
        }

     /*   else if (!Input.anyKey)
        {
            ResetSteps();
        }*/
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

    private void ResetSteps()
    {
        for (int i = 0; i < steps.Length; i++)
        {
            steps[i] = false;
        }
    }

}