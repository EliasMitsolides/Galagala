using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public Rigidbody2D enemy;
    public float moveSpeed = 7f;

    public bool onLeftSide = false;
    public bool changeDirection = false;
    public bool leftMoveToRight = true;
    public bool rightMoveToLeft = true;

    public bool started = false;

    public float changeDirectionTimer = 3.83f;
    public float currentTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        enemy = this.gameObject.GetComponent<Rigidbody2D>();
        if (this.transform.position.x < 0)
        {
            onLeftSide = true;
        }
        //else 
        //{
        //    left
        //}
    }

    // Update is called once per frame
    void Update()
    {
        moveBoss();
    }

    public void moveBoss()
    {
        currentTime += Time.deltaTime;

        if (onLeftSide && ((currentTime > changeDirectionTimer) || !started))
        {
            changeDirectionTimer += currentTime;
            if (leftMoveToRight)
            {
                enemy.velocity = new Vector2(1, 0)  * moveSpeed;
                leftMoveToRight = false;
            }
            else if (!leftMoveToRight)
            { 
                enemy.velocity = new Vector2(1, 0) * -1 * moveSpeed;
                leftMoveToRight = true;
            }
            
            changeDirectionTimer -= currentTime;
            currentTime = 0f;

            started = true;
        }

        else if (!onLeftSide && ((currentTime > changeDirectionTimer) || !started))
        {
            changeDirectionTimer += currentTime;
            if (!rightMoveToLeft)
            {
                enemy.velocity = new Vector2(1, 0) * moveSpeed;
                rightMoveToLeft = true;
            }
            else if (rightMoveToLeft)
            {
                enemy.velocity = new Vector2(1, 0) * -1 * moveSpeed;
                rightMoveToLeft = false;
            }

            changeDirectionTimer -= currentTime;
            currentTime = 0f;

            started = true;
        }

    }
}
