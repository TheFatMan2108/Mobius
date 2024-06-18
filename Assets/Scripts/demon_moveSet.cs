using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class demon_moveSet : MonoBehaviour
{
    [SerializeField] GameObject fire;
    [SerializeField] GameObject brurning;
    [SerializeField] Animator animator;
    [SerializeField] Slider barHealh;
    [SerializeField] GameObject PanelWin;

    private float health = 1000;
    private float healthMax = 1000;
    private float healthMin = 0;
    private float damageWeapon = 0;
    private bool isAttack;
    private int i = 0;
    public static string KEY_PLAYER = "PLAYER";
    public static demon_moveSet demon_;
    public Player player;
    private void Awake()
    {
        demon_ = this;
        AudioManager.instance.PlayMBG("Boss");
        barHealh.maxValue = healthMax;
        barHealh.minValue = healthMin;

    }

    // Update is called once per frame
    void Update()
    {
        damageWeapon = SpawnWeapon.damageWeapon;
        isAttack = animator.GetBool("isAttack");
        barHealh.value = health;
        if (!isAttack && i == 0)
        {
            isAttack = true;
            Debug.Log("dang invoke");
            Invoke("demonActive", 5);
            i++;
        }

    }

    public void demonAttack()
    {
        var fireDemon = Instantiate(fire, new Vector3(transform.position.x + 5 * -1, transform.position.y + -3), Quaternion.identity);
        demonClearAttack();
    }

    public void demonClearAttack()
    {
        animator.SetBool("isAttack", false);
        i = 0;
    }
    public void demonActive()
    {
        animator.SetBool("isAttack", true);
        AudioManager.instance.PlaySFX("dmFire");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            health -= damageWeapon;
            Destroy(collision.gameObject);
            Debug.Log("gay damage len quai : " + damageWeapon);
            AudioManager.instance.PlaySFX("dmHit");

        }
        if (health < 0)
        {   save();
            Instantiate(brurning, new Vector3(transform.position.x, transform.position.y * 15f), Quaternion.identity, transform);
            AudioManager.instance.PlayMBG("theme");
            AudioManager.instance.PlaySFX("dmScream");
            animator.Play("Demon_dead");
           
        }
    }

    private void save()
    {
        player = new Player();
        player.Health = UI_Mananger.mang_;
        player.Coins = UI_Mananger.diem_;
        player.Snakes = PlayerPrefs.GetInt(nextScene1.KEY_SNAKES,0);
        player.Boss = 1;
        player.highScore = PlayerPrefs.GetInt("score", 0);
        PlayerPrefs.SetString(KEY_PLAYER, JsonUtility.ToJson(player));
        PlayerPrefs.Save();
        Debug.Log(player.Snakes + " get coins");
    }

    public void demonFlaping()
    {
        AudioManager.instance.PlaySFX("dmFlaping");
    }

    public void Dead()
    {
        PanelWin.SetActive(true);
        gameObject.SetActive(false);
    }
}

