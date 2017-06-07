using UnityEngine;
using System.Collections;

public class CambiarAnimadion : MonoBehaviour {
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        bool moverse = anim.GetBool("Move");
        if (Input.anyKey)
        {
            moverse = true;
        }
        else { moverse = false; }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
