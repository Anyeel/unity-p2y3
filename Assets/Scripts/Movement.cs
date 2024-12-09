using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 movementInput;
    [SerializeField] float speed = 6;
    private bool gameRunning = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movementInput = Vector2.zero;

        if (gameRunning == true)
        {
            if (Input.GetKey(KeyCode.W))                                 // Almacena información sobre el input de a donde se quiere mover
            {
                movementInput.y++;
            }
            if (Input.GetKey(KeyCode.A))
            {
                movementInput.x--;
            }
            if (Input.GetKey(KeyCode.S))
            {
                movementInput.y--;
            }
            if (Input.GetKey(KeyCode.D))
            {
                movementInput.x++;
            }
        }

        if (movementInput.y != 0 && movementInput.x != 0)                // Comprobamos si el jugador se mueve en diagonal y normalizamos el vector
        {
            movementInput = movementInput.normalized;
        }

        transform.position += speed * movementInput * Time.deltaTime;    // Modificamos la posición
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //print("hit");
    }

    public void GameIsOver()
    {
        gameRunning = false;
    }
}
