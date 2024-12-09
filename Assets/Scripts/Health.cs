using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] float currentHealthNumber;
    [SerializeField] float maxHealth = 100;
    [SerializeField] float healNumber = 10;
    GameOver gameOver;
    [SerializeField] Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealthNumber = maxHealth;
        gameOver = GameObject.Find("GameManager").GetComponent<GameOver>();
        GameEvents.CollectibleEarned.AddListener(Heal);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = currentHealthNumber/maxHealth;
    }
    public void TakeDamage(float damage)
    {
        currentHealthNumber -= damage;
        GameEvents.PlayerHurt.Invoke();
        if (IsDead())
        {
            currentHealthNumber = 0;
            GameEvents.PlayerDied.Invoke();
            gameOver.PlayerJustDied();
        }
    }

    public bool IsDead()
    {
        return currentHealthNumber <= 0;
    }
    void Heal() 
    {
        currentHealthNumber += healNumber;
        if (currentHealthNumber >= maxHealth) 
        { 
            currentHealthNumber = maxHealth; 
        }
    }
}
