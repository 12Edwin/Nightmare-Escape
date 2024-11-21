using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Scene1");
        print("Entro a Scene1");
    }

    public void Quit() 
    {
        Application.Quit();
    }

}
