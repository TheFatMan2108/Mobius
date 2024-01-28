using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Mananger : MonoBehaviour
{
    [SerializeField] TMP_Text mang;
    [SerializeField] TMP_Text diem;
    public static int mang_;
    public static int diem_;
    // Start is called before the first frame update
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name.Equals("LV1"))
        {
            mang_ = 3;
            diem_ = 0;
        }
        else
        {
            mang_ = PlayerPrefs.GetInt(nextScene1.KEY_HEALTH, 3);
            diem_ = PlayerPrefs.GetInt(nextScene1.KEY_COINS, 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        mang.SetText("x " + mang_);
        diem.SetText("" + diem_);
    }
}
