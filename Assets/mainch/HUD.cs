using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
    public Sprite[] Hearts;
    public Image HeartUI;
    public Player player;

    void Start() {
        player = GetComponent<Player>();
    }

    void Update() {
        HeartUI.sprite = Hearts[player.curhealth];
    }

}
