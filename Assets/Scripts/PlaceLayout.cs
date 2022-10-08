using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceLayout : MonoBehaviour
{
    [SerializeField] private GameObject firstPlace;
    [SerializeField] private GameObject secondPlace;
    [SerializeField] private Sprite firstSprite;
    [SerializeField] private Sprite secondSprite;
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject firstLayout;
    [SerializeField] private GameObject secondLayout;
    void Start()
    {
        if (PlayerPrefs.HasKey("ChosenLayout"))
        {
            switch (PlayerPrefs.GetInt("ChosenLayout"))
            {
                case 1: SetLayout(firstPlace, firstLayout);
                    SetBackground(firstSprite);
                    break;
                case 2: SetLayout(secondPlace, secondLayout);
                    SetBackground(secondSprite);
                    break;
                default: SetLayout(secondPlace, secondLayout);
                    SetBackground(secondSprite);
                    break;
            }
        }
    }

    private void SetBackground(Sprite sprite)
    {
        background.GetComponent<SpriteRenderer>().sprite = sprite;
    } 
    private void SetLayout(GameObject place, GameObject layout)
    {
        Instantiate(layout, place.transform.position, place.transform.rotation);
    } 
}
