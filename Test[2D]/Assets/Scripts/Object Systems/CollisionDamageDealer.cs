using UnityEngine;

public class CollisionDamageDealer : MonoBehaviour
{
    [SerializeField]
    private int _damageAmount = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(_damageAmount);
            }
            Destroy(gameObject);
        }

    }
}
