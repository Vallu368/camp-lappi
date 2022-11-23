using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacked : MonoBehaviour
{
    public bool beingAttacked;
    public PlayerMotivation motivation;
    public ButtonMashing mash;

    void Start()
    {
        motivation = GameObject.Find("Player").GetComponent<PlayerMotivation>();
        mash = GameObject.Find("Player").GetComponent<ButtonMashing>();
    }

    // Update is called once per frame
    void Update()
    {

        }

}
