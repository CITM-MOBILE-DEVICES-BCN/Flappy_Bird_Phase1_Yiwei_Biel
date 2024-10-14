using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{ 
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public GameStateScript state; 
    
    public bool birdIsAlive = true;
    private bool isGamePaused = false;
    // Start is called before the first frame update
    void Start()
    {
        state = GameObject.FindGameObjectWithTag("State").GetComponent<GameStateScript>();
        GameStateScript.OnGamePaused += HandlePause;
    }

    private void OnDestroy()
    {
        GameStateScript.OnGamePaused -= HandlePause;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGamePaused) return;


        //if the player presses the space key
        if(Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true && isGamePaused == false)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;

            AudioManager.instance.PlaySoundFXClip(AudioManager.instance.wing, transform, 0.5f);
        }

    }

    private void HandlePause(bool isPaused)
    {
        isGamePaused = isPaused;
        if(isGamePaused)
        {
            myRigidbody.velocity = Vector2.zero;
            myRigidbody.simulated = false;
        }
        else
        {
            myRigidbody.simulated = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        state.GameOver();
        birdIsAlive = false;
        AudioManager.instance.PlaySoundFXClip(AudioManager.instance.hit, transform, 0.8f);
    }

    //if the player is out of bounds, the game is over
    private void OnBecameInvisible()
    {
        if(state != null && birdIsAlive == true)
        {
            state.GameOver();
            birdIsAlive = false;
            AudioManager.instance.PlaySoundFXClip(AudioManager.instance.die, transform, 1.0f);
        }
    }
}

