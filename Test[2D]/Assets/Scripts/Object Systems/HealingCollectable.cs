using UnityEngine;

public class HealingCollectable : MonoBehaviour
{
    [SerializeField]
    private int _healAmount = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal(_healAmount);
            }
            Destroy(gameObject);
        }
    }
}
