using UnityEngine;
using TMPro;


public class pickupring : MonoBehaviour

{
    public GameObject rings;
    public TMP_Text yougotit;
    public Animator ring;
    //
    public AudioSource theSauce;
    public AudioClip ringSound;
    public int counter = 0;
    //
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ring.SetBool("picked", true);
            yougotit.text = "You found the Oracle's ring!";
            Invoke("removetext", 1f);
            //
            if (counter == 0)
            {
                theSauce.PlayOneShot(ringSound);
                counter++;
            }
            //
        }
    }


    void removetext()
    {
        yougotit.text = "";
        Destroy(gameObject);
    }
    


}