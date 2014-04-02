using UnityEngine;
using System.Collections;

public class ControladorPersonaje : MonoBehaviour
{
    private float tiempo;
    private float velocidad = 1;
    private EventLog log;

    // Use this for initialization
    void Start()
    {
        log = GameObject.Find("UI").GetComponent<EventLog>();
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
            rigidbody2D.velocity = new Vector2(velocidad, 0);
            tiempo = 1;
        } else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            log.añadirEvento("<color=blue>Mounstruo se mueve a la izquierda</color>");
            rigidbody2D.velocity = new Vector2(-velocidad, 0);
            tiempo = 1;
        }
        if (tiempo > 0)
        {
            tiempo -= Time.fixedDeltaTime;
        } else
        {
            rigidbody2D.velocity = new Vector2(0, 0);
        }
    }
}
