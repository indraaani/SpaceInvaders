using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private int bulletTolerance = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bounds")
        {
            Destroy(gameObject);

        }

        if(collision.gameObject.tag == "Enemy" && bulletTolerance > 0)
        {
            bulletTolerance = bulletTolerance -1;
        }

        if(collision.gameObject.tag == "Enemy" && bulletTolerance <= 0)
        {
            Destroy(gameObject);
        }

    }
}
