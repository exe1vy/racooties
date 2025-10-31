using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class battleHUD : MonoBehaviour
{
    public TMP_Text hpText;
    public TMP_Text mpText;
    public Slider hpSlider;
    public Slider mpSlider;
    public Unit unitRef;

    public void SetHUD(Unit unit)
    {
        hpText.text = unit.currentHP.ToString();
        mpText.text = unit.currentMana.ToString();
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
        mpSlider.minValue = 0;

    }

    public void setHP(int hp)
    {
        hpSlider.value = hp;
        if (hp < 0)
        {
            hpText.text = 0.ToString();
        }
        else
        {
            hpText.text = hp.ToString();
        }
    }

    public void setMP(int mpTax)
    {
        mpSlider.value -= mpTax;
        unitRef.currentMana -= mpTax;
        if (unitRef.currentMana < 20)
        {
            mpText.text = 0.ToString();
            mpSlider.value = 0;
        }
        else
        {
            mpText.text = unitRef.currentMana.ToString();
        }
    }

    public void addHP(int hp)
    {
        unitRef.currentHP += hp;
        hpSlider.value = unitRef.currentHP;
        hpText.text = unitRef.currentHP.ToString();
    }

}
