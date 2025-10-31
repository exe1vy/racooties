using System.Collections;
using UnityEngine;

public class fadeInScreen : MonoBehaviour
{

    public Animator fadeScreen;
    public GameObject fadeScreenObject;
    public GameObject battleSystem;
    public battleSystem batSysRef;
    public GameObject connerHPBox;
    public GameObject richardHPBox;
    public GameObject interactionBox;
    public GameObject meleeButton;
    public GameObject magicButton;
    public GameObject healButton;
    public Animator instructionsAnimator;
    public Animator fadeOutAnimator;
    public GameObject fadeOutScreenObject;
    public GameObject instructionBoxObject;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fadeScreenObject.SetActive(true);
        fadeScreen.SetBool("fadeNow", true);
        instructionBoxObject.SetActive(true);
        battleSystem.SetActive(false);
        connerHPBox.SetActive(false);
        richardHPBox.SetActive(false);
        interactionBox.SetActive(false);
        meleeButton.SetActive(false);
        magicButton.SetActive(false);
        healButton.SetActive(false);
        StartCoroutine(setUnactive());
        instructionsAnimator.SetBool("fadeIn", true);

    }

    public IEnumerator setUnactive()
    {
        yield return new WaitForSeconds(1f);
        fadeScreenObject.SetActive(false);
    }

    public void fadeOutGameNow()
    {
        fadeOutScreenObject.SetActive(true);
        fadeOutAnimator.SetBool("outNow", true);
    }

    //public IEnumerator setActive()
    //{
    //    yield return new WaitForSeconds(1f);
    //    fadeScreenObject.SetActive(true);
    //}
}
