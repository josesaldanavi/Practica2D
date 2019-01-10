using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorDeCarreteras : MonoBehaviour {

    [Header("Calles")]
    public GameObject contenedorGO;
    public GameObject[] callesArrays;

    public float speed;
    public bool inicio_juego;   
    public bool termino_juego;

    int qCalles = 0;
    int seleccionDecalle;

    public GameObject calle_Anterior;
    public GameObject calle_posterior;

    [Header("cortarPantalla")]
    public Vector3 limitePantalla;
    public float tamañoCalle;
    public bool salioDePantalla;
    public GameObject camaraGo;
    public Camera camara;

    void Start ()
    {
        BuscoCalle();
        camaraGo = GameObject.Find("Main Camera");
        camara = camaraGo.GetComponent<Camera>();
	}
	

	void Update ()
    {
        if (inicio_juego==true && termino_juego==false)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            if (calle_Anterior.transform.position.y + tamañoCalle < limitePantalla.y && salioDePantalla == false)
            {
                salioDePantalla = true;
                //Destruir calle
                DestruyoCalles();
            }
            if (speed <= 0)
            {
                speed = 0;
            }
        }
	}



    void BuscoCalle()
    {
        callesArrays = GameObject.FindGameObjectsWithTag("calle");

        for (int i = 0; i < callesArrays.Length; i++)
        {
            callesArrays[i].gameObject.transform.parent = contenedorGO.transform;
            callesArrays[i].gameObject.SetActive(false);
            callesArrays[i].gameObject.name = "Calle_OFF" + i;
        }
        CrearCalle();
    }

    void CrearCalle()
    {
        qCalles++;
        seleccionDecalle = UnityEngine.Random.Range(0, callesArrays.Length);
        //Se crea una copia del objeto original y lo posiciona en el motor de carreteras("gamemanager")
        GameObject calle = Instantiate(callesArrays[seleccionDecalle]);
        calle.SetActive(true);
        calle.name = "Calle" + qCalles;
        //se vuele hijo del objeto motorCarreteras
        calle.transform.parent = gameObject.transform;
        PosicionoCalle();
    }

    void PosicionoCalle()
    {
        calle_Anterior = GameObject.Find("Calle"+(qCalles-1));
        calle_posterior = GameObject.Find("Calle" + (qCalles));
        MidoCalle();
        calle_posterior.transform.position = new Vector3(calle_Anterior.transform.position.x, calle_Anterior.transform.position.y + tamañoCalle,0);
        salioDePantalla = false;

    }

    void MidoCalle()
    {
        for(int i = 0; i < calle_Anterior.transform.childCount; i++)
        {
            if (calle_Anterior.transform.GetChild(i).gameObject.GetComponent<Pieza>() != null)
            {
                float tamañoPieza = calle_Anterior.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
                tamañoCalle = tamañoCalle + tamañoPieza;
            }

        }
    }

    void MedirPantalla()
    {
        limitePantalla = new Vector3(0, camara.ScreenToWorldPoint(new Vector3(0, 0, 0)).y - 0.5f, 0);
    }

    private void DestruyoCalles()
    {
        Destroy(calle_Anterior);
        tamañoCalle = 0;
        calle_Anterior = null;
        CrearCalle();
    }
}
