using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
public class GameOverManager : MonoBehaviour {
    public Player curhealth;
    public GameObject ammo;
    Animator anim;
    float aux;
    int counter;

	void Start () {
        anim = GetComponent<Animator>();
        counter = 0;
	}
	

	void Update () {
        if (curhealth.curhealth <= 0)
        {
            anim.SetBool("GameOver", true);
            Destroy(ammo);
            if (Input.anyKey){
                SceneManager.LoadScene(0);
            }
        }
    }
}
