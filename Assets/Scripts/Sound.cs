using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound 
{
    private string Name;
    private AudioClip sfx;

    public Sound()
    {

    }
    public Sound(string v, AudioClip audioClip)
    {
       Name = v;
       sfx = audioClip;
    }

    public string Name1 { get => Name; set => Name = value; }
    public AudioClip Sfx { get => sfx; set => sfx = value; }
}
