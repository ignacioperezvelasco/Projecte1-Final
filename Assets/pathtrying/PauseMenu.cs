using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
public class PauseMenu : MonoBehaviour {

    public string mainmenu;

    public bool ispaused;
    public GameObject pauseMenuCanvas;
	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
        if (ispaused == true)
        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ispaused = !ispaused;
        }
	}
    public void resume()
    {
        ispaused = false;
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
