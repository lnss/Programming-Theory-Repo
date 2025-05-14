using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;
    //public TextMeshProUGUI gameOverText;
    //public TextMeshProUGUI timeText;
    public GameObject titleScreen;
    public GameObject gamePlayScreen;
    public GameObject gameOverScreen;
    //public Button restartButton;

    //public List<GameObject> targetPrefabs;

    public static int resultNum = 0;
    public static int goalNum = 60;
    public static int cardSelectedNum = 0;
    public static int score;
    public static int life;
    //private int timeRemain;
    //private int timeMax = 60;
    //private float spawnRate = 1.5f;

    public static bool isGameActive = false;

    //private float spaceBetweenSquares = 2.5f;
    //private float minValueX = -3.75f; //  x value of the center of the left-most square
    //private float minValueY = -3.75f; //  y value of the center of the bottom-most square

    // Start the game, remove title screen, reset score, and adjust spawnRate based on difficulty button clicked
    public void StartGame()
    {
        isGameActive = true;
        titleScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        gamePlayScreen.SetActive(true);

        score = 0;
        UpdateScore(score);
        life = 3;
        UpdateLife(life);
        //timeRemain = timeMax;

    }

    private void Update()
    {
        if (isGameActive)
        {
            if (life != 0)
            {
                UpdateScore(score);
                UpdateLife(life);
            }
            else
            {
                GameOver();
            }
        }
        
    }

    // Generate new group of cards.
    //void GenerateCards()
    //{
    //    while (isGameActive)
    //    {
    //        int index = Random.Range(0, targetPrefabs.Count);

    //        if (isGameActive)
    //        {
    //            Instantiate(targetPrefabs[index], RandomSpawnPosition(), targetPrefabs[index].transform.rotation);
    //        }

    //    }
    //}



    //// Generates random square index from 0 to 3, which determines which square the target will appear in
    //int RandomSquareIndex()
    //{
    //    return Random.Range(0, 4);
    //}

    // Update score with value from target clicked
    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateLife(int life)
    {
        lifeText.text = "Life: " + life;
    }

    //IEnumerator TimeCountdown()
    //{
    //    while (isGameActive)
    //    {
    //        for (int i = 1; i < timeMax + 1; i++)
    //        {
    //            yield return new WaitForSeconds(1);
    //            timeRemain = timeMax - i;
    //            UpdateTime(timeRemain);
    //            if (timeRemain == 0)
    //            {
    //                GameOver();
    //            }
    //        }
    //    }

    //}

    //// Update remain time 
    //public void UpdateTime(int time)
    //{
    //    timeText.text = "Time: " + time;
    //}


    // Stop game, bring up game over text and restart button
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        isGameActive = false;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
