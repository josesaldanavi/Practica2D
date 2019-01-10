using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocheObstaculo : MonoBehaviour {
    public SoundFXController sound;
    public MotorDeCarreteras motorDeCarreterasScript;
    public float desacelerar;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Coche>()!=null)
        {
            sound.ChoqueCoche();
            motorDeCarreterasScript.speed -= desacelerar;
            Destroy(gameObject);
        }
    }

}
/*meta: hacer que el motor carreteras pierda velocidad y que por ende no avance tantos metros y que cada vez que 
choca que salga un sonido de choque */
