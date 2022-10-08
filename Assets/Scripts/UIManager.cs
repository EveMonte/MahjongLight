using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
        public void OnRestartClick()
        {
                SceneManager.LoadScene("SampleScene");
        }

        public void OnHomeClick()
        {
                SceneManager.LoadScene("MainMenu");
        }
}
