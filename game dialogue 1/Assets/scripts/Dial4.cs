using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class Dial4 : MonoBehaviour
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
        secondAnother.SetBool("reveal", true);
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
        if (index is 2 or 3)
        {
            another.SetBool("turned", true);
        }
        else
        {
            another.SetBool("turned", false);
        }
        if (index is 0)
        {
            secondAnother.SetBool("reveal", true);
        }
        else
        {
            secondAnother.SetBool("reveal", false);
        }
        if (index is 3)
        {
            secondAnother.SetBool("angey", true);
        }
        else
        {
            secondAnother.SetBool("angey", false);
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