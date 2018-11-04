using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        gameHasEnded = false;

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
        // EndGame();
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Restart();
        }
    }

    private void Restart()
    {
        Debug.Log("RESTART CURRENT SCENE");

        // TODO: Restart the current scene
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name)
    }
}