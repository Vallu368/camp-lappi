using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndingAndStart : MonoBehaviour
{
    public FadeToBlack fade;
    public InventoryScript inv;
    public SceneLoader sceneLoader;
    bool sus;
    bool test;
    public string startText;
    public string endText;
    TextMeshProUGUI playerSpeech;
    void Awake()
    {
        sceneLoader = GameObject.Find("Canvas").GetComponent<SceneLoader>();
        fade = GameObject.Find("Canvas").GetComponent<FadeToBlack>();
        inv = GameObject.Find("Canvas").GetComponent<InventoryScript>();
        playerSpeech = GameObject.Find("PlayerSpeech").GetComponent<TextMeshProUGUI>();
        
        


    }

    // Update is called once per frame
    void Update()
    {
        if (!sus)
        {
            StartCoroutine(GameStart());
            
        }
        if (inv.keyItemsUsed == 8)
        {
            if (!test)
            {
                StartCoroutine(GameEnd());
            }
        }

    }
     IEnumerator GameStart()
    {
        inv.running = true;
        sus = true;
        StartCoroutine(fade.FadeIn(1f));
        yield return new WaitForSeconds(1f);
        StartCoroutine(fade.FadeOut(5f));
        yield return new WaitForSeconds(3f);
        playerSpeech.text = startText;
        playerSpeech.gameObject.SetActive(true);
        yield return new WaitForSeconds(6f);
        playerSpeech.gameObject.SetActive(false);
        inv.running = false;

    }

    IEnumerator GameEnd()
    {
        test = true;
        inv.running = true;
        playerSpeech.text = endText;
        playerSpeech.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        playerSpeech.gameObject.SetActive(false);
        StartCoroutine(fade.FadeIn(4f));
        yield return new WaitForSeconds(4f);
        sceneLoader.LoadNextScene();




    }

}
