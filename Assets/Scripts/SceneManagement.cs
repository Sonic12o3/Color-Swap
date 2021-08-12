using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    //Loads the main game scene
    public void StartTheGame()
    {
        SceneManager.LoadScene(0);
    }

    public void BackToMain()
    {
        SceneManager.LoadScene(1);
    }
}
