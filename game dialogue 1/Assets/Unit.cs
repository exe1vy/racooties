using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int meleeDamage;
    public int magicDamage;
    public int maxHP;
    public int currentHP;
    public int maxMana;
    public int currentMana;

    public bool takeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
     

}
