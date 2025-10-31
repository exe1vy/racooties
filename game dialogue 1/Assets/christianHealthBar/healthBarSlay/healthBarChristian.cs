using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class healthBarChristian : MonoBehaviour
{
    public TMP_Text hpText;
    public Slider hpSlider;
    public christianUnitScript unitRef;

    void Start()
    {
        setStartHP();
    }

    public void setStartHP()
    {
        // GameObject connerGameObject = connerRef;
        // connerUnit = connerGameObject.GetComponent<christianUnitScript>();


        // hpText.text = connerUnit.currentHP.ToString();
        // hpSlider.maxValue = connerUnit.maxHP;
        // hpSlider.value = connerUnit.currentHP;

        hpSlider.maxValue = unitRef.maxHP;
        hpSlider.value = unitRef.currentHP;
        hpText.text = unitRef.currentHP.ToString();

    }

    public void setHP(int hp)
    {
        unitRef.currentHP -= hp;
        hpSlider.value = unitRef.currentHP;
        print(unitRef.currentHP);
        hpText.text = unitRef.currentHP.ToString();

        if (unitRef.currentHP == 0)
        {
            SceneManager.LoadScene("ForestLose");
        }


        // if (hpSlider.value == 0)
        // {
        //     print("I DIED");
        // }
    }
}
