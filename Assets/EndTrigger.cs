using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameMaster gm;

    public void OnTriggerEnter2D(Collider2D other)
    {
        gm.LevelCompleted();
    }
}