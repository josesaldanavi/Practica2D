using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Limit
{
    public float xMin, xMax,yMin,yMax;
}
public class ControladorCoche : MonoBehaviour {

    public GameObject cocheGO;
    public Limit limite;
    public float anguloGiro;
    public float velocidad;
    public Rigidbody2D rgbd;
    public MotorDeCarreteras motorScript;

	void Start ()
    {
        cocheGO = GameObject.FindObjectOfType<Coche>().gameObject;
	}
	

	void Update ()
    {
        /*float giroZ = 0;
        transform.Translate(Vector2.right * Input.GetAxis("Horizontal")*velocidad*Time.deltaTime);

        giroZ = Input.GetAxis("Horizontal") * anguloGiro;
        cocheGO.transform.rotation = Quaternion.Euler(0f, 0f, -giroZ);*/
        
	}

    private void FixedUpdate()
    {
        if (motorScript.inicio_juego) {
            float horizontal = Input.GetAxis("Horizontal");
            float giroZ = 0;

            Vector2 v_2 = new Vector2(horizontal, 0f);
            rgbd.velocity = v_2 * velocidad * Time.deltaTime * 10;
            rgbd.position = new Vector3(Mathf.Clamp(rgbd.position.x, limite.xMin, limite.xMax), Mathf.Clamp(rgbd.position.y, limite.yMin, limite.yMax), 0);
            giroZ = horizontal * anguloGiro;

            //otorga un giro y posicionamiento seguro lol 
            cocheGO.transform.rotation = Quaternion.Euler(0f, 0f, -giroZ);
        }
    }
}
