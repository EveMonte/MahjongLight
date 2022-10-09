using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
        [SerializeField] private GameObject settings;
        [SerializeField] private GameObject gameUI;
        [SerializeField] private Sprite soundOn;
        [SerializeField] private Sprite soundOff;
        [SerializeField] private Sprite SFXOff;
        [SerializeField] private Sprite SFXOn;
        [SerializeField] private Button sound;
        [SerializeField] private Button SFX;
        [SerializeField] private Camera camera;
        [SerializeField] private GameObject container;

        private bool isSoundOn = true;
        private bool isSFXOn = true;
        private AudioSource click;
        private AudioSource audioBackground;
        private AudioSource triple;


        private void Start()
        {
                triple = container.GetComponent<AudioSource>();
                if (PlayerPrefs.HasKey("isSoundOn"))
                {
                        isSoundOn = Convert.ToBoolean(PlayerPrefs.GetInt("isSoundOn"));
                }
                if (PlayerPrefs.HasKey("isSFXOn"))
                {
                        isSFXOn = Convert.ToBoolean(PlayerPrefs.GetInt("isSFXOn"));
                }

                click = gameObject.GetComponent<AudioSource>();
                audioBackground = camera.GetComponent<AudioSource>();
                audioBackground.mute = !isSoundOn;
                click.mute = !isSFXOn;
                triple.mute = !isSFXOn;
                SetSoundSprite();
                SetSFXSprite();

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

        public void OnMenuClick()
        {
                click.PlayOneShot(click.clip);
                SceneManager.LoadScene("MainMenu");
        }
        
        public void OnBackClick()
        {
                click.PlayOneShot(click.clip);

                settings.SetActive(false);
                gameUI.SetActive(true);
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
                triple.mute = !isSFXOn;

                PlayerPrefs.SetInt("isSFXOn", Convert.ToInt32(isSFXOn));

        }


        public void OnRestartClick()
        {
                SceneManager.LoadScene("SampleScene");
        }


        public void OnSettingsClick()
        {
                click.PlayOneShot(click.clip);
                gameUI.SetActive(false);
                settings.SetActive(true);
        }
}
