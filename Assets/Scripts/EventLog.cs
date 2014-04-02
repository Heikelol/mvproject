using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EventLog : MonoBehaviour
{
    Queue<string> ultimosEventos;
    // Use this for initialization
    void Start()
    {
        ultimosEventos = new Queue<string>();
    }
    
    // Update is called once per frame
    void Update()
    {
    
    }

    void OnGUI()
    {
        string textoEventos = "";
        for (int i = 0; i < ultimosEventos.Count; i++)
        {
            textoEventos += ultimosEventos.ElementAt(i) + "\n";
        }
        GUIStyle style = GUI.skin.box;
        style.alignment = TextAnchor.UpperLeft;
        GUI.Box(new Rect(Screen.width / 2 - 250, Screen.height - 160, 500, 150), textoEventos, style);
    }

    public void añadirEvento(string evento)
    {
        if (ultimosEventos.Count > 8)
            ultimosEventos.Dequeue();
        ultimosEventos.Enqueue(evento);
    }
}
