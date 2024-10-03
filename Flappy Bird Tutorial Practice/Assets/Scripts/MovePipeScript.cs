using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipeScript : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float destroyXPos = -13;
    // Start is called before the first frame update
    void Start()
    {
        
    }
        
    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        if ((transform.position.x < destroyXPos))
        {
            Debug.Log("Pipe Destroyed!");
            Destroy(gameObject);
        }
    }
}
