using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterZone : MonoBehaviour
{
    public PlayerData DataPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DataPlayer.InWater = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DataPlayer.InWater = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DataPlayer.InWater = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
