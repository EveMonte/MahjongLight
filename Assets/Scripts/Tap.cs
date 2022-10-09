using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : MonoBehaviour
{
    [SerializeField] private bool isActive;
    [SerializeField] private GameObject underlyingTile;
    [SerializeField] private float duration; 
    private float time = 0;
    private bool toContainer = false;
    private Vector3 targetPosition;
    private Vector3 startPosition;
    private bool isLocked = false;


    private void Start()
    {
        startPosition.x = transform.position.x;
        startPosition.y = transform.position.y;
        startPosition.z = transform.position.z;
    }

    private void DisableAnimation()
    {
        gameObject.GetComponent<Animator>().SetBool("shouldFadeOut", false);
    }
    
    private void IsActive(bool value)
    {
        isActive = value;
        gameObject.GetComponent<Animator>().SetBool("shouldFadeOut", true);
    }
    private void OnMouseDown()
    {
        if (isActive && !isLocked)
        {
            isLocked = true;
            ContainerManager.instance.AddToContainer(gameObject);
            if (underlyingTile != null)
            {
                underlyingTile.SendMessage("IsActive", true, SendMessageOptions.DontRequireReceiver);
            }
        }
        else
        {
            ContainerManager.instance.ShowWarning();
        }
    }

    private void ActivateMovementToContainer(Vector3 targetCoords)
    {
        targetPosition = targetCoords;
        toContainer = true;
    }

    private void FixedUpdate()
    {
        if (toContainer)
        {
            time += Time.deltaTime;
            transform.position = Vector3.Slerp(startPosition, targetPosition, time / duration);
            if (time / duration >= 1)
            {
                toContainer = false;
                ContainerManager.instance.AddToTiles(gameObject);
            }
        }
    }
}
