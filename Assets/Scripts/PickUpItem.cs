using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public bool taken = false;
    public Item item;
    public bool isKeyitem;
    public int keyItemNumber;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (taken)
        {
            Destroy(this.gameObject);
        }
    }
}
