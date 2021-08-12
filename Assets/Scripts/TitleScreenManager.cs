using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject credits;

    public void ShowCredits()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }

    public void ShowMain()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
    }
}
