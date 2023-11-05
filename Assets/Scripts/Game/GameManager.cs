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
        [SerializeField] private GameObject pauseMenuUI;
        [SerializeField] private GameObject glosariumMenuUI;
        [SerializeField] private Text scoreText;
        [SerializeField] private Text resultScoreText;

        [SerializeField] private Sprite[] glosariumImage;
        [SerializeField] private string[] glosariumText;
        [SerializeField] private Image glosariumImageDisplay;
        [SerializeField] private Text glosariumTextDisplay;
        [SerializeField] private Button nextPageButton;
        [SerializeField] private Button prevPageButton;

        public GameState state;
        private GameState previousState;

        private int currentPage = 0;

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
        }

        // Start is called before the first frame update
        void Start()
        {
            InitializeGame();

            if (state == GameState.Playing)
            {
                InvokeRepeating("AddScorePeriodically", 0f, 0.1f);
            }
        }

        // Update is called once per frame
        void Update()
        {
            //UpdateScore();
        }

        private void AddScorePeriodically()
        {
            if (state == GameState.Playing)
            {
                AddScore(1);
            }
        }

        void InitializeGame()
        {
            state = GameState.Playing;
            gameScore = 0;
            scoreText.text = gameScore.ToString();
            Time.timeScale = 1;
        }

        void UpdateScore()
        {
            if (scoreText != null)
            {
                scoreText.text = gameScore.ToString();
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
                state = GameState.GameOver;
                ShowGameOverUI();
                CancelInvoke("AddScorePeriodically"); // Stop adding score when the game is over.
                Time.timeScale = 0;
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
            AudioManager.instance.Play("Tap");
            SceneManager.LoadScene(0);
        }

        public void RetryButton()
        {
            AudioManager.instance.Play("Tap");
            SceneManager.LoadScene(1);
        }

        public void PauseButton()
        {
            if (state == GameState.Playing)
            {
                AudioManager.instance.Play("PopUp");
                previousState = state;
                state = GameState.Paused;
                Time.timeScale = 0;
                pauseMenuUI.SetActive(true);
            }
            else
            {
                AudioManager.instance.Play("Tap");
                state = previousState;
                Time.timeScale = 1;
                pauseMenuUI.SetActive(false);
            }
        }

        public void GlosariumButton()
        {
            if(!glosariumMenuUI.activeSelf)
            {
                AudioManager.instance.Play("PopUp");
                glosariumMenuUI.SetActive(true);
                UpdateGlosariumDisplay();
            }
            else
            {
                AudioManager.instance.Play("Tap");
                glosariumMenuUI.SetActive(false);
                UpdateGlosariumDisplay();
            }
        }

        public void NextPage()
        {
            AudioManager.instance.Play("Tap");
            currentPage++;
            UpdateGlosariumDisplay();
        }

        public void PrevPage()
        {
            AudioManager.instance.Play("Tap");
            currentPage--;
            UpdateGlosariumDisplay();
        }

        private void UpdateGlosariumDisplay()
        {
            if (currentPage == 0)
            {
                currentPage = 0;
                prevPageButton.interactable = false;
            }
            else
            {
                prevPageButton.interactable = true;
            }

            if (currentPage >= glosariumImage.Length - 1)
            {
                currentPage = glosariumImage.Length - 1;
                nextPageButton.interactable = false;
            }
            else
            {
                nextPageButton.interactable = true;
            }

            glosariumImageDisplay.sprite = glosariumImage[currentPage];
            glosariumTextDisplay.text = glosariumText[currentPage];
        }
    }
}

public enum GameState
{
    Playing,
    GameOver,
    Paused
}