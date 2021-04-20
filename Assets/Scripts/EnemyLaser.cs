using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public Rigidbody2D projectile;

    public float moveSpeed = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        projectile = this.gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        projectile.velocity = new Vector2(0, -1) * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D collidingWith)
    {
        if (collidingWith.gameObject.tag == "Player")
        {
            collidingWith.gameObject.SetActive(false);
            Object.Destroy(this.gameObject);
        }

        if (collidingWith.gameObject.name == "Bottom")
        {
            Object.Destroy(this.gameObject);
        }
    }
}
