using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Singleton<AudioManager>
public class AudioManager : MonoBehaviour
{
    public AudioSource BackgroundMusic;
    public AudioSource SoundEffect;

    public AudioClip CheerSound;
    public AudioClip OneShape;
    /*public AudioClip LaserClip;
    public AudioClip RegularExplosion;
    public AudioClip SimpleExplosion;
    public AudioClip SonicExplosion;
    public AudioClip BlueLaserExplosion;
    */
    
    public void gameWon()
    {
            SoundEffect.PlayOneShot(CheerSound);
    }

    public void ShapeMatch()
    {
            SoundEffect.PlayOneShot(OneShape);
    }
    
    /*public void LaserSound()
    {
        if (LaserClip!=null)
            SoundEffect.PlayOneShot(LaserClip);
    }

    public void ExplosionSound()
    {
        if (RegularExplosion!=null)
            SoundEffect.PlayOneShot(RegularExplosion);
    }
    */

}
