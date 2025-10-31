using UnityEngine;
using UnityEngine.SceneManagement;
public class transitions : MonoBehaviour
{
    public Animator transition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transition.SetBool("fade out", true);
            Invoke("scenechanger", 1f);
        }
    }

    void scenechanger()
    {
        SceneManager.LoadScene("Reveal");
    }
}
