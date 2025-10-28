using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
//moved enemy code here too
//removed text for hurt cause eh
//moved hurtSound code here, changed enemy collision to a player collision. Makes more sense?
public class christianPlayer : MonoBehaviour
{
    public float speed;
    public AudioSource theSauce;
    public AudioClip hurtSound;
    public float health = 10;
    public Animator connorMovements;
    public Animator hurtAnimator;
    public healthBarChristian hpRef;
    public int ringSwitch;



    // Start is called before the first frame update
    void Start()
    {
        ringSwitch = 0;
        PlayerPrefs.SetInt("ringcollected", ringSwitch);
        PlayerPrefs.Save();
        connorMovements.SetBool("Idle", true);
        hpRef.setStartHP();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
            connorMovements.SetBool("Idle", false);
            connorMovements.SetBool("runUp", true);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
            connorMovements.SetBool("Idle", false);
            connorMovements.SetBool("runDown", true);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
            connorMovements.SetBool("Idle", false);
            connorMovements.SetBool("runLeft", true);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            connorMovements.SetBool("Idle", false);
            connorMovements.SetBool("runRight", true);
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            connorMovements.SetBool("Idle", true);
            connorMovements.SetBool("runUp", false);
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            connorMovements.SetBool("Idle", true);
            connorMovements.SetBool("runDown", false);
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            connorMovements.SetBool("Idle", true);
            connorMovements.SetBool("runLeft", false);
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            connorMovements.SetBool("Idle", true);
            connorMovements.SetBool("runRight", false);

        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            hpRef.setHP(10);
            theSauce.PlayOneShot(hurtSound);
            hurtAnimator.SetBool("startHurt", true);
            StartCoroutine(resetHurt());

        }
    }

    public IEnumerator resetHurt()
    {
        yield return new WaitForSeconds(.5f);
        hurtAnimator.SetBool("startHurt", false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("key"))
        {
            ringSwitch = 1;
            PlayerPrefs.SetInt("ringcollected", ringSwitch);
            PlayerPrefs.Save();
        }
    }

}


