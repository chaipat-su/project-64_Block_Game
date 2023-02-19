using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainac : MonoBehaviour
{
    public void start_game()
    {
        SceneManager.LoadScene(1);
    }

    public void back_mainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void option()
    {
        SceneManager.LoadScene(2);
    }

    public void leave()
    {
        SceneManager.LoadScene(1);
    }

    public void tutorial()
    {
        SceneManager.LoadScene(5);
    }

    public void online()
    {
        SceneManager.LoadScene(3);
    }

    public void backop()
    {
        SceneManager.LoadScene(2);
    }

    public void tplay()
    {
        SceneManager.LoadScene(4);
    }

    public void quit_game()
    {
        Application.Quit();
    }
}
