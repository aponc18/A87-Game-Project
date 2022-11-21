using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AnimationAudioTrigger : MonoBehaviour
{
    //sound array anthony
    private AudioSource soundSource;
    public AudioClip[] wanderSounds;
    public AudioClip[] ChaseSounds;
    public AudioClip[] attackSounds;
    public AudioClip[] hurtSounds;


    public void wanderNoise()
    {
        int n = Random.Range(1, wanderSounds.Length);
        soundSource.clip = wanderSounds[n];
        soundSource.PlayOneShot(soundSource.clip);

        wanderSounds[n] = wanderSounds[0];
        wanderSounds[0] = soundSource.clip;

    }

    public void chaseNoise()
    {
        int n = Random.Range(1, ChaseSounds.Length);
        soundSource.clip = ChaseSounds[n];
        soundSource.PlayOneShot(soundSource.clip);

        ChaseSounds[n] = ChaseSounds[0];
        ChaseSounds[0] = soundSource.clip;

    }

    public void attackNoise()
    {
        int n = Random.Range(1, attackSounds.Length);
        soundSource.clip = attackSounds[n];
        soundSource.PlayOneShot(soundSource.clip);

        attackSounds[n] = attackSounds[0];
        attackSounds[0] = soundSource.clip;

    }
    public void hurtNoise()
    {
        int n = Random.Range(1, hurtSounds.Length);
        soundSource.clip = hurtSounds[n];
        soundSource.PlayOneShot(soundSource.clip);

        hurtSounds[n] = hurtSounds[0];
        hurtSounds[0] = soundSource.clip;

    }

}
