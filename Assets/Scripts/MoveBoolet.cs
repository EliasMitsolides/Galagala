using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoolet : MonoBehaviour
{
    public Rigidbody2D projectile;

    public float moveSpeed = 20.0f;


    // Start is called before the first frame update
    void Start()
    {
        projectile = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        projectile.velocity = new Vector2(0, 1) * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D collidingWith)
    {
        if (collidingWith.gameObject.name == "Green Enemy" || collidingWith.gameObject.name == "Crawlie Enemy") 
        {
            collidingWith.gameObject.SetActive(false);
            Object.Destroy(this.gameObject);
            WaveSpawner.Instance.enemyCounter -= 1;
        }

        if (collidingWith.gameObject.name == "Left Boss Enemy") 
        {
            WaveSpawner.Instance.leftBossHealth -= 1;
            if (WaveSpawner.Instance.leftBossHealth == 0)
            {
                collidingWith.gameObject.SetActive(false);
                WaveSpawner.Instance.enemyCounter -= 1;
            }
            Object.Destroy(this.gameObject);
        }

        if (collidingWith.gameObject.name == "Right Boss Enemy")
        {
            WaveSpawner.Instance.rightBossHealth -= 1;
            if (WaveSpawner.Instance.rightBossHealth == 0)
            {
                collidingWith.gameObject.SetActive(false);
                WaveSpawner.Instance.enemyCounter -= 1;
            }
            Object.Destroy(this.gameObject);
        }

        if (collidingWith.gameObject.name == "Top")
        {
            Object.Destroy(this.gameObject);
        }
    }

}
