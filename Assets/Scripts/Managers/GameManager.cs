using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    public static GameManager instance;

    public int Score { get => score; set => score = value; }

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
        //healthText.text = "HEALTH: " + healthPalyer;
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


}
