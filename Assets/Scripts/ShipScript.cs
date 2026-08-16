using UnityEngine;

public class ShipScript : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    public bool shipIsAlive = true;
    public BulletSpawner bullet;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 270f));
            //transform.rotation = new Quaternion(0f, 0f, 90f, 0f);   
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
                  transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));  
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= new Vector3(0f, speed * Time.deltaTime, 0f);
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 180f));       
        }

        if (Input.GetKey(KeyCode.Space))
        {
            bullet.SpawnBullet();
        }
    }
        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (shipIsAlive == true)
        {
            shipIsAlive = false;
            Debug.Log("game over");
        }
    }
}