
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ListWeapon : MonoBehaviour
{

    [SerializeField] GameObject weapons;
    [SerializeField] Sprite sprite1, sprite2, sprite3, sprite4, sprite5, sprite6, sprite7, sprite8, sprite9, sprite10;
   
    private List<Weapon> weaponList;

    private void Awake()
    {
        randomPrice();
        randomPower();
        weaponList = new List<Weapon>();
        weaponList.Add(newWeapon("Ginny Weasley", sprite1,randomPrice(),randomPower() ));
        weaponList.Add(newWeapon("Ron Weasley", sprite2, randomPrice(), randomPower()));
        weaponList.Add(newWeapon("Lucius Malfoy", sprite3, randomPrice(),randomPower()));
        weaponList.Add(newWeapon("Rubeus Hagrid", sprite4, randomPrice(), randomPower()));
        weaponList.Add(newWeapon("Hermione Granger", sprite5, randomPrice(), randomPower()));
        weaponList.Add(newWeapon("Bellatrix Lestrange", sprite6, randomPrice(),randomPower()));
        weaponList.Add(newWeapon("Minerva Mcgonagall", sprite7, randomPrice(), randomPower()));
        weaponList.Add(newWeapon("Severus Snape", sprite8, randomPrice(), randomPower()));
        weaponList.Add(newWeapon("Voldemort", sprite9, randomPrice(),randomPower()));
        weaponList.Add(newWeapon("Harry Potter", sprite10, randomPrice(), randomPower()));

        for (int i = 0; i < 2; i++)
        {

            Instantiate(newWeapon(weaponList[UnityEngine.Random.Range(0,weaponList.Count)]), transform);
        }

    }

    private int randomPower()
    {
        return UnityEngine.Random.Range(200, 1000);
    }

    private int randomPrice()
    {
       return UnityEngine.Random.Range(6000, 8000);
    }

    private GameObject newWeapon(Weapon weapon)
    {
        GameObject gameObject = weapons;
        gameObject.name = "weapon";
        gameObject.transform.Find("Info").transform.Find("Name").transform.GetComponent<TMP_Text>().text = weapon.NameWeapon;
        gameObject.transform.Find("Info").transform.Find("Image").transform.GetComponent<Image>().sprite = weapon.ImgWeapon;
        gameObject.transform.Find("Info").transform.Find("gia").transform.GetComponent<TMP_Text>().text = "Giá:" + weapon.PriceWeapon;
        gameObject.transform.Find("Info").transform.Find("sucManh").transform.GetComponent<TMP_Text>().text = "Sức mạnh:" + weapon.DamegeWeapon;
        gameObject.transform.Find("Info").transform.Find("Mua").transform.GetComponent<Button>().onClick.AddListener(selectWeapon);
        return gameObject;
    }

    private Weapon Weapon(GameObject gameObject)
    {
        Weapon weapon = new Weapon();
        weapon.NameWeapon = gameObject.transform.Find("Info").transform.Find("Name").transform.GetComponent<TMP_Text>().text;
        weapon.ImgWeapon = gameObject.transform.Find("Info").transform.Find("Image").transform.GetComponent<Image>().sprite;
        string textPrice = gameObject.transform.Find("Info").transform.Find("gia").transform.GetComponent<TMP_Text>().text;
        string textDamege = gameObject.transform.Find("Info").transform.Find("sucManh").transform.GetComponent<TMP_Text>().text;
        weapon.PriceWeapon = int.Parse(getFloat(textPrice, "Giá:"));
        weapon.DamegeWeapon = float.Parse(getFloat(textDamege, "Sức mạnh:"));
        return weapon;
    }

    private Weapon newWeapon(string name, Sprite image, int price, float damage)
    {
        Weapon weapon = new Weapon();
        weapon.NameWeapon = name;
        weapon.ImgWeapon = image;
        weapon.PriceWeapon = price;
        weapon.DamegeWeapon = damage;
        return weapon;
    }

    private string getFloat(string text, string textDelete)
    {
        string[] c = text.Split(textDelete, text.Length);
        string txt = "";
        for (int i = 0; i < c.Length; i++)
        {
            txt += c[i];
        }
        return txt;
    }

    public void selectWeapon()
    {
        Debug.Log(Weapon(gameObject).NameWeapon);
    }
}
