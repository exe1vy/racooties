using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endingSceneSceneManageAndFade : MonoBehaviour
{
    public GameObject fadeInScreen;
    public GameObject fadeOutScreen;
    public Animator creditsOut;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fadeInScreen.SetActive(true);
        StartCoroutine(waitToDeactivate());
        fadeOutScreen.SetActive(false);
    }

    public IEnumerator waitToDeactivate()
    {
        yield return new WaitForSeconds(1f);
        fadeInScreen.SetActive(false);
    }

    public IEnumerator waitForForest()
    {
        yield return new WaitForSeconds(2.6f);
        print("going now");
        SceneManager.LoadScene("travelScene");
    }

    public IEnumerator waitForStartOver()
    {
        yield return new WaitForSeconds(2.6f);
        print("going now");
        SceneManager.LoadScene("startingScreen");
    }
    public void loadForest()
    {
        fadeOutScreen.SetActive(true);
        creditsOut.SetBool("fadeOut", true);
        StartCoroutine(waitForForest());
    }

    public void loadStartOver()
    {
        fadeOutScreen.SetActive(true);
        creditsOut.SetBool("fadeOut", true);
        StartCoroutine(waitForStartOver());
    }

}
