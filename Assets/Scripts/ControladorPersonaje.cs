using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControladorPersonaje : MonoBehaviour
{
    private float velocidad = 1;
    private float rango = 2;
    private EventLog log;
    private Animator animator;
    private GameObject enemigo;
    private int vida = 100;
    private int loop;
    private Object disparoPrefab;
    GameObject disparo;

    // Use this for initialization
    void Start()
    {
        log = GameObject.Find("UI").GetComponent<EventLog>();
        animator = GetComponent<Animator>();
        animator.SetBool("moviendose", true);
        disparoPrefab = Resources.Load("Disparo");
    }

    // Update is called once per frame
    void Update()
    {
        if (enemigo == null)
        {
            enemigo = GameObject.Find("Controlador Nivel").GetComponent<ControladorNivel>().enemigoMasCercano(transform.position);
            animator.SetBool("moviendose", true);
            animator.SetBool("enRango", false);
        } else
        {
            if (Vector3.Distance(transform.position, enemigo.transform.position) < rango)
            {
                animator.SetBool("moviendose", false);
                animator.SetBool("enRango", true);
                if (Mathf.FloorToInt(animator.GetCurrentAnimatorStateInfo(0).normalizedTime) > loop)
                {
                    disparo = Instantiate(disparoPrefab, transform.position + new Vector3(0.2f,0.05f,0), Quaternion.identity) as GameObject;
                    disparo.GetComponent<ControladorDisparo>().enemigo = enemigo;
                }
            } else
            {
                animator.SetBool("moviendose", true);
            }
            loop = Mathf.FloorToInt(animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        }
    }

    void FixedUpdate()
    {
        if (animator.GetBool("moviendose") == true)
        {
            rigidbody2D.velocity = new Vector2(velocidad, 0);
        } else
        {
            rigidbody2D.velocity = new Vector2(0, 0);
        }
    }
}
