using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class Dial : MonoBehaviour
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
        if (index is 0 or 4 or 5)
        {
            another.SetBool("worried", true);
        }
        else
        {
            another.SetBool("worried", false);
        }
        if (index is 8 or 9 or 10)
        {
            another.SetBool("ohman", true);
        }
        else
        {
            another.SetBool("ohman", false);
        }
        if (index is 2 or 3 or 6 or 7)
        {
            another.SetBool("normal talk", true);
        }
        else
        {
            another.SetBool("normal talk", false);
        }
        if (index is 11)
        {
            another.SetBool("angry", true);
        }
        else
        {
            another.SetBool("angry", false);
        }

        if (index is 1 or 7 or 10)
        {
            secondAnother.SetBool("shocking", true);
        }
        else
        {
            secondAnother.SetBool("shocking", false);
        }

        if (index is 5)
        {
            secondAnother.SetBool("nerv", true);
        }
        else
        {
            secondAnother.SetBool("nerv", false);
        }

        if (index is 9)
        {
            secondAnother.SetBool("happie", true);
        }
        else
        {
            secondAnother.SetBool("happie", false);
        }

        if (index is 3)
        {
            secondAnother.SetBool("talking", true);
        }
        else
        {
            secondAnother.SetBool("talking", false);
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
        SceneManager.LoadScene("travelScene");
    }
}