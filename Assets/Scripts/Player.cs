using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //touch side of screen to move is universal
    // diff is double tap to dash or "jerk" the phone to either side
    public int whichControlScheme = 0;
    public float playerMoveSpeed = 10.0f;

    public Rigidbody2D player;
    // Start is called before the first frame update
    void Start()
    {
        //what game object this script is attached to will have it's rigid body comm with the script 
        player = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (touch.position.x < Screen.width / 2)
                        player.velocity = new Vector2(-1f * playerMoveSpeed, 0f);
                    if (touch.position.x > Screen.width / 2)
                        player.velocity = new Vector2(playerMoveSpeed, 0f);
                    break;

                case TouchPhase.Ended:
                    player.velocity = new Vector2(0f, 0f);
                    break;
            }
        }
    }


    void FixedUpdate()
    {
        //movePlayer ();
    }

    public void movePlayer ()
    {                               //horizontal key, left right   // vertical, up down key  
        player.velocity = new Vector2(Input.GetAxis("Horizontal") * playerMoveSpeed, Input.GetAxis("Vertical") * 0) ;
        //set Gravity Scale in this object's Rigidbody 2D to 0 so that it doesn't drop slowly
        //
        //player.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * playerMoveSpeed;
    }
}
