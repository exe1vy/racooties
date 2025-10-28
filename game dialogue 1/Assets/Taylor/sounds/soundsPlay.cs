using UnityEngine;

public class soundsPlay : MonoBehaviour
{
    public AudioSource startingMusic;
    public AudioSource battleMusic;
    public AudioSource meleeNoise;
    public AudioSource connerCritHitNoise;
    public AudioSource connerHealNoise;
    public AudioSource connerMagicHitNoise;
    public AudioSource richardMagicNoise;
    public AudioSource hurtNoise;
    public AudioSource failHitNoise;

    public void stopStartMusic()
    {
        startingMusic.Stop();
    }
    public void playBattleNoise()
    {
        battleMusic.Play();
    }

    public void playHurtNoise()
    {
        hurtNoise.Play();
    }
    public void playFailHitNoise()
    {
        failHitNoise.Play();
    }

    public void playMeleeHitNoise()
    {
        meleeNoise.Play();
    }

    public void playConnerCritHitNoise()
    {
        connerCritHitNoise.Play();
    }

    public void playConnerHealNoise()
    {
        connerHealNoise.Play();
    }

    public void playConnerMagicHitNoise()
    {
        connerMagicHitNoise.Play();
    }

    public void playRichardMagicNoise()
    {
        richardMagicNoise.Play();
    }
    
}
