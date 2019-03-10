using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public static GameController instance = null;
    public static bool inicio_juego = false;
    public int sceneNumber;
    //pseudo singleton
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(this);
    }
    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InicioJuego()
    {
        inicio_juego = true;
        SceneManager.LoadScene(sceneNumber);
    }

}
/*Este es el controlador del juego, aca se controla las pausa el inicio del juego, el final del juego, si pierde el jugador , si se reinicia
 * el juego , salvar el juego*/