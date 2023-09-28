using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private GameObject cam;

    [SerializeField] private float parallaxEffect;

    private float xPosition;
    private float length;
    private float yPosition;
    private float width;

    private void Start()
    {
        cam = GameObject.Find("Main Camera");
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        width = GetComponent<SpriteRenderer>().bounds.size.y;
        xPosition = transform.position.x;
        yPosition = transform.position.y;
    }

    private void Update()
    {
        float distanceMoved = cam.transform.position.x * (1 - parallaxEffect);
        float distantoMove = cam.transform.position.x * parallaxEffect;
        float distanceMovedY = cam.transform.position.y * (1 - parallaxEffect);
        float distantoMoveY = cam.transform.position.y * parallaxEffect;

        transform.position = new Vector3(xPosition + distantoMove, yPosition + distantoMoveY);

        if (distanceMoved > xPosition + length)
        {
            xPosition = xPosition + length;
        }
        else if (distanceMoved < xPosition - length)
        {
            xPosition = xPosition - length;
        }
        if (distanceMovedY > yPosition + width)
        {
            yPosition = yPosition + width;
        }
        else if (distanceMovedY < yPosition - width)
        {
            yPosition = yPosition - width;
        }
    }
}
