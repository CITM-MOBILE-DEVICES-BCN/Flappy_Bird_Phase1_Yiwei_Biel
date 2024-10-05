using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{ 
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic; 
    
    public bool birdIsAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //if the player presses the space key
        if(Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;

            AudioManager.instance.PlaySoundFXClip(AudioManager.instance.wing, transform, 0.5f);
        }

        // press ESC to quit the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.GameOver();
        birdIsAlive = false;
        AudioManager.instance.PlaySoundFXClip(AudioManager.instance.hit, transform, 0.8f);
    }

    //if the player is out of bounds, the game is over
    private void OnBecameInvisible()
    {
        logic.GameOver();
        birdIsAlive = false;
        AudioManager.instance.PlaySoundFXClip(AudioManager.instance.die, transform, 1.0f);
    }
}

