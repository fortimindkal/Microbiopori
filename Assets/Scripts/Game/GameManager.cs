using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Microbiopori
{ 
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance; // Singleton pattern to ensure only one instance exists.

        [Header("Game Parameters")]
        [SerializeField] private int gameScore;
        [SerializeField] private bool isGameOver = false;

        [Header("Game User-Interface")]
        [SerializeField] private GameObject gameOverUI;
        [SerializeField] private Text scoreText;

        private void Awake()
        {
            // Implementing the Singleton pattern.
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        // Start is called before the first frame update
        void Start()
        {
            InitializeGame();
        }

        // Update is called once per frame
        void Update()
        {
            //UpdateScore();
        }

        void InitializeGame()
        {
            gameScore = 0;
        }

        void UpdateScore()
        {
            scoreText.text = "Score: " + gameScore.ToString();
        }

        public void AddScore(int score)
        {
            gameScore += score;
            UpdateScore();
        }

        // Call this function to handle game over logic.
        public void GameOver()
        {
            if (!isGameOver)
            {
                isGameOver = true;
                ShowGameOverUI();
                // Handle any other game over logic, such as stopping gameplay.
            }
        }

        // Show the game over UI.
        void ShowGameOverUI()
        {
            if (gameOverUI != null)
            {
                gameOverUI.SetActive(true);
            }
        }
    }
}