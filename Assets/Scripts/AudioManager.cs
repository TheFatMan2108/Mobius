using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private List<Sound> MBGs = new List<Sound>();
    private List<Sound> SFXs = new List<Sound>();
    [SerializeField] private AudioClip[] Sounds;
    [SerializeField] private string[] soundName;
    [SerializeField] private AudioSource MBG;
    public AudioSource MBG_temp;
    [SerializeField] private AudioSource SFX;
    public AudioSource SFX_temp;
   
    
 

    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        MBGs.Add(new Sound(soundName[0], Sounds[0]));
        MBGs.Add(new Sound(soundName[1], Sounds[1]));
        for (int i = 2; i < Sounds.Length; i++)
        {
            
            SFXs.Add(new Sound(soundName[i], Sounds[i]));
        }
        MBG_temp = MBG;
        SFX_temp = SFX;
    }

    private void Start()
    {
        PlayMBG("theme");
    }

    public void PlayMBG(string name)
    {
        AudioClip src = FindSound(name, MBGs);

        if (src == null)
        {
            Debug.Log("Lỗi");
            return;
        }
        MBG.clip = src;
        MBG.Play();
    }

    public void PlaySFX(string Name)
    {
        AudioClip src = FindSound(Name, SFXs);

        if (src == null)
        {
            Debug.Log("Lỗi");
            return;
        }
        SFX.clip = src;
        SFX.PlayOneShot(src);
    }

    private AudioClip FindSound(string name, List<Sound> Sounds)
    {
       
        foreach (Sound item in Sounds)
        {
            Debug.Log("1: "+name);
            Debug.Log("2: " + item.Name1);
            if (name.ToLower().Trim().Equals(item.Name1.ToLower().Trim()))
            {
                Debug.Log(item.Name1);
                return item.Sfx;
            }
        }
        return null;
    }
    public void StopSound()
    {
        SFX.Stop();
    }

   
}
