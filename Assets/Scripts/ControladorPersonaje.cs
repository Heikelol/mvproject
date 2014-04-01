using UnityEngine;
using System.Collections;

public class ControladorPersonaje : MonoBehaviour
{
    private float tiempo;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float desplazamiento = Input.GetAxis("Horizontal");
        if (desplazamiento > 0)
        {
            rigidbody2D.velocity = new Vector2(1, 0);
            tiempo = 1;
        } else if (desplazamiento < 0)
        {
            rigidbody2D.velocity = new Vector2(-1, 0);
            tiempo = 1;
        }
        if (tiempo > 0)
        {
            tiempo -= Time.deltaTime;
        } else
        {
            rigidbody2D.velocity = new Vector2(0, 0);
        }
    }
}
