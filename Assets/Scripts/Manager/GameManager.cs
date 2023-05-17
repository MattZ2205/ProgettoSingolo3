using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameStatus
    {
        gameRunning,
        gamePaused,
        gameEnd,
        waitingForWave
    }
    public static GameStatus gameStatus;

    private void Update()
    {
        switch ((int)gameStatus)
        {
            case (int)GameStatus.gameRunning:
                Time.timeScale = 1;
                break;
            case (int)GameStatus.gamePaused:
                Time.timeScale = 0;
                break;
            case (int)GameStatus.gameEnd:
                Time.timeScale = 0;
                EndGame();
                break;
        }
    }

    void EndGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
