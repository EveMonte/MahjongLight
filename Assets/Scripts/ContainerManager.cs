using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContainerManager : MonoBehaviour
{
    public static ContainerManager instance = null;
    private int containerCapacity;
    [SerializeField] private List<GameObject> items;
    private List<GameObject> tiles;
    private int containerCount = 0;
    [SerializeField] private GameObject warning;
    [SerializeField] private GameObject finishPanel;
    [SerializeField] private GameObject finishText;
    [SerializeField] private Text score;
    private AudioSource triple;
    void Start ()
    {
        if (instance == null) {
            instance = this; 
        } 

        InitializeManager();
    }

    private void InitializeManager()
    {
        containerCapacity = items.Count;
        tiles = new List<GameObject>(items);
        triple = gameObject.GetComponent<AudioSource>();
    }

    public void SetSettings()
    {
        
    }

    public void ShowWarning()
    {
        warning.SendMessage("TurnOnFadingOut", SendMessageOptions.DontRequireReceiver);
    }

    public void AddToContainer(GameObject tile)
    {
        if (containerCount < containerCapacity)
        {
            for (int i = 0; i < containerCapacity; i++)
            {
                if (tiles[i].CompareTag("Untagged"))
                {
                    tiles[i].tag = "Busy";
                    tile.SendMessage("ActivateMovementToContainer", items[i].transform.position);
                    return;
                }
            }
        }
        else
        {
            FailedGame();
            return;
        }
    }

    public void AddToTiles(GameObject tile)
    {
        for (int i = 0; i < containerCapacity; i++)
        {
            if (tiles[i].CompareTag("Busy"))
            {
                tiles[i].tag = "Untagged";
                tiles[i] = tile;
                containerCount++;
                LookingForTriple(tile.tag);
                return;
            }
        }

    }

    public void LookingForTriple(string tagName)
    {
        int count = tiles.Count(n => n.CompareTag(tagName));
        if (count == 3)
        {
            triple.PlayOneShot(triple.clip);
            for (int i = 0; i < tiles.Count; i++)
            {
                if (tiles[i].CompareTag(tagName))
                {
                    tiles[i].SetActive(false);
                    tiles[i] = items[i];
                    containerCount--;
                    score.text = (int.Parse(score.text) + 1).ToString();
                }
            }
        }

        if (int.Parse(score.text) == 15)
        {
            FinishGame();
        }
    }

    
    private void FinishGame()
    {
        finishText.GetComponent<Text>().text = "Вы выиграли!";
        finishPanel.SetActive(true);
        finishText.GetComponent<Animator>().SetBool("shouldFadeOut", true);
        StartCoroutine(OpenMenu());

    }
    private void FailedGame()
    {
        finishText.GetComponent<Text>().text = "Вы проиграли!";

        finishPanel.SetActive(true);
        finishText.GetComponent<Animator>().SetBool("shouldFadeOut", true);
        StartCoroutine(OpenMenu());
    }

    public IEnumerator OpenMenu()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("MainMenu");
    }
}
