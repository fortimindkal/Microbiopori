using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void HomeButton()
    {
        SceneManager.LoadScene(0);
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(1);
    }
}
