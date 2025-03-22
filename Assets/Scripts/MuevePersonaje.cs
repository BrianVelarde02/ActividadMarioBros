using UnityEngine;

public class MuevePersonaje : MonoBehaviour
{
    // Velocidad
    [SerializeField]
    private float velocidadX;

    [SerializeField]
    private float velocidadY;

    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movHorizontal = Input.GetAxis("Horizontal");
        float movVertical = Input.GetAxis("Vertical");

        if (movVertical > 0)
        {
            rb.linearVelocity = new Vector2(movHorizontal * velocidadX * Time.deltaTime, movVertical * velocidadY * Time.deltaTime);
        }
        else {
            rb.linearVelocity = new Vector2(movHorizontal * velocidadX * Time.deltaTime, rb.linearVelocityY);
        }

    }
}
