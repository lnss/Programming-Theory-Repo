using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI lifeText;

    public GameObject titleScreen;
    public GameObject gamePlayScreen;
    public GameObject gameOverScreen;
    public GameObject levelCompletedScreen;
    public GameObject cardGroupPrefab;
    public GameObject originalCardGroup;
    
    public static int resultNum = 0;
    public static int goalNum = 10;
    public static List<GameObject> cardSelected = new List<GameObject>(2);

    public static int score;
    public static int life;

    private int timeRemain;
    private int timeMax = 30;
    
    private bool isGameActive = false;
    private int cardNum;

    
    // Start the game, remove title screen, reset score, and adjust spawnRate based on difficulty button clicked
    public void StartGame()
    {
        isGameActive = true;
        titleScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        levelCompletedScreen.SetActive(false);
        gamePlayScreen.SetActive(true);

        score = 0;
        UpdateScore(score);
        life = 3;
        UpdateLife(life);
        timeRemain = timeMax;
        StartCoroutine(TimeCountdown());
    }

    private void Update()
    {
        if (isGameActive)
        {
            if (life != 0)
            {
                UpdateScore(score);
                UpdateLife(life);
                cardNum = GameObject.FindGameObjectsWithTag("NotSelected").Length;
                if (cardNum == 0)
                {
                    LevelCompleted();
                }
            }
            else
            {
                GameOver();
            }
        }
        
    }

    void SpawnCardGroup()
    {
        GameObject newCardGroup = Instantiate(cardGroupPrefab, originalCardGroup.transform.position, cardGroupPrefab.transform.rotation) as GameObject;
        newCardGroup.transform.SetParent(gamePlayScreen.transform);
    }

    // Update score with value from target clicked
    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateLife(int life)
    {
        lifeText.text = "Life: " + life;
    }

    IEnumerator TimeCountdown()
    {
        while (isGameActive)
        {
            for (int i = 1; i < timeMax + 1; i++)
            {
                yield return new WaitForSeconds(1);
                timeRemain = timeMax - i;
                UpdateTime(timeRemain);
                if (timeRemain == 0)
                {
                    GameOver();
                }
            }
        }

    }

    // Update remain time 
    public void UpdateTime(int time)
    {
        timeText.text = "Time: " + time;
    }

    public void RefreshCardGroup()
    {
        for(int i = 0; i< cardNum; i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("NotSelected")[i]);
        }
        SpawnCardGroup();
        life--;
    }

    // Stop game, bring up game over text and restart button
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        gamePlayScreen.SetActive(false);
        isGameActive = false;
    }

    public void LevelCompleted()
    {
        levelCompletedScreen.SetActive(true);
        gamePlayScreen.SetActive(false);
        isGameActive = false;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
