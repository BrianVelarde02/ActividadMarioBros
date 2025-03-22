using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ControlarPersonaje : MonoBehaviour
{   
    public float velocidad;
    public float fuerzaSalto;
    private Rigidbody2D rigid; // Para acceder rapido al rigidBody
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

    void Movimiento()
    {   
        float Movimiento = Input.GetAxis("Horizontal");
        if(Movimiento != 0f ){
            anima.SetBool("IsRunning", true);
        }
        else{
            anima.SetBool("IsRunning", false);
        }
        
        rigid.linearVelocity = new Vector2(Movimiento * velocidad, rigid.linearVelocityY);
        orientacion(Movimiento);
    }

    void Salto()
    {
        if(Input.GetKeyDown(KeyCode.Space)== true && EstaEnSuelo() ){
            rigid.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
        if(EstaEnSuelo()== true){
            anima.SetBool("IsJumping", false);
        }
        else{
            anima.SetBool("IsJumping", true);
        }
        
    }

    bool EstaEnSuelo()
    {
        RaycastHit2D RCH = Physics2D.BoxCast(cajaDecolision.bounds.center, new Vector2(cajaDecolision.bounds.size.x, cajaDecolision.bounds.size.y), 0f, Vector2.down, 0.1f, CapaSuelo);
        return RCH.collider != null;

    }

    void orientacion(float Movimiento)
    {
        if( Derecha == true && Movimiento < 0 ||Derecha == false && Movimiento > 0 ){
            Derecha = !Derecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

}
