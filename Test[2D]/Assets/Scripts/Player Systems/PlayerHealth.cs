using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int _maxHealth = 3;
    private int _currentHealth;
    private Action<int> _onHealthChanged;
    void Start()
    {
        _currentHealth = _maxHealth;
        _onHealthChanged += FindAnyObjectByType<UIHealthManager>().UpdateHealthUI;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _onHealthChanged?.Invoke(_currentHealth);
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Heal(int amount)
    {
        _currentHealth = Mathf.Min(_currentHealth + amount, _maxHealth);
        _onHealthChanged?.Invoke(_currentHealth);
    }
}