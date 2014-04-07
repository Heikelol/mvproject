using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControladorNivel : MonoBehaviour
{

    Object nivel;
    List<GameObject> niveles;

    // Use this for initialization
    void Start()
    {
        nivel = Resources.Load("Nivel");
        niveles = new List<GameObject>();
        GameObject n = Instantiate(nivel, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        n.transform.parent = transform;
        niveles.Add(n);
    }
    
    // Update is called once per frame
    void Update()
    {
        float anchoPantalla = Screen.width / 100.0f;
        if (Camera.main.transform.position.x > anchoPantalla * (niveles.Count - 1) && niveles.Count < (Camera.main.transform.position.x + anchoPantalla) / anchoPantalla)
        {
            GameObject n = Instantiate(nivel, new Vector3(anchoPantalla * niveles.Count, 0, 0), Quaternion.identity) as GameObject;
            n.transform.parent = transform;
            niveles.Add(n);
        }
    }
}
