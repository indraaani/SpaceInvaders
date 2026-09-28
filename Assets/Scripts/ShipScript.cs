using Unity.VisualScripting;
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
    [SerializeField] public int shipHealth;
    private bool shipIsImmune = false;
    [SerializeField] private float immunityTimer = 2f;
    [SerializeField] private float rotationSpeed = 2f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
          logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
          logic.UpdateShipHealth();
  }

    // Update is called once per frame
    void Update()
    {

        float verticalMovement = Input.GetAxis("Vertical");
        float horizontalMovement = Input.GetAxis("Horizontal");
        
        transform.position += new Vector3(speed * Time.deltaTime * horizontalMovement, speed * Time.deltaTime * verticalMovement, 0f);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            SpawnBullet();
        }

        if (verticalMovement != 0 || horizontalMovement != 0)
        {
            float targetAngle = Mathf.Atan2(verticalMovement, horizontalMovement) * Mathf.Rad2Deg - 90f;  
            Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // if (Input.GetKey(KeyCode.RightArrow))
        // {
        //     transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        //     transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 270f));
        // }

        // if (Input.GetKey(KeyCode.LeftArrow))
        // {
        //     transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
        //     transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));  
        // }

        // if (Input.GetKey(KeyCode.UpArrow))
        // {
        //     transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
        //     transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        // }

        // if (Input.GetKey(KeyCode.DownArrow))
        // {
        //     transform.position -= new Vector3(0f, speed * Time.deltaTime, 0f);
        //     transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 180f));       
        // }

        // if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
        // {
        //     transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
        //     transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 45f));
        // }        

        // if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
        // {
        //     transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
        //     transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -45f));
        // }   

        // if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
        // {
        //     transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
        //     transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 135f));
        // }  

        // if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
        // {
        //     transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
        //     transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -135f));
        // }     
    }
    private void SpawnBullet()
    {

       Rigidbody2D NewBullet = Instantiate(Bullet, new Vector3(shipGun.transform.position.x, shipGun.transform.position.y, shipGun.transform.position.z + bulletOffset), transform.rotation);       
       NewBullet.AddForce(NewBullet.transform.up * bulletSpeed);

    }

    private void GainImmuninty()
    {

        shipIsImmune = true;
        Invoke(nameof(RevokeImmunity), immunityTimer);
    }

    private void RevokeImmunity()
    {
        shipIsImmune = false;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.attachedRigidbody == null || shipIsImmune == true)
         {
           return;
         }

        if ((shipIsAlive == true) && (collider.attachedRigidbody.gameObject.tag == "Enemy") && (shipHealth > 0))
        {
            shipHealth = (shipHealth - 1);
            logic.UpdateShipHealth();
            GainImmuninty();

        }

        if ((shipIsAlive == true) && (collider.attachedRigidbody.gameObject.tag == "Enemy") && (shipHealth <= 0))

        {
            Destroy(gameObject);
            shipIsAlive = false;
            logic.GameOver();

        }
    }

}