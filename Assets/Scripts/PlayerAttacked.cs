using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.PlayerLoop.PreLateUpdate;

public class PlayerAttacked : MonoBehaviour
{
    public bool beingAttacked;
    private TextMeshProUGUI text;
    private PlayerMotivation motivation;
    private ButtonMashing mash;
    public int attacked;
    private int nextUpdate = 1;

    void Start()
    {
        text = GameObject.Find("MashText").GetComponent<TextMeshProUGUI>();
        text.enabled = false;
        motivation = GameObject.Find("Player").GetComponent<PlayerMotivation>();
        mash = GameObject.Find("Player").GetComponent<ButtonMashing>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.X))
        {
            beingAttacked = true;
        }
        if (Time.time >= nextUpdate)
        {
    
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            UpdateEverySecond();
        }
        if (beingAttacked)
        {
            mash.StartButtonMash();
            text.enabled = true;
        }
        if (!beingAttacked)
        {
            text.enabled = false;
            mash.StopButtonMash();
        }
        if (attacked >= 5)
        {
            beingAttacked = false;

        }
        if (mash.mashingFailed)
        {
            beingAttacked = false;
        }

        }
    public void UpdateEverySecond()
    {
        if (beingAttacked)
        {
            attacked++;
            motivation.LowerMotivation(5);
        }
    }

}
