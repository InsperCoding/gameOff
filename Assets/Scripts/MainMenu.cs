using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Room0");
    }

    public void QuitGame()
    {
        Debug.Log("Quit fui");
        Application.Quit();
    }
}
