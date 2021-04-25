using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public bool greenPowerUpActivated = false;
    public int chancesFromGreenPowerUp = 2;
    public int chancesInOneCurrent = 2;

    public int livesLeft = 3;

    //touch side of screen to move is universal
    // diff is double tap to dash or "jerk" the phone to either side
    public int whichControlScheme = 0;
    public float playerMoveSpeed = 10.0f;

    public int score;
    public Text scoreOnScreen;

    public Rigidbody2D player;

    public Material materialWhite;
    public Material materialDefault;
    private Object explosionReference;

    SpriteRenderer spriteRenderer;

    // one life remaining is indicated by none of the tokens being visible on the lower left
    public GameObject TwoLifesLeftToken;
    public GameObject ThreeLifesLeftToken;


    //float touchInterval = 0.4f;
    //int scriptTouchCount = 0;
    public bool doubleTapped = false;
    public float DTapTime = 0.5f;
    float newTime;

    public bool pressingSomeUI = false;


    //this up until the end of Awake makes a public Instance of this so that when enemys kill us
    //...we can reduce our lives by one
    public static Player _instance = null;
    public static Player Instance
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
        score = int.Parse(scoreOnScreen.text.ToString());
        //Debug.Log(score);


        spriteRenderer = GetComponent<SpriteRenderer>();
        materialWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        materialDefault = spriteRenderer.material;
        explosionReference = Resources.Load("ParticleExplosion");
        
        //what game object this script is attached to will have it's rigid body comm with the script 
        player = this.GetComponent<Rigidbody2D>();
    }

    //Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.tapCount == 2 && !pressingSomeUI)
                {
                    Touch thistouch = Input.GetTouch(0);
                    switch (thistouch.phase)
                    {
                        case TouchPhase.Began:
                            if (thistouch.position.x < Screen.width / 2)
                                player.velocity = new Vector2(-1f * playerMoveSpeed * 6f, 0f);
                            if (thistouch.position.x > Screen.width / 2)
                                player.velocity = new Vector2(playerMoveSpeed * 6f, 0f);
                            break;

                        case TouchPhase.Ended:
                            //doubleTapped = false;
                            //scriptTouchCount = 0;

                            player.velocity = new Vector2(0f, 0f);
                            break;
                    }
                }

                if (touch.tapCount == 1 && !pressingSomeUI)
                {
                    Touch thistouch = Input.GetTouch(0);
                    switch (thistouch.phase)
                    {
                        case TouchPhase.Began:
                            if (thistouch.position.x < Screen.width / 2)
                                player.velocity = new Vector2(-1f * playerMoveSpeed, 0f);
                            if (thistouch.position.x > Screen.width / 2)
                                player.velocity = new Vector2(playerMoveSpeed, 0f);
                            break;

                        case TouchPhase.Ended:
                            player.velocity = new Vector2(0f, 0f);
                            break;
                    }
                }
            }

            

        }

        //if (Input.touchCount > 0)
        //{

        //    if (scriptTouchCount == 1 && (touchInterval > 0) && !pressingSomeUI)
        //    {
        //        //we just double tapped, see if two taps were on same side
        //        doubleTapped = true;
        //    }
        //    else
        //    {
        //        touchInterval = 0.4f;
        //        scriptTouchCount += 1;
        //        //should implicitly be the case but hey
        //    }

        //    if( touchInterval > 0)
        //    {
        //        touchInterval -= 1 * Time.deltaTime;
        //    }
        //    else
        //    {
        //        //doubleTapped = false;
        //        //was just one press...do this
        //        scriptTouchCount = 0;

                
        //    }

        //    if (doubleTapped && !pressingSomeUI)
        //    {
        //        Touch touch = Input.GetTouch(0);
        //        switch (touch.phase)
        //        {
        //            case TouchPhase.Began:
        //                if (touch.position.x < Screen.width / 2)
        //                    player.velocity = new Vector2(-1f * playerMoveSpeed * 6f, 0f);
        //                if (touch.position.x > Screen.width / 2)
        //                    player.velocity = new Vector2(playerMoveSpeed * 6f, 0f);
        //                break;

        //            case TouchPhase.Ended:
        //                doubleTapped = false;
        //                scriptTouchCount = 0;

        //                player.velocity = new Vector2(0f, 0f);
        //                break;
        //        }
        //    }
        //    else if (!pressingSomeUI)
        //    {
        //        Touch touch = Input.GetTouch(0);
        //        switch (touch.phase)
        //        {
        //            case TouchPhase.Began:
        //                if (touch.position.x < Screen.width / 2)
        //                    player.velocity = new Vector2(-1f * playerMoveSpeed, 0f);
        //                if (touch.position.x > Screen.width / 2)
        //                    player.velocity = new Vector2(playerMoveSpeed, 0f);
        //                break;

        //            case TouchPhase.Ended:
        //                player.velocity = new Vector2(0f, 0f);
        //                break;
        //        }
        //    }
        //}



        //    Touch touch = Input.GetTouch(0);

        //    switch (touch.phase)
        //    {
        //        case TouchPhase.Began:
        //            if (touch.position.x<Screen.width / 2)
        //                player.velocity = new Vector2(-1f * playerMoveSpeed, 0f);
        //            if (touch.position.x > Screen.width / 2)
        //                player.velocity = new Vector2(playerMoveSpeed, 0f);
        //            break;

        //        case TouchPhase.Ended:
        //            player.velocity = new Vector2(0f, 0f);
        //            break;
        //    }
        //}

        //float touchInterval = 0.4f;
        //int touchCount = 0;
        
    }

    void FixedUpdate()
    {
        

        #if !UNITY_ANDROID && !UNITY_IOS && !UNITY_WINRT
                movePlayer();
                return;
        #endif
    }

    public void movePlayer()
    {                               //horizontal key, left right   // vertical, up down key  
        player.velocity = new Vector2(Input.GetAxis("Horizontal") * playerMoveSpeed, Input.GetAxis("Vertical") * 0) ;
        //set Gravity Scale in this object's Rigidbody 2D to 0 so that it doesn't drop slowly
        //
        //player.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * playerMoveSpeed;
    }
    //if (Player.Instance.livesLeft == 1 ||
    //(Player.Instance.greenPowerUpActivated == false ||
    //            (Player.Instance.greenPowerUpActivated == true && Player.Instance.chancesInOneCurrent == 1))) 
    //        {

    //            Player.Instance.DeathByEnemyCollision();
    //            //collidingWith.gameObject.SetActive(false);
    //            Object.Destroy(this.gameObject);
    //}
    //        else if (Player.Instance.livesLeft > 1 )
    //        {
    //            Player.Instance.chancesInOneCurrent -= 1;
    //            Player.Instance.DeathByEnemyCollision();
    //            //collidingWith.gameObject.SetActive(false);
    //            Object.Destroy(this.gameObject);
    //}


    public void DeathByEnemyCollision()
    {
        //we've run out of luck (and life lol)...welcome to die
        if (livesLeft == 1 && (greenPowerUpActivated == false || 
            (greenPowerUpActivated == true && chancesInOneCurrent == 1)))
        {
            //we deeeeeaaaaaaaaaad

            livesLeft = 0;
            GameObject explosion = (GameObject)Instantiate(explosionReference);
            explosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            this.gameObject.SetActive(false);

            PlayerPrefs.SetString("PlayerScore", score.ToString() );

            PauseMenu.Instance.GameOver();
            
            
        }
        else
        {
            if (greenPowerUpActivated == false ||
            (greenPowerUpActivated == true && chancesInOneCurrent == 1))
            { 
                //remove a token and flash the ship back to center
                livesLeft -= 1;


                switch (livesLeft)
                {
                    //have ship glow white for a bit no matter what, a hit's a hit
                    case 1:
                        TwoLifesLeftToken.SetActive(false);
                        spriteRenderer.material = materialWhite;
                        break;
                    case 2:
                        ThreeLifesLeftToken.SetActive(false);
                        spriteRenderer.material = materialWhite;
                        break;
                    default:
                        break;
                }
                //reset the amount of chances for our next life back to prooooobably 2
                chancesInOneCurrent = 2;

                //Do the explosion while the shaceship is still white n glowly
                GameObject explosion = (GameObject)Instantiate(explosionReference);
                explosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            
                //have it disappear in the explosion, we spawn it back in the reset function
                // We'll put it back to the middle soon
                this.gameObject.SetActive(false);
                StartReset();
            }
            else if (greenPowerUpActivated == true && chancesInOneCurrent > 1)
            {
                chancesInOneCurrent -= 1;
            }
        }
    }

    void StartReset()
    {
        Invoke(nameof(ResetMaterialAndPOS), 3f);
    }

    void ResetMaterialAndPOS()
    {
        //yield return new WaitForSeconds(3);
        spriteRenderer.material = materialDefault;
        this.gameObject.transform.position = new Vector3(0f, -3.5f, 0f);
        this.gameObject.SetActive(true);
    }

    public void UpSpeedBluePower()
    {
        pressingSomeUI = true;
        if (playerMoveSpeed == 10.0f) { 
            playerMoveSpeed = 20.0f;
        }
    }

    public void LifeImproveGreenPower()
    {
        pressingSomeUI = true;
        if (greenPowerUpActivated == false) 
        {
            greenPowerUpActivated = true;
        }
        
    }

    public void noLongerPressingUI()
    {
        pressingSomeUI = false;
    }

    public void RestartGame()
    {
        greenPowerUpActivated = false;
        chancesFromGreenPowerUp = 2;
        chancesInOneCurrent = 2;

        livesLeft = 3;

        //touch side of screen to move is universal
        // diff is double tap to dash or "jerk" the phone to either side...didn't get to impl this
        whichControlScheme = 0;
        playerMoveSpeed = 10.0f;
        score = 0;
        scoreOnScreen.text = score.ToString();

        TwoLifesLeftToken.SetActive(true);
        ThreeLifesLeftToken.SetActive(true);
       

        

        this.transform.position = new Vector3(0f, -3.5f);
        this.gameObject.SetActive(true);
       
    }
}
