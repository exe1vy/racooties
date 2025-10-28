using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class Dial5 : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public Animator another;
    public Animator secondAnother;
    public Animator End;
    public float textSpeed;
    private int index;
    public int ringcollected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialougue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
        if (index is 0 or 1)
        {
            another.SetBool("happyblush", true);
        }
        else
        {
            another.SetBool("happyblush", false);
        }

        if (index is 2 or 3)
        {
            another.SetBool("worried", true);
        }
        else
        {
            another.SetBool("worried", false);
        }
        if (index is 4)
        {
            another.SetBool("happy", true);
        }
        else
        {
            another.SetBool("happy", false);
        }
        if (index is 5 or 6)
        {
            another.SetBool("saved", true);
        }
        else
        {
            another.SetBool("saved", false);
        }

        if (index is 0 or 1 or 2 or 3 or 4)
        {
            secondAnother.SetBool("reveal", true);
            secondAnother.SetBool("angey", true);
        }
        else
        {
            secondAnother.SetBool("angey", false);
        }
        if (index is 5 or 6)
        {
            secondAnother.SetBool("sad", true);
        }
        if (index is 6)
        {
            secondAnother.SetBool("gone", true);
        }

    }
    void StartDialougue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            End.SetBool("finish", true);
            SceneManager.LoadScene("loading");
        }
    }
}