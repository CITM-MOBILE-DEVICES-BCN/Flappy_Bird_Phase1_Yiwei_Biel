using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = -2f;
    [SerializeField] private float tileSizeX = 20.0f;
    [SerializeField] private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        MoveBackgroundLoop();
    }

    private void MoveBackgroundLoop()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeX);
        transform.position = startPosition + Vector3.right * newPosition;
    }
}


