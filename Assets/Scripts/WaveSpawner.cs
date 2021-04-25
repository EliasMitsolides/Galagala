using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    bool poppedUpVictoryScreen = false;
    bool hasGameStarted = false;
    public int currentWave = 0;
    public int enemyCounter = 0;

    public GameObject gameContent;

    //public Transform GreenEnemyInitiate;
    public GameObject GreenEnemy;

    //public Transform CrawlieEnemyInitiate;
    public GameObject CrawlieEnemy;

    public GameObject BossEnemy;

    public int leftBossHealth = 3;
    public int rightBossHealth = 3;


    GameObject green1;
    GameObject green2;
    GameObject green3;
    GameObject green4;
    GameObject green5;
    GameObject green6;
    GameObject green7;
    GameObject green8;
    GameObject green9;
    GameObject green10;


    GameObject green11;
    GameObject green12;
    GameObject green13;
    GameObject crawlie1;
    GameObject green14;
    GameObject green15;
    GameObject green16;
    GameObject crawlie2;

    GameObject boss1;
    GameObject boss2;

    //this up until the end of Awake makes a public Instance of this so that when our laser kills an enemy
    //...we can reduce this public enemyCounter by one
    public static WaveSpawner _instance = null;
    public static WaveSpawner Instance
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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWave == 0 && !hasGameStarted && enemyCounter == 0)
        {   //         Right Side Wave       GreenEnemyInitiate.position 
            green1 = Instantiate(GreenEnemy, new Vector3(10.7f, 20f, 0f), Quaternion.identity);
            green2 = Instantiate(GreenEnemy, new Vector3(17.7f, 20f, 0f), Quaternion.identity);
            green3 = Instantiate(GreenEnemy, new Vector3(24.7f, 20f, 0f), Quaternion.identity);

            green4 = Instantiate(GreenEnemy, new Vector3(14.4f, 13.5f, 0f), Quaternion.identity);
            green5 = Instantiate(GreenEnemy, new Vector3(21.4f, 13.5f, 0f), Quaternion.identity);

            //         Left Side Wave   ......  Spawn em 7 over to the right
            green6 = Instantiate(GreenEnemy, new Vector3(-3.7f, 20f, 0f), Quaternion.identity);
            green7 = Instantiate(GreenEnemy, new Vector3(-10.7f, 20f, 0f), Quaternion.identity);
            green8 = Instantiate(GreenEnemy, new Vector3(-17.7f, 20f, 0f), Quaternion.identity);

            green9 = Instantiate(GreenEnemy, new Vector3(-7.4f, 13.5f, 0f), Quaternion.identity);
            green10 = Instantiate(GreenEnemy, new Vector3(-14.4f, 13.5f, 0f), Quaternion.identity);

            green1.transform.parent = gameContent.transform;
            green2.transform.parent = gameContent.transform;
            green3.transform.parent = gameContent.transform;
            green4.transform.parent = gameContent.transform;
            green5.transform.parent = gameContent.transform;
            green6.transform.parent = gameContent.transform;
            green7.transform.parent = gameContent.transform;
            green8.transform.parent = gameContent.transform;
            green9.transform.parent = gameContent.transform;
            green10.transform.parent = gameContent.transform;


            //upper row y's were at 17.5...lower row y's were at 11
            green1.name = "Green Enemy";
            green2.name = "Green Enemy";
            green3.name = "Green Enemy";
            green4.name = "Green Enemy";
            green5.name = "Green Enemy";
            green6.name = "Green Enemy";
            green7.name = "Green Enemy";
            green8.name = "Green Enemy";
            green9.name = "Green Enemy";
            green10.name = "Green Enemy";

            currentWave = 1;
            hasGameStarted = true;
            enemyCounter = 10;
            //Instantiate(GreenEnemy, new Vector3(7.2f, 17.5f, 0f), Quaternion.identity);
            //Instantiate(GreenEnemy, new Vector3(14.2f, 17.5f, 0f), Quaternion.identity);
            //Instantiate(GreenEnemy, new Vector3(21.2f, 17.5f, 0f), Quaternion.identity);

            //Instantiate(GreenEnemy, new Vector3(10.9f, 11f, 0f), Quaternion.identity);
            //Instantiate(GreenEnemy, new Vector3(17.9f, 11f, 0f), Quaternion.identity);

        }


        //start second wave, those 10 (maybe reduce to 8 or 9) plus the two "crawliers"

        //if (currentWave == 1 && enemyCounter == 0)
        if (currentWave == 1 && hasGameStarted && enemyCounter == 0)
        {


            green11 = Instantiate(GreenEnemy, new Vector3(10.7f, 20f, 0f), Quaternion.identity);
            green12 = Instantiate(GreenEnemy, new Vector3(17.7f, 20f, 0f), Quaternion.identity);
            green13 = Instantiate(GreenEnemy, new Vector3(24.7f, 20f, 0f), Quaternion.identity);
            crawlie1 = Instantiate(CrawlieEnemy, new Vector3(33.6f, 2.77f, 0f), Quaternion.identity);


            green14 = Instantiate(GreenEnemy, new Vector3(-3.7f, 20f, 0f), Quaternion.identity);
            green15 = Instantiate(GreenEnemy, new Vector3(-10.7f, 20f, 0f), Quaternion.identity);
            green16 = Instantiate(GreenEnemy, new Vector3(-17.7f, 20f, 0f), Quaternion.identity);
            crawlie2 = Instantiate(CrawlieEnemy, new Vector3(-33.6f, 2.77f, 0f), Quaternion.identity);
            //upper row y's were at 17.5...lower row y's were at 11.......crawlie y's were at 2.5

            green11.transform.parent = gameContent.transform;
            green12.transform.parent = gameContent.transform;
            green13.transform.parent = gameContent.transform;
            crawlie1.transform.parent = gameContent.transform;

            green14.transform.parent = gameContent.transform;
            green15.transform.parent = gameContent.transform;
            green16.transform.parent = gameContent.transform;
            crawlie2.transform.parent = gameContent.transform;


            green11.name = "Green Enemy";
            green12.name = "Green Enemy";
            green13.name = "Green Enemy";
            crawlie1.name = "Crawlie Enemy";

            green14.name = "Green Enemy";
            green15.name = "Green Enemy";
            green16.name = "Green Enemy";
            crawlie2.name = "Crawlie Enemy";

            currentWave = 2;
            enemyCounter = 8;
        }
        else if (currentWave == 2 && enemyCounter == 0)
        {                                                       //go to x = -3.8...diff of 26.2 via moving right
            boss1 = Instantiate(BossEnemy, new Vector3(-30f, 22.18f, 0f), Quaternion.identity);
            boss1.name = "Left Boss Enemy";

                                                                //go to x = 3.8...diff of 26.2 via moving left
            boss2 = Instantiate(BossEnemy, new Vector3(30f, 22.18f, 0f), Quaternion.identity);
            boss2.name = "Right Boss Enemy";

            boss1.transform.parent = gameContent.transform;
            boss2.transform.parent = gameContent.transform;


            currentWave = 3;
            enemyCounter = 2;
        }
        else if (currentWave == 3 && enemyCounter == 0 && !poppedUpVictoryScreen)
        {
            poppedUpVictoryScreen = true;
            PauseMenu.Instance.GameWon();
        }
    }

    void WipePreviousEnemies()
    {
        Object.Destroy(green1);
        Object.Destroy(green2);
        Object.Destroy(green3);
        Object.Destroy(green4);
        Object.Destroy(green5);
        Object.Destroy(green6);
        Object.Destroy(green7);
        Object.Destroy(green8);
        Object.Destroy(green9);
        Object.Destroy(green10);


        Object.Destroy(green11);
        Object.Destroy(green12);
        Object.Destroy(green13);
        Object.Destroy(crawlie1);
        Object.Destroy(green14);
        Object.Destroy(green15);
        Object.Destroy(green16);
        Object.Destroy(crawlie2);

        Object.Destroy(boss1);
        Object.Destroy(boss2);
    }

    public void RestartEnemies()
    {
        currentWave = 0;
        hasGameStarted = false;
        enemyCounter = 0;
        poppedUpVictoryScreen = false;
        WipePreviousEnemies();
    }
}
