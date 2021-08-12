using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    //Loads the main game scene
    public void StartTheGame()
    {
        SceneManager.LoadScene(1);
    }

    public void BackToMain()
    {
        Debug.Log("WHY ISN'T THIS WORKING???");
        SceneManager.LoadScene(0);
    }
}
