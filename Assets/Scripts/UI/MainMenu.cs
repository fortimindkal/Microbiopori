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
        [SerializeField] public Sprite[] audioSprite = new Sprite[2];
        [SerializeField] public Image audioImage;

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
            audioImage.sprite = audioSprite[0];
        }

        // Call this function to start the game.
        public void StartGame()
        {
            // Load the game scene when the "Start" button is clicked.
            AudioManager.instance.Play("Tap");
            SceneManager.LoadScene(1);
        }

        // Call this function to quit the game.
        public void QuitGame()
        {
            // Quit the application if running in standalone build (e.g., Windows, macOS).
            AudioManager.instance.Play("Tap");
            Application.Quit();
        }

        public void CreditsGame()
        {
            if (!creditsUI.activeSelf)
            {
                AudioManager.instance.Play("PopUp");
                creditsUI.SetActive(true);
            }
            else
            {
                AudioManager.instance.Play("Tap");
                creditsUI.SetActive(false);
            }
        }

        public void GlosariumGame()
        {
            if (!glosariumUI.activeSelf)
            {
                AudioManager.instance.Play("PopUp");
                glosariumUI.SetActive(true);
                UpdateGlosariumDisplay();
            }
            else
            {
                AudioManager.instance.Play("Tap");
                glosariumUI.SetActive(false);
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
