using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuentaBolos : MonoBehaviour
{
    public int numeroDeBolos;
    public ControlDatosJuego datosJuego;
    private bool entroo;
    void Start()
    {
        numeroDeBolos= 0;
        datosJuego = GameObject.Find("DatosJuego").GetComponent<ControlDatosJuego>();
        entroo= false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        Debug.Log(collision.gameObject.tag);
     
        if (collision.gameObject.tag == "Bolo" && !entroo)
        {
            numeroDeBolos++;
            datosJuego.Puntuacion++;
            entroo = true;
            Debug.Log("Entroo");

        }
         
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Bolo" && entroo)
        {
            numeroDeBolos--;

            datosJuego.Puntuacion--;

            entroo = false;

            Debug.Log("Salio");

        }
    }
}
