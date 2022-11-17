using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSounds : MonoBehaviour
{
    public AudioSource m_audioClip;

    public void Playm_audioClip() {
    m_audioClip.Play();
    }

    void onTriggerEnter() {
        
    }
}
