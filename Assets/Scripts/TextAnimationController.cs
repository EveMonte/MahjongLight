using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnimationController : MonoBehaviour
{
    private Animator animator;
    private bool isBusy = false;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void FadeIn()
    {
        animator.SetBool("shouldFadeIn", false);
        isBusy = false;
    }

    public void FadeOut()
    {
        animator.SetBool("shouldFadeOut", false);
        StartCoroutine(TurnOnFadingIn());

    }

    public void TurnOnFadingOut()
    {
        if (!isBusy)
        {
            animator.SetBool("shouldFadeOut", true);
            isBusy = true;

        }


    }

    public IEnumerator TurnOnFadingIn()
    {
        yield return new WaitForSeconds(2f);
        animator.SetBool("shouldFadeIn", true);

    }
}
