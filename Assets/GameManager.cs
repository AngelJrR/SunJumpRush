using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text text;
    public int wave = 1;
    public int enemiesToKill = 1;
    public int enemiesKilled = 0;
    public bool waveStart = false;

    public bool bossKilled = false;
    public bool playerAlive = true;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject gameWinScreen;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Waves Until Boss " + wave;
        
        
        if(enemiesKilled == enemiesToKill)
        {
            //Debug.Log("Hello");
            enemiesKilled = 0;
            enemiesToKill += 2;
            wave++;
            waveStart = true;
            
        }

        if (playerAlive == false)
        {
            GameOver();
        }

        if (bossKilled == true)
        {
            WinGame();
        }


    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void WinGame()
    {
        gameWinScreen.SetActive(true);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(1); 
    }

    public void ContinueGame()
    {
        gameWinScreen.SetActive(false); 
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
