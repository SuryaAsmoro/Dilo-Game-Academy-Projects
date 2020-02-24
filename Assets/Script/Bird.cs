using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    [SerializeField] private float upForce = 100;
    [SerializeField] private bool isDead;
    [SerializeField] private UnityEvent OnJump, OnDead;
    private Rigidbody2D rigidBody2d;
    private Animator animator;

    [SerializeField] private int score;
    [SerializeField] private UnityEvent OnAddPoint;

    [SerializeField] private Text scoreText;

    void Start()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (!isDead && Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }
    public bool IsDead()
    {
        return isDead;
    }

    public void Dead()
    {
        if (!isDead && OnDead != null)
        {
            animator.enabled = false;
            OnDead.Invoke();
        }

        isDead = true;

    }

    void Jump()
    {
        if (rigidBody2d)
        {
            rigidBody2d.velocity = Vector2.zero;
            rigidBody2d.AddForce(new Vector2(0, upForce));
        }

        if (OnJump != null)
        {
            OnJump.Invoke();
        }
    }

    public void AddScore(int value)
    {
        score += value;
        if (OnAddPoint != null)
        {
            OnAddPoint.Invoke();
        }
        scoreText.text = score.ToString();
    }
}
