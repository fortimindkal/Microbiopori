using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Microbiopori
{ 
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager Instance => _instance;

        [Header("Game Parameters")]
        [SerializeField] private int gameScore;
        [SerializeField] private bool isGameOver = false;

        [Header("Game User-Interface")]
        [SerializeField] private GameObject gameOverUI;
        [SerializeField] private Text scoreText;
        [SerializeField] private Text resultScoreText;

        private void Awake()
        {
            // Implementing the Singleton pattern.
            if (_instance == null)
            {
                _instance = this;
            }
            else if (_instance != this)
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
            if (scoreText != null)
            {
                scoreText.text = "Score: " + gameScore.ToString();
            }
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
                resultScoreText.text = scoreText.text;
            }
        }

        public void HomeButton()
        {
            SceneManager.LoadScene(0);
        }

        public void RetryButton()
        {
            SceneManager.LoadScene(1);
        }
    }
}