using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float worldWidth = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    // Update is called once per frame
    void Update()
    {

        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (FindObjectOfType<GameStatus>().isAutoPlayEnabled() == true)
        {
            return FindObjectOfType<Ball>().transform.position.x;
        }
        else
        {
            float currentPos = Input.mousePosition.x / Screen.width * worldWidth;
            return currentPos;
        }
    }
}
