using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingFinal : MonoBehaviour
{
    public FadeToBlack fade;
    public SceneLoader scene;
    void Start()
    {
        fade = GameObject.Find("Canvas").GetComponent<FadeToBlack>();
        StartCoroutine(Fuck());
        scene = GameObject.Find("Canvas").GetComponent<SceneLoader>();
        
    }

    IEnumerator Fuck()
    {
        
        yield return new WaitForSeconds(5f);
        StartCoroutine(fade.FadeIn(5f));
        yield return new WaitForSeconds(5f);
        scene.ReturnToMenu();
    }
}
