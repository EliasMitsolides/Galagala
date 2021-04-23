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
        Debug.Log("uwu");
        if (currentWave == 0 && !hasGameStarted && enemyCounter == 0)
        {   //         Right Side Wave       GreenEnemyInitiate.position 
            GameObject green1 = Instantiate(GreenEnemy, new Vector3(10.7f, 20f, 0f), Quaternion.identity);
            GameObject green2 = Instantiate(GreenEnemy, new Vector3(17.7f, 20f, 0f), Quaternion.identity);
            GameObject green3 = Instantiate(GreenEnemy, new Vector3(24.7f, 20f, 0f), Quaternion.identity);

            GameObject green4 = Instantiate(GreenEnemy, new Vector3(14.4f, 13.5f, 0f), Quaternion.identity);
            GameObject green5 = Instantiate(GreenEnemy, new Vector3(21.4f, 13.5f, 0f), Quaternion.identity);

            //         Left Side Wave   ......  Spawn em 7 over to the right
            GameObject green6 = Instantiate(GreenEnemy, new Vector3(-3.7f, 20f, 0f), Quaternion.identity);
            GameObject green7 = Instantiate(GreenEnemy, new Vector3(-10.7f, 20f, 0f), Quaternion.identity);
            GameObject green8 = Instantiate(GreenEnemy, new Vector3(-17.7f, 20f, 0f), Quaternion.identity);

            GameObject green9 = Instantiate(GreenEnemy, new Vector3(-7.4f, 13.5f, 0f), Quaternion.identity);
            GameObject green10 = Instantiate(GreenEnemy, new Vector3(-14.4f, 13.5f, 0f), Quaternion.identity);

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
    }

    // Update is called once per frame
    void Update()
    {
        //start second wave, those 10 (maybe reduce to 8 or 9) plus the two "crawliers"

        //if (currentWave == 1 && enemyCounter == 0)
        if (currentWave == 1 && hasGameStarted && enemyCounter == 0)
        {


            GameObject green11 = Instantiate(GreenEnemy, new Vector3(10.7f, 20f, 0f), Quaternion.identity);
            GameObject green12 = Instantiate(GreenEnemy, new Vector3(17.7f, 20f, 0f), Quaternion.identity);
            GameObject green13 = Instantiate(GreenEnemy, new Vector3(24.7f, 20f, 0f), Quaternion.identity);
            GameObject crawlie1 = Instantiate(CrawlieEnemy, new Vector3(33.6f, 2.77f, 0f), Quaternion.identity);


            GameObject green16 = Instantiate(GreenEnemy, new Vector3(-3.7f, 20f, 0f), Quaternion.identity);
            GameObject green17 = Instantiate(GreenEnemy, new Vector3(-10.7f, 20f, 0f), Quaternion.identity);
            GameObject green18 = Instantiate(GreenEnemy, new Vector3(-17.7f, 20f, 0f), Quaternion.identity);
            GameObject crawlie2 = Instantiate(CrawlieEnemy, new Vector3(-33.6f, 2.77f, 0f), Quaternion.identity);
            //upper row y's were at 17.5...lower row y's were at 11.......crawlie y's were at 2.5

            green11.transform.parent = gameContent.transform;
            green12.transform.parent = gameContent.transform;
            green13.transform.parent = gameContent.transform;
            crawlie1.transform.parent = gameContent.transform;

            green16.transform.parent = gameContent.transform;
            green17.transform.parent = gameContent.transform;
            green18.transform.parent = gameContent.transform;
            crawlie2.transform.parent = gameContent.transform;


            green11.name = "Green Enemy";
            green12.name = "Green Enemy";
            green13.name = "Green Enemy";
            crawlie1.name = "Crawlie Enemy";

            green16.name = "Green Enemy";
            green17.name = "Green Enemy";
            green18.name = "Green Enemy";
            crawlie2.name = "Crawlie Enemy";

            currentWave = 2;
            enemyCounter = 8;
        }
        else if (currentWave == 2 && enemyCounter == 0)
        {                                                       //go to x = -3.8...diff of 26.2 via moving right
            GameObject boss1 = Instantiate(BossEnemy, new Vector3(-30f, 22.18f, 0f), Quaternion.identity);
            boss1.name = "Left Boss Enemy";

                                                                //go to x = 3.8...diff of 26.2 via moving left
            GameObject boss2 = Instantiate(BossEnemy, new Vector3(30f, 22.18f, 0f), Quaternion.identity);
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
}
