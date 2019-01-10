using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuentaAtras : MonoBehaviour {

    public GameObject motorCarrGO;
    public MotorDeCarreteras motorCarrScript;
    public Sprite[] numeros;

    public GameObject contadorNumGO;
    public SpriteRenderer contadoNumComp;

    public GameObject controladorCocheGO;
    public GameObject cocheGO;

	void Start ()
    {
        InicioComponentes();
	}

    void InicioComponentes()
    {
        motorCarrGO = GameObject.Find("MotorCarreteras");
        motorCarrScript = motorCarrGO.GetComponent<MotorDeCarreteras>();

        contadorNumGO = GameObject.Find("ContadorDeNumeros");
        contadoNumComp = contadorNumGO.GetComponent<SpriteRenderer>();

        controladorCocheGO = GameObject.Find("PlayerController");
        cocheGO = GameObject.Find("Coche");

        InicioCuentaAtras();
    }
	
    void InicioCuentaAtras()
    {
       StartCoroutine(ParaAtras());
    }

    IEnumerator ParaAtras()
    {
        controladorCocheGO.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2f);

        contadoNumComp.sprite = numeros[1];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1f);

        contadoNumComp.sprite = numeros[2];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1f);

        contadoNumComp.sprite = numeros[3];
        motorCarrScript.inicio_juego = true;
        contadorNumGO.GetComponent<AudioSource>().Play();
        cocheGO.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2f);

        contadorNumGO.SetActive(false);


    }


	void Update ()
    {
        if (motorCarrScript.termino_juego)
        {
            cocheGO.GetComponent<AudioSource>().Stop();
        }
	}
}
