using System.Collections;
using TMPro;
using UnityEngine;

public enum battleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class battleSystem : MonoBehaviour
{
    public battleState state;
    public GameObject richard;
    public GameObject conner;
    public GameObject meleeButton;
    public GameObject magicButton;
    public GameObject healButton;

    public Transform connerSpawn;
    public Transform richardSpawn;
    public GameObject connerHPBox;
    public GameObject richardHPBox;
    public GameObject interactionBox;
    public fadeInScreen screenRef;
    public taylorSceneManager sceneManagerRef;

    public battleHUD connerHUD;
    public battleHUD richardHUD;

    public soundsPlay soundsRef;

    public Animator connerAnimator;
    public Animator richardAnimator;

    public GameObject fadeInScreenObject;
    public Animator fadeScreenAnimator;

    public bool meleeButtonCanBeClicked = true;
    public bool magicButtonCanBeClicked = true;
    public bool healButtonCanBeClicked = true;

    bool connerAttackSuccessful = false;
    bool connerCritHitMelee = false;
    bool richardAttackSuccessful = false;

    Unit connerUnit;
    Unit richardUnit;

    public TMP_Text descBoxText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state=battleState.START;
        StartCoroutine(setupBattle());
    }

    IEnumerator setupBattle()
    {
        interactionBox.SetActive(true);
        connerHPBox.SetActive(true);
        richardHPBox.SetActive(true);

        GameObject connerGO = conner;
        connerUnit=connerGO.GetComponentInParent<Unit>();

        GameObject richardGO = richard;
        richardUnit=richardGO.GetComponentInParent<Unit>();

        descBoxText.text = "The battle begins...";
        //start playing battle music==============================
        soundsRef.stopStartMusic();
        yield return new WaitForSeconds(.3f);
        soundsRef.playBattleNoise();
        connerHUD.SetHUD(connerUnit);
        richardHUD.SetHUD(richardUnit);

        yield return new WaitForSeconds(3f);

        state = battleState.PLAYERTURN;
        connerTurn();

    }

    void connerTurn()
    {
        descBoxText.text = "It's " + connerUnit.unitName + "'s turn. What should he do?";
        meleeButton.SetActive(true);
        if (connerUnit.currentMana >= 20)
        {
            magicButton.SetActive(true);
            healButton.SetActive(true);
        }

    }

    public void genRichardAction()
    {
        int genAction = Random.Range(0, 4);
        if (genAction == 0 || genAction == 1)
        {
            print("Richard melee");
            StartCoroutine(richardMeleeTurn());
        }
        else
        {
            print("Richard magic");
            StartCoroutine(richardMagicTurn());
        }
    }

    public IEnumerator connerMelee()
    {
        //choice made
        descBoxText.text = "Conner melee attacks!";
        //animation plays
        connerAnimator.SetBool("meleeNow", true);
        yield return new WaitForSeconds(.5f);
        soundsRef.playMeleeHitNoise();
        yield return new WaitForSeconds(1);
        connerAnimator.SetBool("meleeNow", false);



        //probability system here
        int connerProbSuccess = Random.Range(0, 8);
        //print("prob # is: "+probSuccess);

        if (connerProbSuccess == 0 || connerProbSuccess == 1 || connerProbSuccess == 2 || connerProbSuccess == 3 || connerProbSuccess == 4)
        {
            print("Attack successful!");
            connerAttackSuccessful = true;
            
        }
        else if (connerProbSuccess == 5)
        {
            connerCritHitMelee = true;
            print("CRITICAL HIT!");
        }
        else
        {
            print("Attack failed!");
            connerAttackSuccessful = false;

        }
        yield return new WaitForSeconds(1);

        if (connerCritHitMelee == true)
        {
            descBoxText.text = "Critical Hit! Conner's attack has more damage!";
            //play hurt anim richard
            soundsRef.playConnerCritHitNoise();
            richardAnimator.SetBool("hurtNow", true);
            yield return new WaitForSeconds(1f);
            soundsRef.playHurtNoise();
            yield return new WaitForSeconds(.5f);
            richardAnimator.SetBool("hurtNow", false);
            bool isDead = richardUnit.takeDamage(connerUnit.meleeDamage + 10);
            richardHUD.setHP(richardUnit.currentHP);
            //check if the enemy is dead
            if (isDead)
            {
                //end battle
                state = battleState.WON;
                endBattle();
            }
            else
            {
                //enemy turn
                state = battleState.ENEMYTURN;
                yield return new WaitForSeconds(2f);
                //also choose which turn here /===========================
                genRichardAction();
            }
            //change state based on what happened
        }
        else if (connerAttackSuccessful == true)
        {
            descBoxText.text = "The attack was successful!";
            //play hurt anim richard
            soundsRef.playHurtNoise();
            richardAnimator.SetBool("hurtNow", true);
            yield return new WaitForSeconds(1.2f);
            richardAnimator.SetBool("hurtNow", false);
            bool isDead = richardUnit.takeDamage(connerUnit.meleeDamage);
            richardHUD.setHP(richardUnit.currentHP);
            //check if the enemy is dead
            if (isDead)
            {
                //end battle
                state = battleState.WON;
                endBattle();
            }
            else
            {
                //enemy turn
                state = battleState.ENEMYTURN;
                yield return new WaitForSeconds(2f);
                //also choose which turn here /===========================
                genRichardAction();


            }
            //change state based on what happened
        }
        else
        {
            bool isDead = richardUnit.takeDamage(0);
            richardHUD.setHP(richardUnit.currentHP);
            descBoxText.text = "Conner missed :(";
            soundsRef.playFailHitNoise();
            //check if the enemy is dead
            if (isDead)
            {
                //end battle
                state = battleState.WON;
                endBattle();
            }
            else
            {
                //enemy turn
                state = battleState.ENEMYTURN;
                yield return new WaitForSeconds(2f);
                //choose which richard turn to do HERE =======================
                genRichardAction();
            }
            //change state based on what happened
            connerAttackSuccessful = false;
            connerCritHitMelee = false;
        }


    }

    public IEnumerator richardMeleeTurn()
    {
        meleeButton.SetActive(false);
        magicButton.SetActive(false);
        healButton.SetActive(false);
        descBoxText.text = "It's Richards turn!";
        yield return new WaitForSeconds(2f);
        descBoxText.text = richardUnit.unitName + " melee attacks!";
        richardAnimator.SetBool("meleeNow", true);
        yield return new WaitForSeconds(.5f);
        soundsRef.playMeleeHitNoise();
        yield return new WaitForSeconds(1f);
        richardAnimator.SetBool("meleeNow", false);
        
        //melee attack
        int richardProbSuccess = Random.Range(0, 6); //add another to this if too OP
        //print("prob # is: "+probSuccess);

        if (richardProbSuccess == 0 || richardProbSuccess == 1 || richardProbSuccess == 2 || richardProbSuccess == 3 || richardProbSuccess == 4)
        {
            print("Attack successful!");
            richardAttackSuccessful = true;

        }
        else
        {
            print("Attack failed!");
            richardAttackSuccessful = false;

        }
        yield return new WaitForSeconds(1f);

        if (richardAttackSuccessful)
        {
            //play hurt conner anim
            connerAnimator.SetBool("hurtNow", true);
            descBoxText.text = "Richard hit!";
            soundsRef.playHurtNoise();
            yield return new WaitForSeconds(1.2f);
            connerAnimator.SetBool("hurtNow", false);
            bool isDead = connerUnit.takeDamage(richardUnit.meleeDamage);
            connerHUD.setHP(connerUnit.currentHP);
            //check if conner is dead
            if (isDead)
            {
                state = battleState.LOST;
                endBattle();
            }
            else
            {
                state = battleState.PLAYERTURN;
                yield return new WaitForSeconds(2f);
                connerTurn();
            }

        }
        else
        {
            bool isDead = connerUnit.takeDamage(0);
            connerHUD.setHP(connerUnit.currentHP);
            descBoxText.text = "Richard missed!";
            soundsRef.playFailHitNoise();
            if (isDead)
            {
                state = battleState.LOST;
                endBattle();
            }
            else
            {
                state = battleState.PLAYERTURN;
                yield return new WaitForSeconds(2f);
                connerTurn();
            }
        }
        richardAttackSuccessful = false;
    }

    public IEnumerator richardMagicTurn()
    {
        meleeButton.SetActive(false);
        magicButton.SetActive(false);
        healButton.SetActive(false);
        descBoxText.text = "It's Richards turn!";
        yield return new WaitForSeconds(2f);
        descBoxText.text = richardUnit.unitName + " attempts a magic attack!";
        richardAnimator.SetBool("magicNow", true);
        yield return new WaitForSeconds(1f);
        soundsRef.playRichardMagicNoise();
        yield return new WaitForSeconds(.5f);
        richardAnimator.SetBool("magicNow", false);

        //melee attack
        int richardProbSuccess = Random.Range(0, 8);

        if (richardProbSuccess == 0 || richardProbSuccess == 1 || richardProbSuccess == 2 || richardProbSuccess == 3)
        {
            print("magic Attack successful!");
            richardAttackSuccessful = true;

        }
        else
        {
            print("magic Attack failed!");
            richardAttackSuccessful = false;

        }
        yield return new WaitForSeconds(1f);

        if (richardAttackSuccessful==true)
        {
            //play hurt conner anim
            connerAnimator.SetBool("hurtNow", true);
            descBoxText.text = "Richard hit! Extra damage applied!";
            soundsRef.playHurtNoise();
            yield return new WaitForSeconds(1.2f);
            connerAnimator.SetBool("hurtNow", false);
            bool isDead = connerUnit.takeDamage(richardUnit.magicDamage);
            connerHUD.setHP(connerUnit.currentHP);
            //check if conner is dead
            if (isDead)
            {
                state = battleState.LOST;
                endBattle();
            }
            else
            {
                state = battleState.PLAYERTURN;
                yield return new WaitForSeconds(2f);
                connerTurn(); //skips back to richards turn?
            }

        }
        else
        {
            bool isDead = connerUnit.takeDamage(0);
            connerHUD.setHP(connerUnit.currentHP);
            descBoxText.text = "Richard missed!";
            soundsRef.playFailHitNoise();
            if (isDead)
            {
                state = battleState.LOST;
                endBattle();
            }
            else
            {
                state = battleState.PLAYERTURN;
                yield return new WaitForSeconds(2f);
                connerTurn();
            }
        }
        richardAttackSuccessful = false;
    }

    public void endBattle()
    {
        if (state == battleState.WON)
        {
            meleeButton.SetActive(false);
            magicButton.SetActive(false);
            healButton.SetActive(false);
            descBoxText.text = "Hooray! Conner triumphs!";
            soundsRef.playConnerHealNoise();
            screenRef.fadeOutGameNow();
            //SCENE MANAGER FUNCTION TO SEND TO OTHER SCENE
            sceneManagerRef.loadWinScene();

        }
        else if (state == battleState.LOST)
        {
            meleeButton.SetActive(false);
            magicButton.SetActive(false);
            healButton.SetActive(false);
            descBoxText.text = "OH NO! Conner's been defeated!";
            soundsRef.playHurtNoise();
            screenRef.fadeOutGameNow();
            //SCENE MANAGER FUNCTION TO SEND TO OTHER SCENE
            sceneManagerRef.loadLoseScene();
        }
    }


    public void onMeleeButton()
    {
        if (state != battleState.PLAYERTURN)
        {
            return;
        }
        
        if (meleeButtonCanBeClicked)
        {
            StartCoroutine(connerMelee());
            StartCoroutine(noSpamMelee());
        }
        

    }

    public void onMagicButton()
    {
        if (state != battleState.PLAYERTURN)
        {
            return;
        }
        
        if (magicButtonCanBeClicked)
        {
            StartCoroutine(connerMagic());
            StartCoroutine(noSpamMagic());
        }
            
    }

    public void onHealButton()
    {
        if (state != battleState.PLAYERTURN)
        {
            return;
        }

        if (healButtonCanBeClicked)
        {
            if (connerUnit.currentHP <= 80)
            {
                StartCoroutine(connerHeal());
                StartCoroutine(noSpamHeal());
            }
            else
            {
                descBoxText.text = "You can't heal, you're at max health silly!";
            }
        }
        
    }

    public IEnumerator noSpamMelee()
    {
        meleeButtonCanBeClicked = false;
        yield return new WaitForSeconds(6.5f);
        meleeButtonCanBeClicked = true;
    }

    public IEnumerator noSpamMagic()
    {
        magicButtonCanBeClicked = false;
        yield return new WaitForSeconds(6.5f);
        magicButtonCanBeClicked = true;
    }

    public IEnumerator noSpamHeal()
    {
        healButtonCanBeClicked = false;
        yield return new WaitForSeconds(6.5f);
        healButtonCanBeClicked = true;
    }

    ///=================================

    public IEnumerator connerHeal()
    {
        //choice made
        descBoxText.text = "Conner Heals!";
        //animation plays
        connerAnimator.SetBool("magicNow", true);
        soundsRef.playConnerHealNoise();
        yield return new WaitForSeconds(1f);
        connerAnimator.SetBool("magicNow", false);

        yield return new WaitForSeconds(.5f);

        if (connerUnit.currentHP > 65)
        {
            int randSmallHealAmount = Random.Range(20, 31);
            print("small HEAL");

            descBoxText.text = ("Conner healed by " + randSmallHealAmount.ToString() + " points!");
            bool isDead = richardUnit.takeDamage(0);
            //richardHUD.setHP(richardUnit.currentHP);
            connerHUD.setMP(connerUnit.magicDamage);
            connerHUD.addHP(randSmallHealAmount);
            //check if the enemy is dead
            if (isDead)
            {
                //end battle
                state = battleState.WON;
                endBattle();
            }
            else
            {
                //enemy turn
                state = battleState.ENEMYTURN;
                yield return new WaitForSeconds(3f);
                //also choose which turn here /===========================
                genRichardAction();
            }
        }else if (connerUnit.currentHP < 65)
        {
            int randLargeHealAmount = Random.Range(30, 45);
            print("LARGE HEAL");

            descBoxText.text = ("Conner healed by " + randLargeHealAmount.ToString() + " points!");
            bool isDead = richardUnit.takeDamage(0);
            //richardHUD.setHP(richardUnit.currentHP);
            connerHUD.setMP(connerUnit.magicDamage);
            connerHUD.addHP(randLargeHealAmount);
            //check if the enemy is dead
            if (isDead)
            {
                //end battle
                state = battleState.WON;
                endBattle();
            }
            else
            {
                //enemy turn
                state = battleState.ENEMYTURN;
                yield return new WaitForSeconds(3f);
                //also choose which turn here /===========================
                genRichardAction();
            }
        }

        
    }


    ///==========================================

    public IEnumerator connerMagic()
    {
        //choice made
        descBoxText.text = "Conner attempts a magic attack!";
        //animation plays
        connerAnimator.SetBool("magicNow", true);
        yield return new WaitForSeconds(.5f);
        soundsRef.playConnerMagicHitNoise();
        yield return new WaitForSeconds(1);
        connerAnimator.SetBool("magicNow", false);

        //probability system here
        int connerProbSuccess = Random.Range(0, 6);
        //print("prob # is: "+probSuccess);

        if (connerProbSuccess == 0 || connerProbSuccess == 1 || connerProbSuccess == 2 || connerProbSuccess == 3)
        {
            print("Attack successful!");
            connerAttackSuccessful = true;

        }
        else
        {
            print("Attack failed!");
            connerAttackSuccessful = false;

        }
        yield return new WaitForSeconds(1f);

        if (connerAttackSuccessful == true)
        {
            descBoxText.text = "The attack was successful! Extra damage applied!";
            //play hurt anim richard
            richardAnimator.SetBool("hurtNow", true);
            soundsRef.playHurtNoise();
            yield return new WaitForSeconds(1.2f);
            richardAnimator.SetBool("hurtNow", false);
            bool isDead = richardUnit.takeDamage(connerUnit.magicDamage);
            richardHUD.setHP(richardUnit.currentHP);
            connerHUD.setMP(connerUnit.magicDamage);
            //check if the enemy is dead
            if (isDead)
            {
                //end battle
                state = battleState.WON;
                endBattle();
            }
            else
            {
                //enemy turn
                state = battleState.ENEMYTURN;
                yield return new WaitForSeconds(2f);
                //also choose which turn here /===========================
                genRichardAction();
            }
            //change state based on what happened
        }
        else
        {
            bool isDead = richardUnit.takeDamage(0);
            soundsRef.playFailHitNoise();
            richardHUD.setHP(richardUnit.currentHP);
            connerHUD.setMP(connerUnit.magicDamage);

            descBoxText.text = "Conner missed, MP wasted :(";
            //check if the enemy is dead
            if (isDead)
            {
                //end battle
                state = battleState.WON;
                endBattle();
            }
            else
            {
                //enemy turn
                state = battleState.ENEMYTURN;
                yield return new WaitForSeconds(2f);
                //choose which richard turn to do HERE =======================
                genRichardAction();
            }
            //change state based on what happened
        }
        connerAttackSuccessful = false;
    }



}
