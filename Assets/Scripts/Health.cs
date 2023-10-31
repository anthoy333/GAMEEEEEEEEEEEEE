using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int playerHealth = 10;
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject player;
    private int PlayerDamage;

    void Start()
    {
        PlayerDamage = player.GetComponent<DamageReciver>().damage;
    }

    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            System.Print("Hi");
            // Player's turn
            if (enemies.Count > 0)
            {
                // Determine which enemy the player is attacking
                int enemyToAttack = GetEnemyToAttack();

                if (enemyToAttack >= 0 && enemyToAttack < enemies.Count)
                {
                    GameObject selectedEnemy = enemies[enemyToAttack];
                    var enemyDamageReceiver = selectedEnemy.GetComponent<DamageReciver>();
                    if (enemyDamageReceiver != null)
                    {
                        enemyDamageReceiver.TakeDamage(PlayerDamage);
                        if (enemyDamageReceiver.currentHealth <= 0)
                        {
                            enemies.RemoveAt(enemyToAttack);
                            Destroy(selectedEnemy);
                        }
                    }
                }
            }
        }

        if (playerHealth <= 0)
        {
            // Player is defeated
            Debug.Log("Player is defeated!");
            player.SetActive(false);
        }
    }

    // Define a method to get the index of the enemy to attack based on user input
    int GetEnemyToAttack()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            // Check if the corresponding key for the enemy is pressed (e.g., "1" for the first enemy, "2" for the second, etc.)
            if (Input.GetKeyDown((i + 1).ToString()))
            {
                return i;
            }
        }
        return -1; // Return -1 if no valid key is pressed
    }
}
