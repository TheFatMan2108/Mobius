using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BuyScript : MonoBehaviour
{
    private string KEY_WEAPON = "WEAPON";
    private GameObject data;
    private Weapon weapon;
    [SerializeField] private GameObject thongBao;

    [System.Obsolete]
    private void Awake()
    {
        data = gameObject.transform.parent.transform.Find("Info").transform.gameObject;
        weapon = new Weapon();

        weapon.NameWeapon = data.transform.Find("Name").transform.GetComponent<TMP_Text>().text;
        weapon.ImgWeapon = data.transform.Find("Image").transform.GetComponent<Image>().sprite;
        weapon.priceWeapon = int.Parse(getData("gia", "Giá:"));
        weapon.damegeWeapon = int.Parse(getData("sucManh", "Sức mạnh:"));
        Debug.Log(weapon.DamegeWeapon);

    }

    private string getData(string c, string v)
    {
        string[] sucManh = data.transform.Find(c).transform.GetComponent<TMP_Text>().text.Split(v);
        string damage = "";
        foreach (var item in sucManh)
        {
            damage += item;
        };
        return damage;
    }

    bool ok = true;
    public void selectWeapon()
    {
        int tien = PlayerPrefs.GetInt(nextScene1.KEY_COINS);
        if (tien< weapon.priceWeapon)
        {
            var tF = transform.parent.transform.parent.transform.parent.transform.parent.transform;
            Debug.Log(transform);
            var thongbao = Instantiate(thongBao,Vector3.zero,Quaternion.identity,tF);
            thongbao.transform.position = new Vector3(0f,4f);
            AudioManager.instance.PlaySFX("Wrong");
            Destroy(thongbao,5);
            return;
        }else if (UI_Mananger.diem_ >= weapon.priceWeapon)
        {
             tien= tien - weapon.priceWeapon;
            PlayerPrefs.SetInt(nextScene1.KEY_COINS, tien);
            PlayerPrefs.Save();
            PlayerPrefs.SetString(KEY_WEAPON, JsonUtility.ToJson(weapon));
            PlayerPrefs.Save();
            SceneManager.LoadScene("FightBoss");
            Debug.Log("tien: "+tien);
            Debug.Log("gia: "+weapon.priceWeapon);
            
        }
        

    }
}
