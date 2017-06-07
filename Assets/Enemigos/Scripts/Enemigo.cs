using UnityEngine;
using System.Collections;


public class Enemigo : MonoBehaviour {
    private float speed=1f;
   
    private Vector2 movement;
    public Rigidbody2D rb2d;
    public Transform trans;

    private bool colision;
    
    public Transform enem;
    public Animator anim;

    private float RotateSpeed = 1f;
    private float Radius = 1f;
    private Vector2 _centre;
    private float _angle;

    private Transform posant;
    private bool proj;
    float aux;
    int counter;
    bool collmain;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

        colision = false;

        _centre = transform.position;

        _angle = Random.Range(0,360);

        proj=false;
        counter = 0;
    }
	
	// Update is called once per frame

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("pared"))
        {
            colision = true;
        }
         if (other.gameObject.layer == LayerMask.NameToLayer("projectile"))
         {
            proj = true;
            posant = enem;
            aux = Time.time;
            counter = 0;
            anim.SetBool("damaged",true);
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("main"))
        {
            colision = true;
            aux = Time.time;
        }
    }

    void FixedUpdate()
    {
       

        if (proj == true)
        {
           
            if (counter == 0)
            {
                if (enem.position.x < trans.position.x)
                {
                    rb2d.AddForce(new Vector2(-100, 0));
                }
                else if (enem.position.x > trans.position.x)
                {
                    rb2d.AddForce(new Vector2(100, 0));
                }
                if (enem.position.y < trans.position.y)
                {
                    rb2d.AddForce(new Vector2(0, -100));
                }
                else if (enem.position.y > trans.position.y)
                {
                    rb2d.AddForce(new Vector2(0, 100));
                }
                counter++;
            }
            if ((Time.time - aux) > 0.1)
            {
                anim.SetBool("damaged", false);
                proj = false;
            }
        }
        else rb2d.velocity = movement;
               
    }

    void rotateIA()
    {
        Vector3 direction = trans.position - transform.position;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg-90);
    }

   
}

