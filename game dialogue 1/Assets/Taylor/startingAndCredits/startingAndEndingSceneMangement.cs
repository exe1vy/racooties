using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class startingAndEndingSceneMangement : MonoBehaviour
{
    public GameObject fadeOutScreenStartingScreen;
    public Animator fadeScreenStartAnimator;


    public void Start()
    {
        fadeOutScreenStartingScreen.SetActive(false);
    }

    public void loadBeginningScene()
    {
        fadeOutScreenStartingScreen.SetActive(true);
        fadeScreenStartAnimator.SetBool("fadeNow", true);
        StartCoroutine(waitForOracle());
    }

    public IEnumerator waitForOracle()
    {
        yield return new WaitForSeconds(2.6f);
        print("going now");
        SceneManager.LoadScene("Oracle");
    }

}
