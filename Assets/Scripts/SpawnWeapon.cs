using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWeapon : MonoBehaviour
{
    [SerializeField] GameObject Skill;
    public static float damageWeapon;
   
    Weapon Info;
    public static bool casSkill = false;
    public void loadWeapon()
    {
       
        Info = new Weapon();
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("WEAPON"),Info);
        transform.gameObject.SetActive(true);
        transform.GetComponent<SpriteRenderer>().sprite = Info.imgWeapon;
        damageWeapon = Info.damegeWeapon;
        Debug.Log("gay damage len quai 1 :  "+ damageWeapon);
        Debug.Log("TEN WEAPON 1 :  "+ Info.NameWeapon);
        
    }

    private void Awake()
    {
        loadWeapon();
    }
    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.E))
        {
            SkillSpawn();
        }
        
    }

    public void SkillSpawn()
    {
        if (!casSkill)
        {
            Instantiate(Skill, transform.position, Quaternion.identity, transform);
            AudioManager.instance.PlaySFX("Spell");
            casSkill = true;
        }
    }
}
