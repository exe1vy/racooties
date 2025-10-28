using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class Dial3 : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public Animator another;
    public Animator secondAnother;
    public float textSpeed;
    private int index;
    public Animator End;

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
        if (index is 1)
        {
            another.SetBool("scared", true);
        }
        else
        {
            another.SetBool("scared", false);
        }
        if (index is 0)
        {
            another.SetBool("shocked", true);
        }
        else
        {
            another.SetBool("shocked", false);
        }
        if (index is 2)
        {
            another.SetBool("turned", true);
        }
        else
        {
            another.SetBool("turned", false);
        }
        if (index is 4)
        {
            another.SetBool("wellok", true);
        }
        else
        {
            another.SetBool("wellok", false);
        }
        if (index is 5 or 7 or 9 or 12)
        {
            another.SetBool("minitalk", true);
        }
        else
        {
            another.SetBool("minitalk", false);
        }
        if (index is 6)
        {
            secondAnother.SetBool("go", true);
        }

        if (index is 8)
        {
            secondAnother.SetBool("AHH", true);
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
            //audio
            End.SetBool("finish", true);
            Invoke("END", 2f);
        }
    }

    void END()
    {
        SceneManager.LoadScene("Credits");
    }
}