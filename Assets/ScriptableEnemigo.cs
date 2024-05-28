using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemigoScriptable", menuName = "Enemy")]
public class ScriptableEnemigo : ScriptableObject
{

    [SerializeField] int vida;
    [SerializeField] string nombre;
    [SerializeField] string saludo;

    public string Nombre { get { return nombre; }  }
    public string Saludo { get { return saludo; } }
    public int Vida { get { return vida; } }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
