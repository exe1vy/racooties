using UnityEngine;

public class startFadeInBox : MonoBehaviour
{
    public Animator instructionAnimator;
    public GameObject instructionBox;
    public GameObject battleSystemObject;
    public Animator hpmpAnimator;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instructionBox.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startInstructions()

    {
        instructionAnimator.SetBool("fadeIn", true);
    }

    public void setDefault()
    {
        instructionAnimator.SetBool("fadeIn", false);
        instructionAnimator.SetBool("goDefault", true);
    }

    public void startPlay()
    {
        battleSystemObject.SetActive(true);
    }

    public void fadeOutBoxes()
    {
        instructionAnimator.SetBool("goDefault", false);
        instructionAnimator.SetBool("fadeOut", true);
        hpmpAnimator.SetBool("fadeOut", true);
    }
}
