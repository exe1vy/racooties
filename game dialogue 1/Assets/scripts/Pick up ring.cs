using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Pickupring : MonoBehaviour
{
    public TMP_Text yougotit;
    public Animator ring;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ring.SetBool("gone", true);
            yougotit.text = "You found the Oracle's ring!";
            Invoke("removetext", 1f);
        }
    }

    void removetext()
    {
        yougotit.text = "";
        Destroy(gameObject);
        SceneManager.LoadScene("null");
    }

}
