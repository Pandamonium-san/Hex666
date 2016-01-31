using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public GameObject MainMenu;
    public GameObject HelpMenu;

	public void StartGame()
    {
        Application.LoadLevel("main");
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
