using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour
{
    public Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    public void Move(Vector2 moveamount)
    {
        transform.Translate(moveamount);
    }
    public void Movey(Vector2 moveamount)
    {
        transform.Translate(moveamount);
    }

}


