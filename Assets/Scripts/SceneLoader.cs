using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   
    // Start is called before the first frame update

    public void ReloadGAme()
    {
        int currentScreen = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScreen);
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void NextGame()
    {
        int currentScreen = SceneManager.GetActiveScene().buildIndex;
        int  nextScreen = currentScreen + 1;
        if (nextScreen == SceneManager.sceneCountInBuildSettings)
        {
            nextScreen = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        SceneManager.LoadScene(nextScreen);
        Time.timeScale = 1;
    }
    public void GoToMAinMenu()
    {
        SceneManager.LoadScene(0);
    }


    public void Instruct()
    {
        SceneManager.LoadScene(3);
    }
    public void Level1()
    {
        SceneManager.LoadScene(4);
    }
    public void Level2()
    {
        SceneManager.LoadScene(5);
    }
    public void Level3()
    {
        SceneManager.LoadScene(6);
    }
    public void Level4()
    {
        SceneManager.LoadScene(7);
    }
    public void Level5()
    {
        SceneManager.LoadScene(8);
    }
    public void Level6()
    {
        SceneManager.LoadScene(9);
    }
    public void About()
    {
        SceneManager.LoadScene(1);
    }
    
   /* private void OnCollisionEnter(Collision collision)
    {
        int currentScreen = SceneManager.GetActiveScene().buildIndex;
        if (collision.gameObject.tag == "Finish")
        {
            int nextScreen = currentScreen + 1;
            if (nextScreen == SceneManager.sceneCountInBuildSettings)
            {
                nextScreen = 0;
            }
            SceneManager.LoadScene(nextScreen);
            //int currentScreen = SceneManager.GetActiveScene().buildIndex;
        }
    }*/
}
