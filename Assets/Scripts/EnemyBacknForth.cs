using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBacknForth : MonoBehaviour
{

    public Rigidbody2D enemy;
    public float moveSpeed = 4f;

    public bool changeDirection = false;
    public bool moveRight = false;

    public bool started = false;

    public float changeDirectionTimer = 1.8f;
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
        //if (changeDirection == true){
        //    enemy.velocity = new Vector2(1, 0) * -1 * moveSpeed;
        //}

        //else if (changeDirection ==false){
        //    enemy.velocity = new Vector2(1, 0) * moveSpeed;
        //}
        currentTime += Time.deltaTime;

        if (moveRight == false && ((currentTime > changeDirectionTimer) || !started) ) 
        {
            changeDirectionTimer += currentTime;
            enemy.velocity = new Vector2(1, 0) * -1 * moveSpeed;
            changeDirectionTimer -= currentTime;

            currentTime = 0f;
            moveRight = true;

            started = true;
        }

        else if (moveRight == true && currentTime > changeDirectionTimer)
        {
            changeDirectionTimer += currentTime;
            enemy.velocity = new Vector2(1, 0) * moveSpeed;
            changeDirectionTimer -= currentTime;
            
            currentTime = 0f;
            moveRight = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collideWall)
    {
        if (collideWall.gameObject.name == "RightWall"){
            Debug.Log("Enemy bumped into RightWall...move left now");
            changeDirection = !changeDirection;
        }
        if (collideWall.gameObject.name == "LeftWall"){
            Debug.Log("Enemy bumped into LeftWall...move right now");
            changeDirection = !changeDirection;
        }
    }

}
