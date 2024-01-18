using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    float tocDo = 5f;
    float nhayCao = 16f;
    float ngang;
    bool chamDat;
    int doubleJump = 1;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ngang = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(ngang * tocDo, rb.velocity.y);
        Flip();

        doubleJumpF();
        if (Input.GetButtonDown("Jump")&&chamDat)
        {
            animator.SetBool("isJump", true);
            rb.velocity = new Vector2(rb.velocity.x, nhayCao);
            doubleJump--;
            Debug.Log(doubleJump + "");
        }
    }

    private void doubleJumpF()
    {
       if (doubleJump == 0)
        {
            chamDat = false;
            return;
        }
    }

    private void Flip()
    {
        if (ngang == 0)
        {

            animator.SetBool("isRun", false);
        }
        else
        {
            animator.SetBool("isRun", true);
            transform.localScale = new Vector3(ngang, transform.localScale.y, transform.localScale.z);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("nenDat")) 
        {
            chamDat = true;
            animator.SetBool("isJump", false);
            doubleJump = 2;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            UI_Mananger.diem_ += 200;
            Destroy(collision.gameObject);
        }
    }
}
