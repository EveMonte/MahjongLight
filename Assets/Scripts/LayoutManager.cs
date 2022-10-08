using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LayoutManager : MonoBehaviour
{
        public void OnFirstLayoutClick()
        {
                PlayerPrefs.SetInt("ChosenLayout", 1);
                StartScene();
        }
        public void OnSecondLayoutClick()
        {
                PlayerPrefs.SetInt("ChosenLayout", 2);
                StartScene();
        }

        private void StartScene()
        {
                SceneManager.LoadScene("SampleScene");
        }
}
