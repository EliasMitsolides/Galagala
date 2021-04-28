using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAspectRatio : MonoBehaviour
{
    float height;

    float width; // basically height screen aspect ratio
    

    // Start is called before the first frame update
    void Start()
    {
        height = Camera.main.orthographicSize * 2;
        width = height * (Screen.width / Screen.height); // basically height screen aspect ratio
        transform.localScale = new Vector3(width, height, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
