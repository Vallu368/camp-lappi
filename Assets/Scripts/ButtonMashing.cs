using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMashing : MonoBehaviour
{
    public float mashDelay = 0.5f;
    public float mash;
    private bool pressed;
    bool started;
    void Start()
    {
        mash = mashDelay;
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
            if (mash <= 0)
            {
                Debug.Log("mashing failed");
                started = false;
            }
        }
    }
    public void StartButtonMash()
    {
        started = true;
        Debug.Log("mashing started)");
        mash = mashDelay;

    }
    public void StopButtonMash()
    {
        started = false;
        mash = mashDelay;
    }
}
