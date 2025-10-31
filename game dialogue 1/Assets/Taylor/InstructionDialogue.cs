using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class InstructionDialogue : MonoBehaviour
{

    public List<string> instructions;
    public TMP_Text instructionText;
    public int instructionCount = 0;
    public Animator instructionAnimator;
    public bool gameStarted = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instructionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void readInstructions()
    {
        if (instructionCount < instructions.Count)
        {
            instructionText.text = instructions[instructionCount];
            instructionCount++;

            return;
        }

        if (instructionCount == instructions.Count)
        {
            instructionAnimator.SetBool("goDefault", false);
            instructionAnimator.SetBool("fadeOut", true);
            instructionCount++;
            gameStarted = true;
        }
    }//it doesnt fade

}
