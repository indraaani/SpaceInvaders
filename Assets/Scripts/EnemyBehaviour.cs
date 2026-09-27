using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class EnemyBehaviour : MonoBehaviour
{

    public LogicScript logic;
    [SerializeField] private int enemyHealth;
    [SerializeField] private TextMeshPro enemyHealthText;
    public Transform shipLocation;
    [SerializeField] private float speed = 0.1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()

    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        shipLocation = GameObject.FindGameObjectWithTag("Ship").GetComponent<Transform>();
        UpdateEnemyHealth();
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, shipLocation.position, step);
    }

  private void OnTriggerEnter2D(Collider2D collision)
    {

    if (collision.attachedRigidbody == null)
        {
          return;
        }

    if (collision.attachedRigidbody.gameObject.tag == "Bullet" && enemyHealth > 0)
        {
            enemyHealth = enemyHealth -1;
            UpdateEnemyHealth();
            
        }

    if (collision.attachedRigidbody.gameObject.tag == "Bullet" && enemyHealth <= 0)
        {
            Destroy(gameObject);
            logic.AddScore();
        }

    if (collision.attachedRigidbody.gameObject.tag == "Ship")
        {
            Destroy(gameObject);
        }
    }

    public void UpdateEnemyHealth()
    {
        enemyHealthText.text = enemyHealth.ToString();
    }
}
