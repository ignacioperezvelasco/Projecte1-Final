using UnityEngine;
using System.Collections;

public class ShurikenHit : MonoBehaviour {
    public float weapondamage;
    ArmaArrojadize myPC;
    //public GameObject explosion;

	// Use this for initialization
	void Awake () {
        myPC = GetComponentInParent<ArmaArrojadize>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.layer == LayerMask.NameToLayer("topoNormal") || other.gameObject.layer == LayerMask.NameToLayer("topopeBoss")) || other.gameObject.layer == LayerMask.NameToLayer("topoPequeño"))
        {
            myPC.removeforce();
           // Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            other.GetComponent<Rigidbody2D>();
            
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if ((other.gameObject.layer == LayerMask.NameToLayer("topoNormal") || other.gameObject.layer == LayerMask.NameToLayer("topopeBoss")) || other.gameObject.layer == LayerMask.NameToLayer("topoPequeño"))
        {
            myPC.removeforce();
            //Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
