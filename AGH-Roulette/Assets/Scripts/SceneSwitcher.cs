using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void BoardScene()
    {
        SceneManager.LoadScene("Gamescene_Main");
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("Gamescene_Menu");
    }
}

