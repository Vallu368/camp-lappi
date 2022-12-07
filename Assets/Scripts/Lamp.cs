using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public GameObject lampPrefab;
    public GameObject hand;
    void Start()
    {
        hand = this.transform.parent.gameObject;
        Instantiate(lampPrefab, transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = hand.transform.position;
    }
}
