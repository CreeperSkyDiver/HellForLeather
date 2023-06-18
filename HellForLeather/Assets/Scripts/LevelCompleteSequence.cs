using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteSequence : MonoBehaviour
{
    public GameObject LevelComplete;

    // Start is called before the first frame update
    void Start()
    {
        LevelComplete.SetActive(false);
    }

    public void StartSequence()
    {

    }
}
