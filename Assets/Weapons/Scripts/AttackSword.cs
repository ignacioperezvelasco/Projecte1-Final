using UnityEngine;
using System.Collections;

public class AttackSword : MonoBehaviour {
    Rigidbody2D rb2d;
    public Rigidbody2D player;
    private int counter;
    private Vector2 positionplayer;

	// Use this for initialization
	void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        counter = 0;
        player =GetComponent<Rigidbody2D>();
        
    }
	
	// Update is called once per frame
	void Update () {
        positionplayer = player.transform.position;
        if ((Input.GetKey("right")))//|| Input.GetKey("left")|| Input.GetKey("up")|| Input.GetKey("down"))&& counter==0)
        {
            rb2d.transform.position = (positionplayer+(new Vector2(1,0)));
            
            //rb2d.MoveRotation(-45);
            counter++;
        }
        if ((Input.GetKey("left")))//|| Input.GetKey("left")|| Input.GetKey("up")|| Input.GetKey("down"))&& counter==0)
        {
            //rb2d.transform.position = new Vector2(-1, 0);
            //rb2d.transform.localPosition = Vector3.Slerp(rb2d.transform.localPosition, new Vector3(1, 0, 0), 0.01f);            //rb2d.MoveRotation(-45);
            counter++;
        }
        if ((Input.GetKey("up")))//|| Input.GetKey("left")|| Input.GetKey("up")|| Input.GetKey("down"))&& counter==0)
        {
            rb2d.transform.position = new Vector2(0, 1);

            //rb2d.MoveRotation(-45);
            counter++;
        }
        if ((Input.GetKey("down")))//|| Input.GetKey("left")|| Input.GetKey("up")|| Input.GetKey("down"))&& counter==0)
        {
            rb2d.transform.position = new Vector2(0, -1);

            //rb2d.MoveRotation(-45);
            counter++;
        }

        /*else if ((Input.GetKey("right") || Input.GetKey("left") || Input.GetKey("up") || Input.GetKey("down")) && counter == 1)
        {
            rb2d.MovePosition(positionplayer +( new Vector2(-1, -1)));

            //rb2d.MoveRotation(45);
            counter--;
        }*/

    }
}
