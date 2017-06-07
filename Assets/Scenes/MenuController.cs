using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour {

    public Canvas MainCanvas;

	// Use this for initialization
	void Awake ()
    {
        MainCanvas.enabled = true;
	}

    // Update is called once per frame
    public void LoadOn() {
        SceneManager.LoadScene(1);
        //Application.LoadLevel(1);
    }
    public void loadoff() { Application.Quit(); }
}
