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
    static public SoundManager instance;

    public AudioSource[] audioSourceEffects;
    public AudioSource audioSourceBgm;

    public Sound[] effectSounds;
    public Sound[] bgmSounds;

    public string[] playSoundName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

    }

    public void PlaySoundEffect(string _Sound)
    {
        for(int i =0; i<effectSounds.Length; i++)
        {
            if(_Sound == effectSounds[i].name)
            {
                for (int j = 0; j < audioSourceEffects.Length; j++)
                {
                    if(!audioSourceEffects[j].isPlaying)
                    {
                        playSoundName[j] = effectSounds[i].name;
                        audioSourceEffects[j].clip = effectSounds[i].clip;
                        audioSourceEffects[j].Play();
                        return;
                    }
                }
                Debug.Log("��� AudioSource �����");
                return;
            }
        }
        Debug.Log(_Sound + "�� SoundManager�� ��ϵ��� �ʾҽ��ϴ�");
    }

    public void StopAllSoundEffect()
    {
        for (int i = 0; i < audioSourceEffects.Length; i++)
        {
            audioSourceEffects[i].Stop();
        }
    }


    public void StopSoundEffect(string SoundName)
    {
        for (int i = 0; i < audioSourceEffects.Length; i++)
        {
            if(playSoundName[i] == SoundName)
            {
                audioSourceEffects[i].Stop();
                return;
            }
        }
        Debug.Log("�������" + SoundName + "�� �����ϴ�.");
    }

    public void Play_BGM(string Bgm)
    {
        for (int i = 0; i < bgmSounds.Length; i++)
        {
            if(Bgm == bgmSounds[i].name)
            {
                audioSourceBgm.clip = bgmSounds[i].clip;
                audioSourceBgm.Play();
            }
        }
    }
}