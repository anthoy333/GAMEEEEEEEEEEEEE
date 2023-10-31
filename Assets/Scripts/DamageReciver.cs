using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReciver : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the GameObject
    public int currentHealth; // Current health of the GameObject
    public int damage;
    private void Start()
    {
        // Initialize current health to max health when the object is created
        currentHealth = maxHealth;
    }

    // Method to take damage
    public void TakeDamage(int damage)
    {
        // Reduce the current health by the damage amount
        currentHealth -= damage;

        // Check if the object's health has reached or fallen below zero
        if (currentHealth <= 0)
        {
            Die(); // Handle the object's death
        }
    }

    // Method to handle the object's death
    private void Die()
    {
        // Perform any necessary actions when the object dies, such as destroying it
        Destroy(gameObject);
    }
}
