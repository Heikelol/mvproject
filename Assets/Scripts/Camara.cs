using UnityEngine;
using System.Collections;

public class Camara : MonoBehaviour
{

    public float pixelsPerUnit = 100;
    public int zoom = 1;
    public GameObject personaje;

    // Use this for initialization
    void Start()
    {  
        Camera.main.orthographicSize = Screen.height / 2f / pixelsPerUnit / zoom;
        personaje = GameObject.Find("Personaje");
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 posicion = transform.position;
        if (personaje.transform.position.x >= -1.5f)
        {
            posicion.x = personaje.transform.position.x + 1.5f;
            transform.position = posicion;
        }
    }
}
