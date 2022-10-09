using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject chooseLayout;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject rules;
    [SerializeField] private Sprite soundOn;
    [SerializeField] private Sprite soundOff;
    [SerializeField] private Sprite SFXOff;
    [SerializeField] private Sprite SFXOn;
    [SerializeField] private Button sound;
    [SerializeField] private Button SFX;
    [SerializeField] private Camera camera;

    private bool isSoundOn = true;
    private bool isSFXOn = true;
    private AudioSource click;
    private AudioSource audioBackground;

    private void Start()
    {
        click = gameObject.GetComponent<AudioSource>();
        audioBackground = camera.GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("isSoundOn"))
        {
            isSoundOn = Convert.ToBoolean(PlayerPrefs.GetInt("isSoundOn"));
        }
        if (PlayerPrefs.HasKey("isSFXOn"))
        {
            isSFXOn = Convert.ToBoolean(PlayerPrefs.GetInt("isSFXOn"));
        }
        audioBackground.mute = !isSoundOn;
        click.mute = !isSFXOn;

        
        SetSoundSprite();
        SetSFXSprite();
    }

    public void OnRulesClick()
    {
        click.PlayOneShot(click.clip);

        rules.SetActive(true);
        mainMenu.SetActive(false);

    }

    public void OnBackClick()
    {
        click.PlayOneShot(click.clip);

        settings.SetActive(false);
        rules.SetActive(false);
        mainMenu.SetActive(true);
    }


    public void SetSoundSprite()
    {
        if (isSoundOn)
        {
            sound.GetComponent<Image>().sprite = soundOn;
        }
        else
        {
            sound.GetComponent<Image>().sprite = soundOff;
        }

    }


    public void SetSFXSprite()
    {
        if (isSFXOn)
        {
            SFX.GetComponent<Image>().sprite = SFXOn;
        }
        else
        {
            SFX.GetComponent<Image>().sprite = SFXOff;
        }

    }
    public void OnSoundClick()
    {
        click.PlayOneShot(click.clip);
        isSoundOn = !isSoundOn;
        SetSoundSprite();
        audioBackground.mute = !isSoundOn;
        PlayerPrefs.SetInt("isSoundOn", Convert.ToInt32(isSoundOn));
    }

    public void OnSFXClick()
    {
        click.PlayOneShot(click.clip);
        isSFXOn = !isSFXOn;
        SetSFXSprite();
        click.mute = !isSFXOn;
        PlayerPrefs.SetInt("isSFXOn", Convert.ToInt32(isSFXOn));

    }
    
    public void OnStartClick()
    {
        click.PlayOneShot(click.clip);
        chooseLayout.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void OnSettingsClick()
    {
        click.PlayOneShot(click.clip);
        settings.SetActive(true);
        mainMenu.SetActive(false);

    }

    public void OnExitClick()
    {
        click.PlayOneShot(click.clip);

        Application.Quit();
    }
}
