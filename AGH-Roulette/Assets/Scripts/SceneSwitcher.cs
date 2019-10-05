using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

//Loads each scene
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

    public void TutorialScene()
    {
        SceneManager.LoadScene("GameScene_Tutorial");
    }

    //Used to create the files if the game is opening for the first time, since these files are read to first
    private void Start()
    {
        string path = "";
        StreamWriter writer;

        for (int i = 0; i < 2; i ++)
        {
            if (i == 0)
            {
                path = "/statsFile.txt";
            }

            else if (i == 1)
            {
                path = "/balandamount.txt";
            }

            if (!File.Exists(Application.persistentDataPath + path))
            {
                writer = new StreamWriter(Application.persistentDataPath + path);

                if (i == 1)
                {
                    //Sets the default Coins to 500
                    writer.WriteLine("Coins: 500");
                }

                writer.Close();
            }
        }



    }
}

