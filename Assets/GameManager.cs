using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text text;
    public int wave = 1;
    public int enemiesToKill = 1;
    public int enemiesKilled = 0;
    public bool waveStart = false;
    public int BossWave = 5;
    public bool BossTime = false;
    public bool finale = false;
    public GameObject lose;
    public GameObject win;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Waves Until Boss: " + (BossWave);
        if (!finale)
        {
            if (BossWave >= 0)
            {
                if (enemiesKilled == enemiesToKill)
                {
                    //Debug.Log("Hello");
                    enemiesKilled = 0;
                    enemiesToKill += 2;
                    wave++;
                    waveStart = true;
                    BossWave--;
                }
            }
            else
            {
                //finale = true;
                BossTime = true;
                waveStart = false;
            }
        }
        /*
        if (enemiesKilled == enemiesToKill)
        {
            //Debug.Log("Hello");
            enemiesKilled = 0;
            enemiesToKill += 2;
            wave++;
            waveStart = true;

        }
        */
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");

        }
    }


    public void Win()
    {
        win.SetActive(true);
    }

    public void Lose()
    {
        lose.SetActive(true);
    }

    public void reBegin()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;

    }

    public void menu()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
