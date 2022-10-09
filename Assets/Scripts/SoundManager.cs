using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private GameObject sfxmanager;

    private AudioSource sound;
    private AudioSource sfx;
    // Start is called before the first frame update
    void Start()
    {
        sfx = sfxmanager.GetComponent<AudioSource>();
        sound = camera.GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("isSoundOn"))
        {
            sound.mute = !Convert.ToBoolean(PlayerPrefs.GetInt("isSoundOn"));
        }
        if (PlayerPrefs.HasKey("isSFXOn"))
        {
            sfx.mute = !Convert.ToBoolean(PlayerPrefs.GetInt("isSFXOn"));
        }
    }

}
