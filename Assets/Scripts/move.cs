using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject buttonSkill;

    public static float huong;

    private float tocDo = 5f;
    private float nhayCao = 16f;
    private float ngang;
    private bool chamDat;
    private int doubleJump = 2;
    private bool visualControl = false;
    private bool isJump = false;
    private int countJumpButton = 1;


    // Update is called once per frame
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name.Equals("FightBoss"))
        {
            buttonSkill.SetActive(true);
        }
        else
        {
            buttonSkill.SetActive(false);
        }
        
    }

    private void Start()
    {
        Application.targetFrameRate = 50;
    }
    void Update()
    {
        huong = transform.localScale.x;
        
       
        rb.velocity = new Vector2(ngang * tocDo, rb.velocity.y);
        Flip();
        
        doubleJumpF();
      
    }

    void OnMove(InputValue input)
    {
        ngang = input.Get<Vector2>().x;
    }

    void OnJump(InputValue input)
    {
        if (input.isPressed && chamDat)
        {
            animator.SetBool("isJump", true);
            rb.velocity = new Vector2(rb.velocity.x, nhayCao);
            doubleJump--;
            AudioManager.instance.PlaySFX("jump");

        }
    }

    private void doubleJumpF()
    {
        if (doubleJump == 0)
        {
            chamDat = false;
            Debug.Log(doubleJump);
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
            AudioManager.instance.PlaySFX("coin");
        }
    }
    public void walking()
    {
        AudioManager.instance.PlaySFX("walk");
    }
}
