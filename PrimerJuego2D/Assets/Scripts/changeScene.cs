using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour {
    public int sceneNumber;

     public void CambioEscena()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
