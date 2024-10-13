using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringDetectorScript : MonoBehaviour
{
    public GameStateScript logic;

    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<GameStateScript>();

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
            logic.addScore(1);

            audioManager.PlaySoundFXClip(audioManager.point, transform, 0.5f);
            
        }
        
    }
}
