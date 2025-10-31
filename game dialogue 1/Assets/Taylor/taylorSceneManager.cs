using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class taylorSceneManager : MonoBehaviour
{
    public void loadWinScene()
    {
        StartCoroutine(delayEnding(0));
        

    }

    public void loadLoseScene()
    {
        StartCoroutine(delayEnding(1));
        
    }

    public IEnumerator delayEnding(int whichOne)
    {
        yield return new WaitForSeconds(3.2f);
        if (whichOne == 0)
        {
            SceneManager.LoadScene("BossWin");
            print("Going to Win Scene Now");
        }
        else if (whichOne == 1)
        {
            print("Going to Lose Scene Now");
            SceneManager.LoadScene("Bosslose");
            
        }
    }
}
