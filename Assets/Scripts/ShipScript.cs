using UnityEngine;

public class ShipScript : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    public bool shipIsAlive = true;
    [SerializeField] private Rigidbody2D Bullet;
    [SerializeField] private GameObject shipGun;
    [SerializeField] private float bulletOffset;
    [SerializeField] private float bulletSpeed;
    public LogicScript logic;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
          logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 270f));
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

        if (Input.GetKeyUp(KeyCode.Space))
        {
            SpawnBullet();
        }
    }
    private void SpawnBullet()
    {

       Rigidbody2D NewBullet = Instantiate(Bullet, new Vector3(shipGun.transform.position.x, shipGun.transform.position.y, shipGun.transform.position.z + bulletOffset), transform.rotation);       
       NewBullet.AddForce(NewBullet.transform.up * bulletSpeed);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.collider.attachedRigidbody == null)
       {
         return;
       }

    if ((shipIsAlive == true) && (collision.collider.attachedRigidbody.gameObject.tag == "Enemy"))

        {
            Destroy(gameObject);
            shipIsAlive = false;
            logic.GameOver();

        }
       
    }
}