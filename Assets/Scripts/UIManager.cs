using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public TextMeshProUGUI scoreText;
    private int score;
    public TextMeshProUGUI highScoreText;
    private int highScore;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI waveText;
    private int wave;
    public Image[] lifeSprites;
    public Image healthBar;
    public Image[] healthBars;
    private Color32 active = new Color(1, 1, 1, 1);
    private Color32 inactive = new Color(1, 1, 1, 0.25f);

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static void UpdateLives(int l)
    {

    }
    public static void UpdateHealthBar(int h)
    {

    }
    public static void UpdateScore()
    {

    }
    public static void UpdateWave()
    {

    }
    public static void UpdateHighScore()
    {

    }
    public static void UpdateCoins()
    {

    }
}
