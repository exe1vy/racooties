using UnityEngine;
using UnityEngine.SceneManagement;
public class decider : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("sceneloader", 3f);
    }
    

    void sceneloader ()
    {
        int ring = PlayerPrefs.GetInt("ringcollected", 0);
        
        if (ring is 1)
        {
            SceneManager.LoadScene("Secret ending");
        }
        else
        {
            SceneManager.LoadScene("Credits");
        }
    }
}