using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class Dial6 : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public Animator another;
    public Animator secondAnother;
    public Animator End;
    public float textSpeed;
    private int index;

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


        if (index is 0 or 2 or 9)
        {
            another.SetBool("talking", true);
        }
        else
        {
            another.SetBool("talking", false);
        }
        if (index is 4 or 6 or 11 or 12 or 13 or 14 or 15 or 16 or 17 or 18 or 22 or 23 or 24 or 25)
        {
            another.SetBool("bloosh", true);
        }
        else
        {
            another.SetBool("bloosh", false);
        }
        if (index is 19)
        {
            another.SetBool("running", true);
        }
        else
        {
            another.SetBool("running", false);
        }
        if (index is 20)
        {
            another.SetBool("coming", true);
        }
        else
        {
            another.SetBool("coming", false);
        }



        if (index is 1 or 8 or 9)
        {
            secondAnother.SetBool("talking", true);
        }
        else
        {
            secondAnother.SetBool("talking", false);
        }
        if (index is 2 or 3 or 4 or 6 or 7 or 10 or 14 or 15 or 18 or 24 or 26)
        {
            secondAnother.SetBool("nerv", true);
        }
        else
        {
            secondAnother.SetBool("nerv", false);
        }
        if (index is 5 or 23)
        {
            secondAnother.SetBool("shocking", true);
        }
        else
        {
            secondAnother.SetBool("shocking", false);
        }
        if (index is 11 or 12 or 13 or 16 or 17 or 25)
        {
            secondAnother.SetBool("blush", true);
        }
        else
        {
            secondAnother.SetBool("blush", false);
        }
        if (index is 19 or 20)
        {
            secondAnother.SetBool("shyrun", true);
        }
        else
        {
            secondAnother.SetBool("shyrun", false);
        }
        if (index is 21 or 22)
        {
            secondAnother.SetBool("yeshun", true);
        }
        else
        {
            secondAnother.SetBool("yeshun", false);
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