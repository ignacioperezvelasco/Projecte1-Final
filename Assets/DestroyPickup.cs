using UnityEngine;
using System.Collections;

public class DestroyPickup : MonoBehaviour
{
    public 

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Main"))
        {
            Destroy(gameObject);
        }

    }
}

