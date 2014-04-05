using UnityEngine;
using System.Collections;
using System.Data;
using Mono.Data.SqliteClient;

public class DAO : MonoBehaviour
{

    private IDbConnection conexion;
    private IDbCommand comando;
    private IDataReader lector;
    // Use this for initialization
    void Start()
    {
        conexion = new SqliteConnection("URI=file:database.sqlite");
        conexion.Open();
        comando = conexion.CreateCommand();
    }
    
    // Update is called once per frame
    void Update()
    {
    
    }

    void OnDestroy()
    {
        comando.Dispose();
        conexion.Close();
    }
}
