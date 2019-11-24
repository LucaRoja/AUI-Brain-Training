using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource BackgroundMusic;
    public AudioSource SoundEffect;

    public AudioClip ThrustClip;
    public AudioClip LaserClip;
    public AudioClip RegularExplosion;
    public AudioClip SimpleExplosion;
    public AudioClip SonicExplosion;
    public AudioClip BlueLaserExplosion;
    
    public void ThrustSound()
    {
        if (ThrustClip!=null)
            SoundEffect.PlayOneShot(ThrustClip);
    }
    
    public void LaserSound()
    {
        if (LaserClip!=null)
            SoundEffect.PlayOneShot(LaserClip);
    }

    public void ExplosionSound()
    {
        if (RegularExplosion!=null)
            SoundEffect.PlayOneShot(RegularExplosion);
    }

}

public class Singleton<T>
{
}