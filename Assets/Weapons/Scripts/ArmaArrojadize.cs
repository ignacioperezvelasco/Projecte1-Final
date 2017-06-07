using UnityEngine;
using System.Collections;



public class ArmaArrojadize : MonoBehaviour
{
    
    //Variables públicas

    public float Velocidad;

    //Variables privadas
    private Rigidbody2D thisRigidbody;

    int scale;

    // Use this for initialization
    void Awake()        
    {
        scale = PlayerPrefs.GetInt("shurikenScale", scale);
        this.transform.localScale = this.transform.localScale * scale;
        thisRigidbody = GetComponent<Rigidbody2D>();
        if  (Input.GetKey("right")) {thisRigidbody.AddForce(new Vector2(1, 0) * Velocidad, ForceMode2D.Impulse);}

        if (Input.GetKey("left")) { thisRigidbody.AddForce(new Vector2(-1, 0) * Velocidad, ForceMode2D.Impulse); }

        if (Input.GetKey("up")) { thisRigidbody.AddForce(new Vector2(0, 1) * Velocidad, ForceMode2D.Impulse); }

        if (Input.GetKey("down")) { thisRigidbody.AddForce(new Vector2(0, -1) * Velocidad, ForceMode2D.Impulse); }
    }

    // Update is called once per frame
    void Update()
    {
        scale = PlayerPrefs.GetInt("shurikenScale");
        Debug.Log(scale);
        transform.Rotate(0, 0, 10);
        
    }

    public void removeforce()
    {
        thisRigidbody.velocity = new Vector2(0, 0);
    }

}

    
   
    
