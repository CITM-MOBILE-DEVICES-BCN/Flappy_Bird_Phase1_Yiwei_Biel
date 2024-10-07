using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class BackGroundManager : MonoBehaviour
{
    public GameObject backGround1;
    public GameObject backGround2;

    public GameObject[] backgrounds;
    private Vector2 resetPosition;

    [SerializeField] private float scrollSpeed;
    private float tileSizeX = 8.0f;
    [SerializeField] private Vector3 startPosition1;
    [SerializeField] private Vector3 startPosition2;

    private void Start()
    {
        tileSizeX = backGround1.GetComponent<SpriteRenderer>().bounds.size.x;

        resetPosition = backgrounds[1].transform.position;

        startPosition1 = backGround1.transform.position;
        startPosition2 = backGround2.transform.position;
    }

    private void Update()
    {
        InfiniteScroll();

    }

    private void InfiniteScroll()
    {
        // Move both backgrounds to the left
        backGround1.transform.position += Vector3.right * scrollSpeed * Time.deltaTime;
        backGround2.transform.position += Vector3.right * scrollSpeed * Time.deltaTime;

        //foreach (GameObject background in backgrounds)
        //{
        //    background.transform.position += Vector3.right * scrollSpeed * Time.deltaTime;

        //    if (background.transform.position.x <= -19.71)
        //    {
        //        background.transform.position = resetPosition;

        //    }
        //}


        // Reposition BackGround1 if it has moved off screen
        if (backGround1.transform.position.x <= -tileSizeX)
        {
            backGround1.transform.position = new Vector3(
                backGround2.transform.position.x + tileSizeX,
                backGround1.transform.position.y,
                backGround1.transform.position.z
            );

            SwitchBackgrounds();
        }

        // Reposition BackGround2 if it has moved off screen
        else if (backGround2.transform.position.x <= -tileSizeX)
        {
            backGround2.transform.position = new Vector3(
                backGround1.transform.position.x + tileSizeX,
                backGround2.transform.position.y,
                backGround2.transform.position.z
            );
            SwitchBackgrounds();
        }



    }

    private void SwitchBackgrounds()
    {
        GameObject temp = backGround1;
        backGround1 = backGround2;
        backGround2 = temp;
        Vector3 tempPos = startPosition1;
        startPosition1 = startPosition2;
        startPosition2 = tempPos;
    }

}
