using UnityEngine;

public class EnemyDefault : MonoBehaviour
{
    public float damageAmount = 25f;
    public float enemyHealth = 50;
    public float enemyCurrentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyCurrentHealth = enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth player = collision.GetComponent<PlayerHealth>();
            player.TakeDamage(damageAmount);
        }
    }

    public void EnemyTakeDamage(float amount)
    {
        enemyCurrentHealth -= amount;
        enemyCurrentHealth = Mathf.Clamp(enemyCurrentHealth, 0, enemyHealth); // prevents negative damage

        if (enemyCurrentHealth <= 0)
        {
            Destroy(gameObject);
        }

    }
}
