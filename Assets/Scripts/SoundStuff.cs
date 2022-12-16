using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundStuff : MonoBehaviour
{
    private int nextUpdate = 1;
    public int i;
    public int spookySoundNumber;
    public AudioSource[] spookySounds;
    private bool isPlaying;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextUpdate)
        {

            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            UpdateEverySecond();
        }
        if (i >= 15)
        {
            
            if (!isPlaying)
            {
                StartCoroutine(PlaySound());
            }
        }
    }
    void UpdateEverySecond()
    {
        i++;
    }
    IEnumerator PlaySound()
    {
        isPlaying = true;
        spookySoundNumber = Random.Range(0, spookySounds.Length);
        yield return new WaitForSeconds(1f);
        spookySounds[spookySoundNumber].Play();
        yield return new WaitForSeconds(4f);
        Debug.Log("sus");
        i = 0;
        isPlaying = false;
    }
}
