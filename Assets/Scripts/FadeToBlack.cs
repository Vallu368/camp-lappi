using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    public GameObject blackScreen;
    float fadeRate; //how fast the black screen fades in and out
    private float targetAlpha; //1 = blackscreen visible 0 = blackscreen not visible
    // Start is called before the first frame update
    void Start()
    {
        blackScreen = GameObject.Find("BlackScreen");
        blackScreen.SetActive(false);
    }
    private void Update()
    {

    }

    public IEnumerator FadeIn(float fade)
    {
        fadeRate = fade;
        blackScreen.SetActive(true);
        targetAlpha = 1.0f;
        Color curColor = blackScreen.GetComponent<Image>().color;
        while (Mathf.Abs(curColor.a - targetAlpha) > 0.0001f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, fadeRate * Time.deltaTime);
            blackScreen.GetComponent<Image>().color = curColor;

            yield return null;
        }
        yield return new WaitForSeconds(2f);
    
    }
    public IEnumerator FadeOut(float fade)
    {
        fadeRate = fade;
        blackScreen.SetActive(true);
        targetAlpha = 0f;
        Color curColor = blackScreen.GetComponent<Image>().color;
        while (Mathf.Abs(curColor.a - targetAlpha) > 0.0001f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, fadeRate * Time.deltaTime);
            blackScreen.GetComponent<Image>().color = curColor;

            yield return null;
        }

        blackScreen.SetActive(false);

    }

}
