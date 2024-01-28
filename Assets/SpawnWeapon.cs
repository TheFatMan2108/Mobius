using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWeapon : MonoBehaviour
{
    [SerializeField] GameObject weapon;
    [SerializeField] GameObject Skill;
   
    Weapon Info;
    public static bool casSkill = false;
    public void loadWeapon()
    {
       
        Info = new Weapon();
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("WEAPON"),Info);
        weapon.SetActive(true);
        weapon.transform.GetComponent<SpriteRenderer>().sprite = Info.imgWeapon;
        
    }

    private void Awake()
    {
        loadWeapon();
    }
    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.E))
        {
            if (!casSkill)
            {
               Instantiate(Skill, transform.position, Quaternion.identity, transform);
                AudioManager.instance.PlaySFX("Spell");
                casSkill = true;
            }
        }
        
    }
}
