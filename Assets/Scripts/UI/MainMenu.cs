using UnityEngine;
using UnityEngine.SceneManagement;

namespace Microbiopori
{
    public class MainMenu : MonoBehaviour
    {
        public string gameSceneName = "GameScene"; // The name of the scene to load when starting the game.

        // Call this function to start the game.
        public void StartGame()
        {
            // Load the game scene when the "Start" button is clicked.
            SceneManager.LoadScene(gameSceneName);
        }

        // Call this function to quit the game.
        public void QuitGame()
        {
            // Quit the application if running in standalone build (e.g., Windows, macOS).
            Application.Quit();
        }
    }
}
