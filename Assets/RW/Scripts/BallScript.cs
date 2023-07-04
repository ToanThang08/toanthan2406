using UnityEngine;
using UnityEngine.InputSystem;

public class BallScript : MonoBehaviour
{
    static public float BallSpeed = 5.0f;

    private float hitPosition = 0;
    private Vector2 direction;
    private Rigidbody2D ballRigidbody;

    public AnimationCurve animationCurve;

    private void Awake()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody.velocity = Vector2.down * BallSpeed;
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            hitPosition = (ballRigidbody.position.x - collision.rigidbody.position.x) / collision.collider.bounds.size.x;
            direction = new Vector2(hitPosition, 1).normalized;
            ballRigidbody.velocity = direction * BallSpeed;
        }
        // 1
        LeanTween.cancel(gameObject);
        transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        // 2
        LeanTween.scale(gameObject, new Vector3(1.0f, 1.0f), 1.0f).setEase(animationCurve);

        gameObject.LeanColor(Color.yellow, 0.5f).setEasePunch();
    }

}
