using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{
    public int health;
    public int coins;
    public int snakes;
    public int boss;
    public int highScore;

    public int Health { get => health; set => health = value; }
    public int Coins { get => coins; set => coins = value; }
    public int Snakes { get => snakes; set => snakes = value; }
    public int Boss { get => boss; set => boss = value; }
    public int HighScore { get => highScore; set => highScore = value; }
}
