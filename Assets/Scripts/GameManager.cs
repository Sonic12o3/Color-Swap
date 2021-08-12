using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameObject player;
    private  static GameObject gameOverMenu;
    private static GameObject gameWinMenu;



    private void Awake()
    {
        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameOverMenu = GameObject.Find("Canvas").transform.Find("Game Over Menu").gameObject;
        gameWinMenu = GameObject.Find("Canvas").transform.Find("Win Game Menu").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void gameOver()
    {
        Destroy(player);
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
        
    }

    public static void winGame()
    {
        gameWinMenu.SetActive(true);
        Time.timeScale = 0;
    }
   
}
