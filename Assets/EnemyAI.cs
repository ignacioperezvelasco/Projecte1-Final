using UnityEngine;
using Pathfinding;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class EnemyAI : MonoBehaviour
{
    // vida
    public float vida;
    //What to chase
    public Transform target;

    //anim
    public Animator anim;
    float aux;
    //
    public int dmg;

    //time second we update a path
    public float updateRate = 2f;

    //catching
    private Seeker seeker;
    private Rigidbody2D rb;

    //Calculate path

    public Path path;

    //Ia speed
    public float speed;
    public ForceMode2D fMode;

    [HideInInspector]
    public bool pathIsEnded = false;

    //Max Distance from IA to waypoint to continue to the next
    public float nextWayPointDistance = 3;

    //WayPoint currently moving
    private int currentWayPoint = 0;

    //distance
    Vector2 distancia;

    void Start()
    {
        //   distancia = new Vector2(target.position.x - this.transform.position.x, target.position.y - this.transform.position.y);
        speed = 0;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        aux = 0;

        if (target == null)
        {
            Debug.LogError("null player found ");
            return;
        }
        //start pat to the target
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine(UpdatePath());
          
    }
    IEnumerator UpdatePath()
    {
        if(target==null)
        {
            //TODO:Insert a player search here
            yield return false;
        }
        seeker.StartPath(transform.position, target.position, OnPathComplete);
        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());
    }

    public void OnPathComplete(Path p)
    {
        Debug.Log("We got a path.did it have an error?" + p.error);
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }

    void FixedUpdate()
    {
        distancia = new Vector2(target.position.x - this.transform.position.x, target.position.y - this.transform.position.y);
        dmg = PlayerPrefs.GetInt("dmg");
        print(distancia.magnitude);
        if (distancia.magnitude < 40)
        {

            if (target == null)
            {
                //TODO:Insert a player search here
                // yield return null;
            }
            //  TODO: Alwais look at player ?

            if (path == null)
            {
                //yield return null;

            }
            if (currentWayPoint >= path.vectorPath.Count)
            {
                if (pathIsEnded)
                {
                    //yield return null;
                }
                Debug.Log("End of path reached");
                pathIsEnded = true;
            }
            pathIsEnded = false;

            //Direction to the next wayPoint
            Vector3 dir = (path.vectorPath[currentWayPoint] - transform.position).normalized;
            dir *= speed * Time.fixedDeltaTime;

            //moveThe Ai

            //rb.AddForce(dir, fMode);
            rb.velocity = dir;
            float dist = Vector3.Distance(transform.position, path.vectorPath[currentWayPoint]);

            if (dist < nextWayPointDistance)
            {
                currentWayPoint++;
                //yield return null;
            }
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
        if ((Time.realtimeSinceStartup-aux) > 3)
        {
            anim.SetBool("damaged", false);
        }
        rotateIA();
        if (vida <= 0) { Destroy(gameObject); }
    }

    void rotateIA()
    {
        Vector3 direction = target.position - transform.position;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.layer == LayerMask.NameToLayer("projectile"))
        {
            aux = Time.realtimeSinceStartup;
            vida -= dmg;
            anim.SetBool("damaged", true);

        }

       
    }
    public void OnTriggerStay(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("pinchos"))
        {
            aux = Time.realtimeSinceStartup;
            vida -= dmg;
            anim.SetBool("damaged", true);
        }
    }

}
   
