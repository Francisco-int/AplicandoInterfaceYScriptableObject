using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, Iinteractuable, ITakeDamage
{
    public ScriptableEnemigo enemyData;
    private int currentHealth;

    void Start()
    {
        currentHealth = enemyData.Vida;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Accion()
    {
        Debug.Log(enemyData.Saludo);
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log(enemyData.Nombre + " has been defeated!");
        Destroy(gameObject);
    }
}
