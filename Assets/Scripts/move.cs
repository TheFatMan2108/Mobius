using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    void Update()
    {
        huong = transform.localScale.x;
        
        ngang = inputLeftRight();
        rb.velocity = new Vector2(ngang * tocDo, rb.velocity.y);
        Flip();
        
        doubleJumpF();
        if (toJump() && chamDat)
        {
            animator.SetBool("isJump", true);
            rb.velocity = new Vector2(rb.velocity.x, nhayCao);
            doubleJump--;
            AudioManager.instance.PlaySFX("jump");

        }
    }

    private bool toJump()
    {
        if (!isJump)
        {
            return Input.GetButtonDown("Jump");
        }
        else
        {
            countJumpButton--;
            return countJumpButton>=0 ? true : false;
        }
    }

    private float inputLeftRight()
    {
        if (!visualControl)
        {
            return Input.GetAxisRaw("Horizontal");
        }
        else
        {
            return ngang;
        }
    }

    public void downKeyJump()
    {
        
        isJump = true;
        
        Debug.Log(chamDat+" ok1");
    }
    public void upKeyJump()
    {
        isJump = false;
        countJumpButton = 1;
    }

    public void downKeyLeft()
    {
        visualControl = true;
        ngang = -1;
    }

    public void downKeyRight()
    {
        visualControl = true;
        ngang = 1;
    }

    public void upKey()
    {
        visualControl = false;
       
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
