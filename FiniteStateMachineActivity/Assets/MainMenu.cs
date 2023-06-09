using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void SwitchScene(string _sceneIndex)
    {
        SceneManager.LoadScene(_sceneIndex);
    }

    public void SideLoadScene(string _sceneIndex)
    {
        SceneManager.LoadSceneAsync(_sceneIndex, LoadSceneMode.Additive);
    }


    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Player has quit the game.");
    }

}
