using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;

    public bool gameHasEnded = false;
    public Transform playerPrefab;
    public Transform spawnPoint;
    public int spawnDelay = 2;
    public int restartDelay = 1;

    private void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        }
    }

    public IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public static void KillPlayer(Player player)
    {
        Destroy(player.gameObject);
        gm.StartCoroutine(gm.RespawnPlayer());
    }

    public void LevelCompleted()
    {
        Debug.Log("LEVEL COMPLETED");

        RestartGame();
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");

        if (gameHasEnded == false)
        {
            gameHasEnded = true;

            RestartGame();
        }
    }

    private void RestartGame()
    {
        Debug.Log("RESTART CURRENT SCENE");

        gameHasEnded = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}