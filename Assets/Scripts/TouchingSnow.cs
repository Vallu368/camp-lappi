using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingSnow : MonoBehaviour
{
    //https://media.tenor.com/Hp8rb6NrNboAAAAi/cat-nodding.gif
    //touch grass

    
    private PlayerMovement move;

    private void Start()
    {
        move = GetComponentInChildren<PlayerMovement>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == ("Snow"))
        {
            Debug.Log("slow");
            move.inHeavySnow = true;
        }
        if (collision.gameObject.name == "ColdAura")
        {
            Debug.Log("aura");
            move.inFearAura = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.transform.tag == ("Snow"))
        {
            Debug.Log("not slowed");
            move.inHeavySnow = false;
        }

        if (collision.gameObject.name == "ColdAura")
        {
            Debug.Log("left aura");
            move.inFearAura = false;
        }
    }
    
}  

