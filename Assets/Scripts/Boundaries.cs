using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    public Vector2 screenBounds;
    public float objectWidth;
    public float objectHeight;

    public float screenSizeWidth;
    public float screenSizeHeight;

    public Vector3 ourThing;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3
             (Screen.width, Screen.height, Camera.main.transform.position.z)
             );
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y/2;
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x/2;

        //ourThing = Camera.main.WorldToViewportPoint(transform.position);
        

        //screenSizeHeight = Screen
    }

    // LateUpdate is called once per frame, after all Updates have finished, want to catch and clamp
    //    once/after player is about to leave bounds...consistent order
    void LateUpdate()
    {
        ourThing = transform.position;

        float distance = transform.position.z - Camera.main.transform.position.z;

        float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)).x + objectWidth;
        float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance)).x - objectWidth;

        ourThing.x = Mathf.Clamp(ourThing.x, leftBorder, rightBorder);
        transform.position = ourThing;
        //Debug.Log(ourThing.x);
        //Vector3 clampedPOS = transform.position;
        //Debug.Log(screenBounds.x);
        //Debug.Log(ourThing.x);

        // \/\/\/ NOTE: uncomment if I don't stick with physics walls
        //Vector3 clampedPOS = ourThing;
        //                    //    \/to clamp\/  \/min,negative\/ \/min,positive\/
        //clampedPOS.x = Mathf.Clamp(ourThing.x, -1 * screenBounds.x + objectWidth, screenBounds.x - objectWidth);
        //clampedPOS.y = Mathf.Clamp(ourThing.y, -1 * screenBounds.y + objectHeight, screenBounds.y - objectHeight);

        //transform.position = clampedPOS;

        // /\/\/\ NOTE: uncomment if I don't stick with physics walls


    }
}
