using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [System.Serializable]
    public class PlayerStats
    {
        public int Health = 100;
    }

    public int fallBoundary = -20;
    public PlayerStats playerStats = new PlayerStats();

    private void Start()
    {
        CameraFollow.FindPlayer();
    }

    private void Update()
    {
        if (transform.position.y <= fallBoundary)
        {
            DamagePlayer(Mathf.FloorToInt(Mathf.Infinity));
        }
    }

    public void DamagePlayer(int damage)
    {
        playerStats.Health -= damage;

        if (playerStats.Health <= 0)
        {
            GameMaster.KillPlayer(this);
        }
    }
}