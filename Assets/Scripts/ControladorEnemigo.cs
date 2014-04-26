using UnityEngine;
using System.Collections;

public class ControladorEnemigo : MonoBehaviour
{
    private EventLog log;
    private Animator animator;
    private int vida = 100;

    // Use this for initialization
    void Start()
    {
        log = GameObject.Find("UI").GetComponent<EventLog>();
        animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
            Destroy(gameObject);
    }

    public void hacerDaño(int daño)
    {
        vida -= daño;
    }
}
