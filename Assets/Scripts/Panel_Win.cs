using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Panel_Win : MonoBehaviour
{
    [SerializeField] private TMP_Text lastHealths;
    [SerializeField] private TMP_Text lastCoins;
    [SerializeField] private TMP_Text lastSnakes;
    [SerializeField] private TMP_Text lastBoss;
    [SerializeField] private TMP_Text highScore;
    [SerializeField] private TMP_Text toTal;

    private Player player;
    private int newHealth;
    private int newCoins;
    private int newSnakes;
    private int newBoss;
    private int score;
    private string key;



    private void Awake()
    {
        player = new Player();
        key = demon_moveSet.KEY_PLAYER;
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(key, "1111"), player);
        Debug.Log(player.Coins + " get coins 2");
        Debug.Log(PlayerPrefs.GetString(key, "1111") + " get coins 2");
        
    }


        void Update()
    {
        newHealth = (player.Health * 2000);
        newCoins = (player.Coins);
        newSnakes = (player.Snakes*1000);
        newBoss = (player.Boss*3000);
        score = newHealth + newCoins + newSnakes + newBoss;
        int diem = HighScore(score, player.HighScore);
        lastHealths.SetText("x " + player.Health + "......" +newHealth );
        lastCoins.SetText("x " + player.Coins + " ......" + newCoins);
        lastSnakes.SetText("x " + player.Snakes + " ......." + newSnakes);
        lastBoss.SetText("x " + player.Boss + "......" + newBoss);
        highScore.SetText("HighScore: " + diem);
        toTal.SetText("Total:" + score);
        int i = 0;
        if (i==0)
        {
            PlayerPrefs.SetInt("score", score);
            PlayerPrefs.Save();
            i++;
        }
    }

    public int HighScore(int newScore, int olbScore)
    {
        if (newScore > olbScore)
        {
            return newScore;
        }
        else
        {
            return olbScore;
        }
    }

    public void PlayeAgain()
    {
        SceneManager.LoadScene("LV1");    
       
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

}
