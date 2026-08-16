using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public LogicScript logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.attachedRigidbody.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            logic.AddScore();
        }
    }
}
