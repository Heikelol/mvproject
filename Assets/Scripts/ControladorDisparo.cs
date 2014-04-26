using UnityEngine;
using System.Collections;

public class ControladorDisparo : MonoBehaviour
{

    private Animator animator;
    private float velocidad = 1.5f;
    public GameObject enemigo;
    private EventLog log;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        log = GameObject.Find("UI").GetComponent<EventLog>();
    }
    
    // Update is called once per frame
    void Update()
    {
    
    }

    void FixedUpdate()
    {
        if (enemigo != null)
        {
            if (Vector3.Distance(transform.position, enemigo.transform.position) > 0.37)
            {
                rigidbody2D.velocity = new Vector2(velocidad, 0);
            } else
            {
                animator.SetBool("cercaDeEnemigo", true);
                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9 && animator.GetCurrentAnimatorStateInfo(0).IsName("disparoFinal"))
                {
                    enemigo.GetComponent<ControladorEnemigo>().hacerDaño(20);
                    log.añadirEvento("Daño: 20");
                    Destroy(gameObject);
                }
            }
        } else
        {
            Destroy(gameObject);
        }
    }
}
