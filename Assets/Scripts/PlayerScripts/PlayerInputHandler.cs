using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerInputHandler : MonoBehaviour
{
    private Animator animator;

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    private Vector2 moveInput;
    private Rigidbody2D rb;

    [Header("Dash Settings")]
    public float dashSpeed = 15f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 2f;

    private bool isDashing = false;
    // private float dashTimer = 0f;
    private float dashCooldownTimer = 0f;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        // Eğer gerekirse enable işlemleri
    }

    private void OnDisable()
    {
        // Eğer gerekirse disable işlemleri
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    [Obsolete]
    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed && !isDashing && dashCooldownTimer <= 0f)
        {
            StartCoroutine(Dash());
        }
    }

    [Obsolete]
    private IEnumerator Dash()
    {
        isDashing = true;
        dashCooldownTimer = dashCooldown;

        Vector2 dashDirection = moveInput.normalized;
        rb.velocity = dashDirection * dashSpeed;

        yield return new WaitForSeconds(dashDuration);

        isDashing = false;
    }

    [Obsolete]
    void FixedUpdate()
    {
        if (!isDashing)
        {
            rb.velocity = moveInput.normalized * moveSpeed;
        }
    }

    void Update()
    {
        if (dashCooldownTimer > 0f)
            dashCooldownTimer -= Time.deltaTime;

        animator.SetFloat("Speed", moveInput.magnitude);
    }
}
