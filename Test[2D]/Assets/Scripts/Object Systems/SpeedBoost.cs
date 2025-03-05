using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField]
    private float _speedIncreaseAmount = 2f;
    [SerializeField]
    private float _duration = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement playerController = collision.GetComponent<PlayerMovement>();
            if (playerController != null)
            {
                playerController.IncreaseSpeed(_speedIncreaseAmount);
                Invoke("ResetSpeed", _duration);
                Destroy(gameObject,_duration+1);
                gameObject.SetActive(false);
            }
        }
    }

    void ResetSpeed()
    {
        PlayerMovement playerController = FindFirstObjectByType<PlayerMovement>();
        if (playerController != null)
        {
            playerController.DecreaseSpeed(_speedIncreaseAmount);
        }
    }
}
