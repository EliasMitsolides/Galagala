using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlieMovement : MonoBehaviour
{
    public Rigidbody2D enemy;
    public float verticalSpeed = 3f;
    public float horizontalSpeed = 6f;
    public float speedLength = 10f; //10 is a placeholder

    // I'll wanna cycle through these
    public bool moveDown = true;
    public bool sweepFloor = false;
    public bool sweepBackToSide = false;
    public bool moveUp = false;
    public bool stayUp = false;

    public bool started = false;

    public float stayUpTimer = 1f;
    public float moveDownTimer = 2.66f; //for moving down to floor or back up to spawn
    public float sweepFloorTimer = 2.3f;
    public float currentTime = 0f;


    // Start is called before the first frame update
    void Start()
    {
        enemy = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveEnemy();
    }

    public void moveEnemy()
    {
        currentTime += Time.deltaTime;

        if (started == false || (moveDown && currentTime > stayUpTimer))
        {
            stayUpTimer += currentTime;
            enemy.velocity = new Vector2(0, 1) * -1 * verticalSpeed;
            stayUpTimer -= currentTime;

            currentTime = 0;
            moveDown = false;
            sweepFloor = true;
            started = true;
        }

        else if (sweepFloor && (currentTime > moveDownTimer))
        {
            Debug.Log("got hereeeeee");
            moveDownTimer += currentTime;

            if (this.transform.position.x < 0) //on left side....so sweep right
            {
                enemy.velocity = new Vector2(1, 0) * horizontalSpeed;
                moveDownTimer -= currentTime;

            }

            else if (this.transform.position.x > 0) //on right side....so sweep left
            {
                enemy.velocity = new Vector2(1, 0) * -1 * horizontalSpeed;
                moveDownTimer -= currentTime;
            }

            currentTime = 0f;
            sweepFloor = false;
            sweepBackToSide = true;
        }

        else if (sweepBackToSide && (currentTime > sweepFloorTimer))
        {
            sweepFloorTimer += currentTime;

            if (this.transform.position.x < 0) //on left side and had swept right...sweep back to left edge
            {
                enemy.velocity = new Vector2(1, 0) * -1 * horizontalSpeed;
                sweepFloorTimer -= currentTime;

            }

            else if (this.transform.position.x > 0) //on right side and had swept left...sweep back to right edge
            {
                enemy.velocity = new Vector2(1, 0) * horizontalSpeed;
                sweepFloorTimer -= currentTime;
            }

            currentTime = 0f;
            sweepBackToSide = false;
            moveUp = true;
        }

        else if (moveUp && (currentTime > sweepFloorTimer) ) //wait however long it was that the crawlies swept back to the side, then go up
        {
            sweepFloorTimer += currentTime;
            enemy.velocity = new Vector2(0, 1) * verticalSpeed;
            sweepFloorTimer -= currentTime;

            currentTime = 0;
            moveUp = false;
            stayUp = true;
            //moveDown = true;
        } 
        else if (stayUp && (currentTime > moveDownTimer))
        {
            sweepFloorTimer += currentTime;
            enemy.velocity = new Vector2(0, 0);
            sweepFloorTimer -= currentTime;
            currentTime = 0;
            stayUp = false;
            moveDown = true;

        }
    }

}
