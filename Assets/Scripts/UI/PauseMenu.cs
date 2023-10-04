using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Reference to the pause menu UI panel.

    private bool isPaused = false;

    private void Start()
    {
        ResumeGame(); // Ensure the game is not paused when it starts.
    }

    private void Update()
    {
        // Check for player input to toggle the pause menu.
        if (Input.GetKeyDown(KeyCode.Escape)) // You can customize the key as needed.
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Resume game time.
        isPaused = false;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Pause game time.
        isPaused = true;
    }

    public void RestartGame()
    {
        // Add logic to restart the game (e.g., reloading the scene).
        // You can use SceneManager.LoadScene to load the current scene again.
    }

    public void QuitGame()
    {
        Application.Quit(); // Close the application (for standalone builds).
    }
}
