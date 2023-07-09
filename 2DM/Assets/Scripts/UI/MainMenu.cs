using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject creditsUI;
    [SerializeField] GameObject tutorialUI;
    [SerializeField] GameObject mainMenuUI;
    public void StartGame()
    {
        SceneManager.LoadScene("DragToRoom");
    }

    public void ShowCredits()
    {
        creditsUI.SetActive(true);
        mainMenuUI.SetActive(false);
    }

    public void ShowTutorial()
    {
        tutorialUI.SetActive(true);
        mainMenuUI.SetActive(false);
    }

    public void BackToMainMenu()
    {
        creditsUI.SetActive(false);
        tutorialUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
