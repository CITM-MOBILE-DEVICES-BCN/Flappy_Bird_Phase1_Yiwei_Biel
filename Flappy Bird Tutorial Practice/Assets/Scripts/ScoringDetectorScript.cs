using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringDetectorScript : MonoBehaviour
{
    public GameStateScript state;

    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        state = GameObject.FindGameObjectWithTag("State").GetComponent<GameStateScript>();

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            state.addScore(1);

            audioManager.PlaySoundFXClip(audioManager.point, transform, 0.5f);
            
        }
        
    }
}
