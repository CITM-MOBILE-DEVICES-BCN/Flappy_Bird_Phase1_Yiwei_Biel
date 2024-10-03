using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class BackGroundManager : MonoBehaviour
{
    public GameObject BackGround1;
    public GameObject BackGround2;
    [SerializeField] private float scrollSpeed = -2.0f;
    private float tileSizeX = 8.0f;
    [SerializeField] private Vector3 startPosition1;
    [SerializeField] private Vector3 startPosition2;

    private void Start()
    {
        
    }

    private void Update()
    {
        InfiniteScroll();

    }

    private void InfiniteScroll()
    {
        // Move both backgrounds to the left
        BackGround1.transform.position += Vector3.right * scrollSpeed * Time.deltaTime;
        BackGround2.transform.position += Vector3.right * scrollSpeed * Time.deltaTime;

        // Check if the first background has moved completely out of view
        if (BackGround1.transform.position.x < -tileSizeX)
        {
            BackGround1.transform.position = startPosition2 + Vector3.right * tileSizeX;
            SwitchBackgrounds();
        }

        // Check if the second background has moved completely out of view
        else if (BackGround2.transform.position.x < -tileSizeX)
        {
            BackGround2.transform.position = startPosition1 + Vector3.right * tileSizeX;
            SwitchBackgrounds();
        }

    }

    private void SwitchBackgrounds()
    {
        GameObject temp = BackGround1;
        BackGround1 = BackGround2;
        BackGround2 = temp;
        Vector3 tempPos = startPosition1;
        startPosition1 = startPosition2;
        startPosition2 = tempPos;
    }

}
