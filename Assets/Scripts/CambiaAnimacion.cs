using UnityEngine;

/**
Aqui se modifican los cambios en el animator
Brian Axel Velarde
*/

public class CambiaAnimacion : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spRenderer;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MueveAccionPersonaje.velocity.x < 0)
        {
            spRenderer.flipX = true;
        } else {
            spRenderer.flipX = false;
        }

        // Animator
        animator.SetFloat("velocidad", MueveAccionPersonaje.velocity.magnitude);
        animator.SetBool("enPiso", EstadoPersonaje.enPiso);
    }
}
