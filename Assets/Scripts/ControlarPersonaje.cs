/*En este Script Esta todo lo referido al manejo del personaje
  Autor: Brian Axel Velarde Rodriguez A01753036
*/

using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ControlarPersonaje : MonoBehaviour
{   
    public float velocidad;
    public float fuerzaSalto;
    private Rigidbody2D rigid; 
    private BoxCollider2D cajaDecolision;
    public LayerMask CapaSuelo;
    private bool Derecha = true;
    private Animator anima;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        cajaDecolision = GetComponent<BoxCollider2D>();
        anima = GetComponent<Animator>();
    }
    void Update()
    {
        Movimiento();
        Salto();
    }

    void Movimiento() //Funcion para Hacer el moviemiento del personaje
    {   
        float Movimiento = Input.GetAxis("Horizontal");
        if(Movimiento != 0f ){ // Condicion para saber si es necesario el cambio de animacion
            anima.SetBool("IsRunning", true);
        }
        else{
            anima.SetBool("IsRunning", false);
        }
        
        rigid.linearVelocity = new Vector2(Movimiento * velocidad, rigid.linearVelocityY); // Calcular el movimiento
        orientacion(Movimiento); // Llamamos a la funcion que define la orientacion del personaje
    }

    void Salto() //Funcion del Salto
    {
        if(Input.GetKeyDown(KeyCode.Space)== true && EstaEnSuelo() ){ // Si el personaje esta en el suelo y presionando Espacio se activa el salto
            rigid.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
        if(EstaEnSuelo()== true){ // Comprobamos que el personaje este en el suelo para llamar a su rrespectiva animacion
            anima.SetBool("IsJumping", false);
        }
        else{
            anima.SetBool("IsJumping", true);
        }
        
    }

    bool EstaEnSuelo() //booleano para saber si el personaje esta en el suelo
    {
        RaycastHit2D RCH = Physics2D.BoxCast(cajaDecolision.bounds.center, new Vector2(cajaDecolision.bounds.size.x, cajaDecolision.bounds.size.y), 0f, Vector2.down, 0.1f, CapaSuelo);
        return RCH.collider != null;

    }

    void orientacion(float Movimiento) //Funcion de la orientacion
    {
        if( Derecha == true && Movimiento < 0 ||Derecha == false && Movimiento > 0 ){
            Derecha = !Derecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y); //Cambiamos la orientacion
        }
    }

}
