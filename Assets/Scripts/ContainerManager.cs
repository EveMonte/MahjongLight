using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ContainerManager : MonoBehaviour
{
    public static ContainerManager instance = null;
    private int containerCapacity;
    [SerializeField] private List<GameObject> items;
    private List<GameObject> tiles;
    private int containerCount = 0;
    [SerializeField] private GameObject warning;
    [SerializeField] private Text score;
    void Start ()
    {
        if (instance == null) {
            instance = this; 
        } else if(instance == this){ 
            Destroy(gameObject); 
        }

        DontDestroyOnLoad(gameObject);

        InitializeManager();
    }

    private void InitializeManager()
    {
        containerCapacity = items.Count;
        tiles = new List<GameObject>(items);
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
                    tiles[i] = tile;
                    containerCount++;
                    tile.SendMessage("ActivateMovementToContainer", items[i].transform.position);
                    return;
                }
            }
        }
        else
        {
            return;
        }
    }

    public void LookingForTriple(string tagName)
    {
        int count = tiles.Count(n => n.CompareTag(tagName));
        if (count == 3)
        {
            for (int i = 0; i < tiles.Count; i++)
            {
                if (tiles[i].CompareTag(tagName))
                {
                    Destroy(tiles[i]);
                    tiles[i] = items[i];
                    containerCount--;
                    score.text = (int.Parse(score.text) + 1).ToString();
                }
            }
        }
    }
}
