using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float timeDestroy = 2f;

    void Start()
    {
        Destroy(gameObject, timeDestroy);
    }

    private void OnMouseDown()
    {
        if (gameObject.CompareTag("Good"))
        {
            Destroy(gameObject);
        }else if (gameObject.CompareTag("Bad"))
        {

        }
    }
}
