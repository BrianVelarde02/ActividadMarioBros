using UnityEngine;

/**
Detectar si el personaje está en el piso.
Autor: Allan Brenes
*/

public class EstadoPersonaje : MonoBehaviour
{
    
    // Para saber si está traslapando el piso
    // Las variables static es una variable para todos los objetos de la clase
    public static bool enPiso { get; private set;}

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enPiso = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        enPiso = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        enPiso = false;
    }
}
