using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float upForce;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float radius;
    [SerializeField] private AudioClip jumpSound;

    private Rigidbody2D playerRb;
    private Animator playerAnimator;
    private AudioSource audioSource;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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

                if (jumpSound != null && audioSource != null)
                    audioSource.PlayOneShot(jumpSound);
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
