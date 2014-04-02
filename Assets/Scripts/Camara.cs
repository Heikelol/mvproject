using UnityEngine;
using System.Collections;

public class Camara : MonoBehaviour
{

    public float pixelsPerUnit = 100;
    public int zoom = 1;

    // Use this for initialization
    void Start()
    {  
        Camera.main.orthographicSize = Screen.height / 2f / pixelsPerUnit / zoom;       
    }
    
    // Update is called once per frame
    void Update()
    {
    
    }
}
