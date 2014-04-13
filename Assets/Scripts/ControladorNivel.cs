using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControladorNivel : MonoBehaviour
{

    private Object nivel;
    private Object enemigo;
    private List<GameObject> niveles;
    private List<GameObject> enemigos;

    void Awake()
    {
        niveles = new List<GameObject>();
        enemigos = new List<GameObject>();
    }

    // Use this for initialization
    void Start()
    {
        nivel = Resources.Load("Nivel");
        GameObject n = Instantiate(nivel, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        n.transform.parent = transform;
        niveles.Add(n);
        int numEnemigos = Random.Range(2, 5);
        enemigo = Resources.Load("Enemigo");
        for (int i = 0; i < numEnemigos; i++)
        {
            float posicion = Screen.width / 100.0f * (i + 1);
            enemigos.Add(Instantiate(enemigo, new Vector3(posicion, 0.055f, 0), Quaternion.identity) as GameObject);
        }
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

    public GameObject enemigoMasCercano(Vector3 posicion)
    {
        GameObject enemigo = null;
        float distancia = float.MaxValue;
        for (int i = 0; i < enemigos.Count; i++)
        {
            GameObject e = enemigos [i];
            if (e == null)
            {
                enemigos.Remove(e);
                i--;
            } else
            {
                float d = Vector3.Distance(posicion, e.transform.position);
                if (d < distancia)
                {
                    distancia = d;
                    enemigo = e;
                }
            }
        }
        return enemigo;
    }
}
