using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWillHitScript : MonoBehaviour
{
    public bool willHitCentipede = true;

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
