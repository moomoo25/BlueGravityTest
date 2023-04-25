using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CharacterMovement : MonoBehaviour
{
    public float speed = 12f;
    public Transform animatorObject;
    private PlayerInput input = null;
    private Rigidbody rigid=null;
    private Animator animator=null;
    private Vector2 moveVector = Vector2.zero;
    private void Awake()
    {
        input = new PlayerInput();
        rigid = GetComponent<Rigidbody>();

        if (animatorObject != null)
            animator = animatorObject.GetComponent<Animator>();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementCancelled;
    }
    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPerformed;
        input.Player.Movement.canceled -= OnMovementCancelled;
    }
    private void FixedUpdate()
    {

        rigid.velocity = new Vector3(moveVector.x * speed * Time.deltaTime, rigid.velocity.y, moveVector.y * speed * Time.deltaTime);
        ChangeScaleLeftRight();
        if (moveVector.x != 0 || moveVector.y!=0)
        {
            animator.SetBool("isRun", true);
            return;
        }
  
        animator.SetBool("isRun", false);

    }
    private void ChangeScaleLeftRight()
    {
        if (moveVector.x != 0)
        {
            if (moveVector.x > 0)
            {
                animatorObject.localScale = new Vector3(-0.5f, animatorObject.localScale.y, animatorObject.localScale.z);
            }
            else if (moveVector.x < 0)
            {
                animatorObject.localScale = new Vector3(0.5f, animatorObject.localScale.y, animatorObject.localScale.z);
            }

        }
    }
    private void OnMovementPerformed(InputAction.CallbackContext value) 
    {
        moveVector = value.ReadValue<Vector2>();
    }
    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
    }
}
