using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Cronometro : MonoBehaviour {

    public GameObject motorCarreteraGO;
    public MotorDeCarreteras motorCarreteraScript;

    public float tiempo;
    public float distancia;

    public Text tiempoTxt;
    public Text DistanciaTxt;

	void Start ()
    {
        motorCarreteraGO = GameObject.Find("MotorCarreteras");
        motorCarreteraScript = motorCarreteraGO.GetComponent<MotorDeCarreteras>();

        tiempoTxt.text = "2:00";
        DistanciaTxt.text = "0";
	}

    void Update()
    {
        if (motorCarreteraScript.inicio_juego == true && motorCarreteraScript.termino_juego == false)
        {
            CalculoTiempDistance();
        }
        
        if(tiempo<=0 && motorCarreteraScript.termino_juego == false)
        {
            motorCarreteraScript.termino_juego = true;
        }
        
	}

    public void CalculoTiempDistance()
    {
        distancia += Time.deltaTime * motorCarreteraScript.speed;
        //hacemos un cast
        DistanciaTxt.text = ((int)distancia).ToString();

        tiempo -= Time.deltaTime;
        int minutos = (int)tiempo / 60;
        int segundos = (int)tiempo % 60;
        tiempoTxt.text = minutos.ToString() + ":" + segundos.ToString().PadLeft(2, '0');
    }
}
