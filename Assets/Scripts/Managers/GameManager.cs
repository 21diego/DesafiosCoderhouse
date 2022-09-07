using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] int score = 0;
    int healthPalyer = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI healthText;

    public static GameManager instance;

    public int Score { get => score; set => score = value; }
    public int HealthPalyer { get => healthPalyer; set => healthPalyer = value; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "SCORE: " + score;
        healthText.text = "HEALTH: " + healthPalyer;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore(int points)
    {
        Score += points;
        scoreText.text = "SCORE: " + Score;
    }
    public void UpdateHealth(int heal)
    {
        HealthPalyer += heal;
        healthText.text = "HEALTH: " + HealthPalyer;
    }
}