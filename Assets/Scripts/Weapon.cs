using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public string nameWeapon;
    public Sprite imgWeapon;
    public int priceWeapon;
    public float damegeWeapon;

    public string NameWeapon { get => nameWeapon; set => nameWeapon = value; }
    public Sprite ImgWeapon { get => imgWeapon; set => imgWeapon = value; }
    public int PriceWeapon { get => priceWeapon; set => priceWeapon = value; }
    public float DamegeWeapon { get => damegeWeapon; set => damegeWeapon = value; }
}
