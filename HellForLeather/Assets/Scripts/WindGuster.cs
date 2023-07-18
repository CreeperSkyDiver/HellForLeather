using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindGuster : MonoBehaviour
{
    [SerializeField] float boostForce = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector2 boostPush = new Vector2(0f, boostForce);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(boostPush);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
