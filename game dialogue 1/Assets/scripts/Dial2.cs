using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class Dial2 : MonoBehaviour
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
        if (index is 0)
        {
            another.SetBool("happy", true);
        }
        else
        {
            another.SetBool("happy", false);
        }
        if (index is 1 or 2 or 3 or 4 or 5 or 9 or 10 or 11 or 19 or 20)
        {
            another.SetBool("worried", true);
        }
        else
        {
            another.SetBool("worried", false);
        }
        if (index is 6 or 7 or 8 or 12 or 13 or 17 or 18)
        {
            another.SetBool("shocked", true);
        }
        else
        {
            another.SetBool("shocked", false);
        }
        if (index is 14 or 15 or 16 or 21)
        {
            another.SetBool("scared", true);
        }
        else
        {
            another.SetBool("scared", false);
        }
        if (index is 22)
        {
            another.SetBool("angry", true);
        }
        else
        {
            another.SetBool("angry", false);
        }
        if (index is 23)
        {
            another.SetBool("ohman", true);
        }
        else
        {
            another.SetBool("ohman", false);
        }



        if (index is 2 or 4)
        {
            secondAnother.SetBool("mysterytalk", true);
        }
        else
        {
            secondAnother.SetBool("mysterytalk", false);
        }
        if (index is 6)
        {
            secondAnother.SetBool("reveal", true);
        }
        if (index is 8 or 9 or 10 or 11 or 17)
        {
            secondAnother.SetBool("angey", true);
        }
        else
        {
            secondAnother.SetBool("angey", false);
        }
        if (index is 15 or 20)
        {
            secondAnother.SetBool("sad", true);
        }
        else
        {
            secondAnother.SetBool("sad", false);
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
        SceneManager.LoadScene("bossBattle");
    }
}