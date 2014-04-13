using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControladorPersonaje : MonoBehaviour
{
    private float tiempo;
    private float velocidad = 1;
    private float rango = 2;
    private EventLog log;
    private Animator animator;
    private GameObject enemigo;
    private int vida = 100;
    private float cooldown = 0;

    // Use this for initialization
    void Start()
    {
        log = GameObject.Find("UI").GetComponent<EventLog>();
        animator = GetComponent<Animator>();
        animator.SetBool("moviendose", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemigo == null)
        {
            enemigo = GameObject.Find("Controlador Nivel").GetComponent<ControladorNivel>().enemigoMasCercano(transform.position);
            animator.SetBool("moviendose", true);
        } else
        {
            if (Vector3.Distance(transform.position, enemigo.transform.position) < rango)
            {
                animator.SetBool("moviendose", false);
                animator.SetBool("enRango", true);
                if (cooldown > 0)
                {
                    cooldown -= Time.deltaTime;
                } else
                {
                    cooldown = 1;
                    enemigo.GetComponent<ControladorEnemigo>().hacerDaño(20);
                    log.añadirEvento("Daño: 20");
                }
            } else
            {
                animator.SetBool("moviendose", true);
            }
        }
    }

    void FixedUpdate()
    {
        if (animator.GetBool("moviendose") == true)
        {
            rigidbody2D.velocity = new Vector2(velocidad, 0);
            tiempo -= Time.fixedDeltaTime;
        } else
        {
            rigidbody2D.velocity = new Vector2(0, 0);
        }
    }
}
