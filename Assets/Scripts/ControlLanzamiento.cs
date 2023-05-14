using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlLanzamiento : MonoBehaviour
{

    public GameObject bola;
    public Rigidbody2D pivote;

    public float tiempoQuitarSprintJoint;
    public float tiempoFinJuego;

    private Camera camara;

    private Rigidbody2D bolaRigidBody;
    private SpringJoint2D bolaSprintJoint;

    private bool estaArrastrando;
  
    void Start()
    {
        camara= Camera.main;

        bolaRigidBody = bola.GetComponent<Rigidbody2D>();
        bolaSprintJoint = bola.GetComponent <SpringJoint2D>();

        bolaSprintJoint.connectedBody = pivote;
    }

  
    void Update()
    {
        if (bolaRigidBody == null)
        {
            return;
        }

        if (!Touchscreen.current.primaryTouch.press.isPressed)
        {
            if (estaArrastrando)
            {
                LanzarBola();
            }
            estaArrastrando= false;
            return;
        }

        estaArrastrando = true;
        bolaRigidBody.isKinematic = true; // deja de tener control fisico

        Vector2 posicionTocar = Touchscreen.current.primaryTouch.position.ReadValue();
        Vector3 posicionMundo = camara.ScreenToWorldPoint(posicionTocar);
        bolaRigidBody.position= posicionMundo;

        //Debug.Log(posicionTocar.ToString());    


        
    }

    private void LanzarBola()
    {
        bolaRigidBody.isKinematic= false;
        bolaRigidBody = null; // para no hacer nada en el update

        // retraso para desactivar sprintJoin
        Invoke(nameof(QuitarSprintJoin), tiempoQuitarSprintJoint);
    }

    private void QuitarSprintJoin()
    {
        bolaSprintJoint.enabled=false;
        bolaSprintJoint = null;

        Invoke(nameof(FinJuego), tiempoFinJuego);
    }

    private void FinJuego()
    {
        return;
    }
}
