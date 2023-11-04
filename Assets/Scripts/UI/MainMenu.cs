using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Microbiopori
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject mainmenuUI;
        [SerializeField] private GameObject glosariumUI;
        [SerializeField] private GameObject creditsUI;

        [SerializeField] private Sprite[] glosariumImage;
        [SerializeField] private string[] glosariumText;
        [SerializeField] private Image glosariumImageDisplay;
        [SerializeField] private Text glosariumTextDisplay;
        [SerializeField] private Button nextPageButton;
        [SerializeField] private Button prevPageButton;

        public string gameSceneName = "GameScene"; // The name of the scene to load when starting the game.

        private int currentPage = 0;

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
            SceneManager.LoadScene(1);
        }

        // Call this function to quit the game.
        public void QuitGame()
        {
            // Quit the application if running in standalone build (e.g., Windows, macOS).
            Application.Quit();
        }

        public void CreditsGame()
        {
            if (!creditsUI.activeSelf)
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
                UpdateGlosariumDisplay();
            }
            else
            {
                glosariumUI.SetActive(false);
                mainmenuUI.SetActive(true);
            }
        }

        public void NextPage()
        {
            currentPage++;
            UpdateGlosariumDisplay();
        }

        public void PrevPage()
        {
            currentPage--;
            UpdateGlosariumDisplay();
        }

        private void UpdateGlosariumDisplay()
        {
            if (currentPage < 0)
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
