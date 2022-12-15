using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public FadeToBlack fade;
    public TextMeshProUGUI text;
    public string introText1;
    public string introText2;
    public string introText3;
    AudioSource spookySound1;
    AudioSource spookySound2;
    void Start()
    {
        sceneLoader = this.gameObject.GetComponent<SceneLoader>();
        fade = this.gameObject.GetComponent<FadeToBlack>();
        text.gameObject.SetActive(false);
        spookySound1 = GameObject.Find("SpookySound1").GetComponent<AudioSource>();
        spookySound2 = GameObject.Find("SpookySound2").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Yee()
    {
        StartCoroutine(StartGame());

    }
    public IEnumerator StartGame()
    {
        StartCoroutine(fade.FadeIn(2f));
        yield return new WaitForSeconds(4f);
        text.gameObject.SetActive(true);
        StartCoroutine(FadeInText(3f, text));
        yield return new WaitForSeconds(4f);
        StartCoroutine(FadeOutText(3f, text));
        yield return new WaitForSeconds(2f);
        spookySound1.Play();
        yield return new WaitForSeconds(5f);
        text.text = introText1;
        StartCoroutine(FadeInText(3f, text));
        yield return new WaitForSeconds(3f);
        StartCoroutine(FadeOutText(3f, text));
        yield return new WaitForSeconds(3f);
        text.text = introText2;
        StartCoroutine(FadeInText(3f, text));
        yield return new WaitForSeconds(4f);
        StartCoroutine(FadeOutText(3f, text));
        yield return new WaitForSeconds(3f);
        spookySound1.Play();
        yield return new WaitForSeconds(5f);
        text.text = introText3;
        StartCoroutine(FadeInText(3f, text));
        yield return new WaitForSeconds(4f);
        StartCoroutine(FadeOutText(3f, text));
        yield return new WaitForSeconds(3f);
        sceneLoader.LoadNextScene();
        

    }
    private IEnumerator FadeInText(float timeSpeed, TextMeshProUGUI text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime * timeSpeed));
            yield return null;
        }
    }
    private IEnumerator FadeOutText(float timeSpeed, TextMeshProUGUI text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime * timeSpeed));
            yield return null;
        }
    }
}
