using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public GameObject Player;
    public GameObject LevelFinishSequence;

    public LevelCompleteSequence sequence;
    public Timer timerscript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player.SetActive(false);
            LevelFinishSequence.SetActive(true);
            sequence.StartSequence();
            timerscript.FinishLevel();
        }
    }
}
