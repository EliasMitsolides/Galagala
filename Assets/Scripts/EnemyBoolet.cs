using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoolet : MonoBehaviour
{

    public Transform projectileInitate;
    public GameObject laser;
    

    public float FireTimer = 1.0f;
    public float currentTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        projectileInitate = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        baddyShoot();
    }

    void baddyShoot() 
    {
        currentTime += Time.deltaTime;

        if(currentTime > FireTimer)
        {
            FireTimer += currentTime;

            Instantiate(laser, projectileInitate.position, Quaternion.identity);

            FireTimer -= currentTime;

            currentTime = 0f;


        }
    }

    
}
