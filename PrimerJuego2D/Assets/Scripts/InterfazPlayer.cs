using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfazPlayer : MonoBehaviour {
    public Canvas ui_Player;
    public float maxVida;
    public Image img_vida;
    public Image img_energia;
    public PlayerController playerScript;
	// Use this for initialization
	void Start () {
        ui_Player.enabled = false;
        maxVida = playerScript.vida;
        img_vida.fillAmount = playerScript.vida / maxVida;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (GameController.inicio_juego)
        {
            ui_Player.enabled = true;
        }
        img_vida.fillAmount = playerScript.vida / maxVida;
    }
}
