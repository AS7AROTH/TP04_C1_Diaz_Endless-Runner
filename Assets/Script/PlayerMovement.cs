using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float upForce;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float radius;

    private Rigidbody2D playerRb;
    private Animator playerAnimator;

    void Start()
    {
       playerRb = GetComponent<Rigidbody2D>();
       playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, radius, ground);
        playerAnimator.SetBool("IsGrounded", isGrounded);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                playerRb.AddForce(Vector2.up * upForce);
            }
        }
    }

    private void OnDrawGizmos()
    { 
        Gizmos.DrawWireSphere(groundCheck.position, radius);
    }      
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManeger.Instance.ShowGameOverScreen();
            playerAnimator.SetTrigger("Die");
            Time.timeScale = 0f;
        }
    }
}
