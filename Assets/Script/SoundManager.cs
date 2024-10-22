using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager SharedInstance = null; 

    private void Awake()
    {
        if (SharedInstance == null)
        {
            SharedInstance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            if (SharedInstance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public Sound[] effectSound;
    public Sound[] BgmSound;

    public AudioSource audioSourceBFM;
    public AudioSource[] audioSourceEffects; 

    public string[] playSoundName; 

    void Start()
    {
        playSoundName = new string[audioSourceEffects.Length];
    }


    public void PlaySE(string _name)
    {
        for (int i = 0; i < effectSound.Length; i++)
        {
            if (_name == effectSound[i].name)
            {
                for (int j = 0; j < audioSourceEffects.Length; j++)
                {
                    if (!audioSourceEffects[j].isPlaying)
                    {
                        audioSourceEffects[j].clip = effectSound[i].clip;
                        audioSourceEffects[j].Play();
                        playSoundName[j] = effectSound[i].name;
                        return;
                    }
                }
  
                return;
            }
        }

    }

    public void PlayBGM(string _name)
    {
        for (int i = 0; i < BgmSound.Length; i++)
        {
            if (_name == BgmSound[i].name)
            {
                audioSourceBFM.clip = BgmSound[i].clip;
                audioSourceBFM.Play();
                return;
            }
        }
    }

    public void StopAllSE()
    {
        for (int i = 0; i < audioSourceEffects.Length; i++)
        {
            audioSourceEffects[i].Stop();
        }
    }

}
