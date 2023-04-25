using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogInteractable : InteracableObject
{
    private Animator animator=null;
    private bool isRun = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public override void OnInteract()
    {
        isRun = !isRun;
        animator.SetBool("isRun", isRun);
    }
}
