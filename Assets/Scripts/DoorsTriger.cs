using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsTriger : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject trigger;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("Open");
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetTrigger("Close");
    }
}
