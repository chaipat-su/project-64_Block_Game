using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainac : MonoBehaviour
{
    public void start_game()
    {
        SceneManager.LoadScene(12);
    }

    public void back_mainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void option()
    {
        SceneManager.LoadScene(1);
    }

    public void setvoid()
    {
        SceneManager.LoadScene(2);
    }

    public void tutorial()
    {
        SceneManager.LoadScene(3);
    }

    public void credit()
    {
        SceneManager.LoadScene(9);
    }

    public void backop()
    {
        SceneManager.LoadScene(2);
    }

    public void quit_game()
    {
        Application.Quit();
    }
}
