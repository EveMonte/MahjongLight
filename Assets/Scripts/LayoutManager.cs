using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LayoutManager : MonoBehaviour
{
        [SerializeField] private GameObject menuManager;
        private AudioSource click;

        private void Start()
        {
                click = menuManager.GetComponent<AudioSource>();
        }
        
        public void OnFirstLayoutClick()
        {
                click.PlayOneShot(click.clip);
                PlayerPrefs.SetInt("ChosenLayout", 1);
                StartScene();
        }
        public void OnSecondLayoutClick()
        {
                click.PlayOneShot(click.clip);

                PlayerPrefs.SetInt("ChosenLayout", 2);
                StartScene();
        }

        private void StartScene()
        {
                SceneManager.LoadScene("SampleScene");
        }
}
