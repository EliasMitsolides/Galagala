using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public Transform projectileSpawn;
    //public Transform sooperProjectileSpawn;

    public GameObject projectile;
    public GameObject sooperProjectile;

    public float nextFire = 1.0f;
    public float currentTime = 0.0f;

    public int sooperBooletsLeft = 1;

    Vector3 sooperSpawn;



    public static Shoot _instance = null;
    public static Shoot Instance
    {
        get { return _instance; }
    }
    void Awake()
    {
        if (Instance == null)
        {
            _instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        projectileSpawn = this.gameObject.transform;
        sooperSpawn = new Vector3(this.transform.position.x, this.transform.position.y + 12f);
        //sooperProjectileSpawn = this.gameObject.transform;
        //sooperProjectileSpawn.position = sooperSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        sooperSpawn = new Vector3(this.transform.position.x, this.transform.position.y + 12f);
        //uncomment this to be able to fire by left mouse button clicking
        //ShootBoolet();

        //this line below goes in ShootBoolet() if we revert back to screen pressing
        currentTime += Time.deltaTime;

    }

    public void ShootBoolet() 
    {
        Player.Instance.pressingSomeUI = true;
        //currentTime += Time.deltaTime;

        //Input.GetButton("Fire1") && currentTime > nextFire

        if (currentTime > nextFire)
        {
            
            nextFire += currentTime;
            Instantiate(projectile, projectileSpawn.position, Quaternion.identity);
            nextFire -= currentTime;
            currentTime = 0.0f;

        }
    }

    public void ShootSooperBoolet()
    {
        Player.Instance.pressingSomeUI = true;

        if (sooperBooletsLeft == 1)
        {
            Instantiate(sooperProjectile, sooperSpawn, Quaternion.identity);
            sooperBooletsLeft = 0;
        }
        
    }

    public void RestartSooperBooletCount()
    {
        sooperBooletsLeft = 1;
    }
}
