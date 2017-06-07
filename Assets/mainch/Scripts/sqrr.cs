using UnityEngine;
using System.Collections;

public class sqrr : MonoBehaviour
{
    float aux;
    public Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown("w")) //pl.currentSpeed==0 && pl.currentSpeedy<0)
        {
            // if (transform.localRotation != Quaternion.Euler(0, 0, 0))

            anim.SetBool("Move", true);





        }
        if (Input.GetKeyDown("a"))
        {
            // if (transform.localRotation != Quaternion.Euler(0, 0, 90))


            anim.SetBool("Move", true);



        }
        if (Input.GetKey("s"))
        {
            // if (transform.localRotation != Quaternion.Euler(0, 0, 180))

            anim.SetBool("Move", true);



        }
        if (Input.GetKeyDown("d"))
        {
            // if (transform.localRotation != Quaternion.Euler(0, 0, 270))


            anim.SetBool("Move", true);


        }

        if ((Time.time - aux) > 2)
        {
            anim.SetBool("damaged", false);
        }




    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.layer == LayerMask.NameToLayer("topoNormal") || other.gameObject.layer == LayerMask.NameToLayer("topopeBoss")) || other.gameObject.layer == LayerMask.NameToLayer("topoPequeño"))
        {
            
            anim.SetBool("damaged", true);
            aux = Time.time;

        }
        if (other.gameObject.layer == LayerMask.NameToLayer("pinchos"))
        {
            aux = Time.realtimeSinceStartup;
            anim.SetBool("damaged", true);
        }


    }
}
       