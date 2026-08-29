using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyBehaviour : MonoBehaviour
{

    public LogicScript logic;
    [SerializeField] private int enemyHealth;
    [SerializeField] private TextMeshPro enemyHealthText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        UpdateEnemyHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  private void OnCollisionEnter2D(Collision2D collision)
    {

    if (collision.collider.attachedRigidbody == null)
        {
          return;
        }

    if (collision.collider.attachedRigidbody.gameObject.tag == "Bullet" && enemyHealth > 0)
        {
            enemyHealth = enemyHealth -1;
            UpdateEnemyHealth();
            
        }

    if (collision.collider.attachedRigidbody.gameObject.tag == "Bullet" && enemyHealth <= 0)
        {
            Destroy(gameObject);
            logic.AddScore();
        }
    }

    public void UpdateEnemyHealth()
    {
        enemyHealthText.text = enemyHealth.ToString();
    }
}
