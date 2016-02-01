using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public GameObject MainMenu;
    public GameObject HelpMenu;

	public void StartGame()
    {
        SceneManager.LoadScene("main");
    }

    public void ShowHelp()
    {
        MainMenu.SetActive(false);
        HelpMenu.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        MainMenu.SetActive(true);
        HelpMenu.SetActive(false);
    }
}
