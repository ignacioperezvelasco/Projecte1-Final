using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

[RequireComponent(typeof(PlayerPhysics))]

public class Player : MonoBehaviour
{
    public float thrust;

    public int dmg;
    public Text currentshurikens;
    
    //public Animator anim;
    private float aux;
    public int health = 3;
    public int curhealth;
    public float speed = 3;
    public float aceleration = 12;
    private PlayerPhysics playerphisics;
    public Rigidbody2D rb2d;
    public Transform chara;

    // For Movement
    private float moveHorizontal;
    private float moveVertical;


    //For shooting

    public Transform guntip;
    public GameObject bullet;
    private float firerate = 0.5f;
    private float nextfire = 0f;
    public int numShurikens;

    int shurikenscale;

    //for SwitchWeapons

    //public GameObject sword;
    public bool shuriken;


    //PickUps
    private bool dmgpick;
    private bool pickUpShurikens;

    public Slider HealthSlider;

    //
    public Transform enem;
    bool dmged;



    // Use this for initialization
    void Start()
    {
        //for shuriken
        shurikenscale = 1;

        //    anim = GetComponent<Animator>();
        //For Move

        curhealth = health;
        rb2d = GetComponent<Rigidbody2D>();
        dmg = 25;
        
            
        dmgpick = false;
        pickUpShurikens = false;
      
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("shurikenScale", shurikenscale);

        currentshurikens.text = "Shurikens: " + numShurikens;
        if (curhealth > health)
        {
            curhealth = health;
        }
        HealthSlider.value = curhealth;

        PlayerPrefs.SetInt("dmg", dmg);
        //For Move


        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                orientacion();

                moveHorizontal = Input.GetAxis("Horizontal");

                float moveVertical = Input.GetAxis("Vertical");

                rb2d.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);
            }
            else { rb2d.velocity = new Vector2(0, 0); }
       



        //For shooting

         if (Input.GetKey("1"))
         {
             //sword.SetActive(true);
             shuriken = false;
         }
         if (Input.GetKey("2"))
         {
             //sword.SetActive(false);
             shuriken = true;
         }

        shuriken = true;
        if (((shuriken == true && (Input.GetKey("down") || Input.GetKey("up") || Input.GetKey("left") || Input.GetKey("right"))) && numShurikens>0)) { fireRocket();  }

        if (curhealth <= 0)
        {
            Destroy(gameObject);
            Application.Quit();
        }

        if (dmgpick == true)
        {
            dmgpick = false;

        }

        if ((Time.time - aux) > 1)
        {
           // anim.SetBool("damaged", false);
           // dmged = false;            
        }
        if (pickUpShurikens == true)
        {
            numShurikens += 10;
            pickUpShurikens = false;
        }

    }

    void fireRocket()
    {
        if (Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            numShurikens--;
            Instantiate(bullet, guntip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        }



        if (Input.GetKey("up"))
        {
            rb2d.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey("down")) { transform.localRotation = Quaternion.Euler(0, 0, 180); }
        if (Input.GetKey("left")) { transform.localRotation = Quaternion.Euler(0, 0, 90); }
        if (Input.GetKey("right")) { transform.localRotation = Quaternion.Euler(0, 0, 270); }



    }

    void orientacion()
    {

        if (Input.GetKeyDown("w")) //pl.currentSpeed==0 && pl.currentSpeedy<0)
        {
            // if (transform.localRotation != Quaternion.Euler(0, 0, 0))


            transform.localRotation = Quaternion.Euler(0, 0, 0);


        }
        if (Input.GetKeyDown("a"))
        {
            // if (transform.localRotation != Quaternion.Euler(0, 0, 90))

            transform.localRotation = Quaternion.Euler(0, 0, 90);



        }
        if (Input.GetKey("s"))
        {
            // if (transform.localRotation != Quaternion.Euler(0, 0, 180))

            transform.localRotation = Quaternion.Euler(0, 0, 180);
        }
        if (Input.GetKeyDown("d"))
        {
            // if (transform.localRotation != Quaternion.Euler(0, 0, 270))

            transform.localRotation = Quaternion.Euler(0, 0, 270);


        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("topoBoss"))
        {         
                curhealth -= 35;
                aux = Time.time;                     
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("topoNormal"))
        {
            curhealth -= 15;
            aux = Time.time;
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("topoPequeño"))
        {
            curhealth -= 7;
            aux = Time.time;
        }
        if ((other.gameObject.layer == LayerMask.NameToLayer("topoNormal")|| other.gameObject.layer == LayerMask.NameToLayer("topopeBoss"))|| other.gameObject.layer == LayerMask.NameToLayer("topoPequeño"))
        {
            dmgpick = true;
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Salida"))
        {
            Application.Quit();
        }


        //PickUps
        if(other.gameObject.layer == LayerMask.NameToLayer("pickUpShuriken"))
        {
            numShurikens += 5;
           
           
        }
        
              if (other.gameObject.layer == LayerMask.NameToLayer("pickUpHealth"))
        {
            curhealth += 20;
        }        
             if (other.gameObject.layer == LayerMask.NameToLayer("pickUpDmg"))
        {
            dmg += 5;
            PlayerPrefs.SetInt("dmg", dmg);
        }
        
             if (other.gameObject.layer == LayerMask.NameToLayer("pickUpSizeShuriken"))
        {

            shurikenscale++;
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("pickUpBotas"))
        {

            speed++;
        }
        
            if (other.gameObject.layer == LayerMask.NameToLayer("pinchos"))
        {

            curhealth -= 10;
           
            
        }
    }

    
   
}


