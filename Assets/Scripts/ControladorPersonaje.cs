using UnityEngine;
using System.Collections;

public class ControladorPersonaje : MonoBehaviour
{
    private float tiempo;
    private float velocidad = 1;
    private EventLog log;
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        log = GameObject.Find("UI").GetComponent<EventLog>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            log.añadirEvento("<color=green>Mounstruo se mueve a la derecha</color>");
            velocidad = 1;
            tiempo = 1;
            transform.localRotation = new Quaternion(0,0,0,0);
            animator.SetBool("moviendose", true);
        } else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            log.añadirEvento("<color=blue>Mounstruo se mueve a la izquierda</color>");
            velocidad = -1;
            tiempo = 1;
            transform.localRotation = new Quaternion(0,180,0,0);
            animator.SetBool("moviendose", true);
        }
        if (tiempo > 0)
        {
            rigidbody2D.velocity = new Vector2(velocidad, 0);
            tiempo -= Time.fixedDeltaTime;
        } else
        {
            animator.SetBool("moviendose", false);
            rigidbody2D.velocity = new Vector2(0, 0);
        }
    }
}
