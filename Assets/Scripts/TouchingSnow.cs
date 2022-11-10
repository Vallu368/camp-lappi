using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingSnow : MonoBehaviour
{
    public PlayerMovement move;

    private void Start()
    {
        move = GetComponentInChildren<PlayerMovement>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == ("Snow"))
        {
            Debug.Log("slow");
            move.inHeavySnow = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == ("Snow"))
        {
            Debug.Log("not slowed");
            move.inHeavySnow = false;
        }
    }
}

