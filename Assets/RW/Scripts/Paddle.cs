
using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    public float paddleSpeed = 5.0f;

    private Rigidbody2D paddleRigidbody;
    private Vector2 moveDirection = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        paddleRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        paddleRigidbody.position += new Vector2(moveDirection.x * Time.deltaTime, 0);
    }

    public void OnMove(InputValue input)
    {
         moveDirection = input.Get<Vector2>() * paddleSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //1
        if (collision.gameObject.tag.Equals("Cog"))
        {
            //2
            LeanTween.cancel(gameObject);
            //3
            LeanTween.moveY(gameObject, transform.position.y - 0.5f, 0.5f).setEaseShake();
        }
    }
}
