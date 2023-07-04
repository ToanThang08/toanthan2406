using UnityEngine;

public class Crates : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //1
        gameObject.GetComponent<Collider2D>().enabled = false;
        //2
        LeanTween.alpha(gameObject, 0.2f, 0.6f);
        //3
        LeanTween.rotateAround(gameObject, collision.GetContact(0).normal, 250.0f, 0.6f).setDestroyOnComplete(true);
        GameManager.Instance.IncreaseScore(1);
        
    }
}
