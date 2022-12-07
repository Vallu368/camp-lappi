using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMashing : MonoBehaviour
{
    public float mashDelay = 1f;
    public float initialMashDelay = 5f;
    public float mash;
    private bool pressed;
    bool started;
    private bool mashing;
    public bool mashingFailed = false;
    public bool hasKnife = false;
    PlayerMotivation motiv;
    InventoryScript inv;    
    
    void Start()
    {
        mash = mashDelay;
        motiv = this.GetComponent<PlayerMotivation>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (started)
        {
            mash -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space) && !pressed)
            {
                pressed = true;
                mash = mashDelay;
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                pressed = false;
            }
            if (mash <= 0.1)
            {
                Debug.Log("mashing failed");
                started = false;
                mashingFailed = true;
                motiv.currentMotivation = 0;
            }
        }
    }
    public void StartButtonMash()
    {
        if (!mashingFailed)
        {

            if (!mashing)
            {
                started = true;
                mash = initialMashDelay;
                mashing = true;
            }
        }

    }
    public void StopButtonMash()
    {
        started = false;
        mashing = false;
        mash = mashDelay;
    }
}
