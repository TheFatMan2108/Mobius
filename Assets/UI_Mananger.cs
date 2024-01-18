using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Mananger : MonoBehaviour
{
    [SerializeField] TMP_Text mang;
    [SerializeField] TMP_Text diem;
   public static int mang_ = 3;
   public static int diem_ = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mang.SetText("x " + mang_);
        diem.SetText("" + diem_);
    }
}
