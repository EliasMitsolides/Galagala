﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SooperBoolet : MonoBehaviour
{
    public Rigidbody2D sooperProjectile;

    public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        sooperProjectile = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        sooperProjectile.velocity = new Vector2(0, 1) * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D collidingWith)
    {
        if (collidingWith.gameObject.name == "Enemy Laser(Clone)" ||
            collidingWith.gameObject.name == "Boss Left Laser(Clone)" ||
            collidingWith.gameObject.name == "Boss Right Laser(Clone)")
        {
            Object.Destroy(collidingWith.gameObject);
        }
        //determine which enemy was hit and adjust score accordingly, higher score because powerup was used

        if (collidingWith.gameObject.name == "Green Enemy" || collidingWith.gameObject.name == "Crawlie Enemy")
        {
            collidingWith.gameObject.SetActive(false);
            WaveSpawner.Instance.enemyCounter -= 1;
            if (collidingWith.gameObject.name == "Green Enemy")
            {
                Player.Instance.score += 200;
                Player.Instance.scoreOnScreen.text = Player.Instance.score.ToString();
            }
            else // it was Crawlie Enemy
            {
                Player.Instance.score += 300;
                Player.Instance.scoreOnScreen.text = Player.Instance.score.ToString();
            }
        }
        if (collidingWith.gameObject.name == "Left Boss Enemy")
        {
            WaveSpawner.Instance.leftBossHealth -= 1;
            if (WaveSpawner.Instance.leftBossHealth == 0)
            {
                collidingWith.gameObject.SetActive(false);
                WaveSpawner.Instance.enemyCounter -= 1;

                Player.Instance.score += 1666;
                Player.Instance.scoreOnScreen.text = Player.Instance.score.ToString();
            }
            //Object.Destroy(this.gameObject);
        }

        if (collidingWith.gameObject.name == "Right Boss Enemy")
        {
            WaveSpawner.Instance.rightBossHealth -= 1;
            if (WaveSpawner.Instance.rightBossHealth == 0)
            {
                collidingWith.gameObject.SetActive(false);
                WaveSpawner.Instance.enemyCounter -= 1;

                Player.Instance.score += 1666;
                Player.Instance.scoreOnScreen.text = Player.Instance.score.ToString();
            }
            //Object.Destroy(this.gameObject);
        }

        if (collidingWith.gameObject.name == "Top")
        {
            Object.Destroy(this.gameObject);
        }
    }
}
