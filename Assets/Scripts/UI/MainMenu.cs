using UnityEngine;
using UnityEngine.SceneManagement;

namespace Microbiopori
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject mainmenuUI;
        [SerializeField] private GameObject glosariumUI;
        [SerializeField] private GameObject creditsUI;

        public string gameSceneName = "GameScene"; // The name of the scene to load when starting the game.

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            mainmenuUI.SetActive(true);
            glosariumUI.SetActive(false);
            creditsUI.SetActive(false);
        }

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

        public void CreditsGame()
        {
            if(!creditsUI.activeSelf)
            {
                creditsUI.SetActive(true);
                mainmenuUI.SetActive(false);
            }
            else
            {
                creditsUI.SetActive(false);
                mainmenuUI.SetActive(true);
            }
        }

        public void GlosariumGame()
        {
            if (!glosariumUI.activeSelf)
            {
                glosariumUI.SetActive(true);
                mainmenuUI.SetActive(false);
            }
            else
            {
                glosariumUI.SetActive(false);
                mainmenuUI.SetActive(true);
            }
        }
    }
}
