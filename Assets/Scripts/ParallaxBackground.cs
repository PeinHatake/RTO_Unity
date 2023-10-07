using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private float parallaxEffect;
    
    private Transform cam;
    private float xPosition;
    private float yPosition;
    // private float width;
    // private float length;

    private void Awake()
    {
        cam = GameObject.Find("Main Camera").transform;
        // length = GetComponent<SpriteRenderer>().bounds.size.x;
        // width = GetComponent<SpriteRenderer>().bounds.size.y;
        var position = transform.position;
        xPosition = position.x;
        yPosition = position.y;
    }

    private void Update()
    {
        var position = cam.position;
        var distanceToMoveX = position.x * parallaxEffect;
        var distanceToMoveY = position.y * parallaxEffect;
        
        transform.position = new Vector3(xPosition + distanceToMoveX, yPosition + distanceToMoveY);
        
        //float distanceMovedY = cam.transform.position.y * (1 - parallaxEffect);
        //float distanceMoved = cam.transform.position.x * (1 - parallaxEffect);
        // if (distanceMoved > xPosition + length)
        // {
        //     xPosition += length;
        // }
        // else if (distanceMoved < xPosition - length)
        // {
        //     xPosition -= length;
        // }
        // if (distanceMovedY > yPosition + width)
        // {
        //     yPosition += width;
        // }
        // else if (distanceMovedY < yPosition - width)
        // {
        //     yPosition -= width;
        // }
    }
}
