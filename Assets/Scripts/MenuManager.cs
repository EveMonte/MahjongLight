using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject chooseLayout;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settings;
    public void OnStartClick()
    {
        chooseLayout.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void OnSettingsClick()
    {
        
    }

    public void OnExitClick()
    {
        Application.Quit();
    }
}
