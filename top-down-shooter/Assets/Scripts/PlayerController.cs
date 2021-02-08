using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // || Inspector References

    [SerializeField] private float moveSpeed;

    // || State

    private Vector2 moveInput;

    // || Cached References

    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        transform.Translate(moveInput * Time.deltaTime * moveSpeed);

        animator.SetBool("IsMoving", moveInput != Vector2.zero);
    }
}