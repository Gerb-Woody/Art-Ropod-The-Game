using System.Collections;
using UnityEngine;

public class ObjectLifetime : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Lifetime());
    }

    private IEnumerator Lifetime()
    {
        int timer = 20;

        while (timer > 0)
        {
            yield return new WaitForSeconds(1f);
            timer--;
        }

        Destroy(gameObject);
    }
}
