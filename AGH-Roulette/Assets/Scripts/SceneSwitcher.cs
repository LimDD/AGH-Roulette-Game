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

    public void WheelScene()
    {
        SceneManager.LoadScene("Roulette_Wheel");
    }
}

