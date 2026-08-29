using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    [SerializeField] private float spawnRate;
    private float timer = 0;
    public ShipScript ship;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemy();
        ship = GameObject.FindGameObjectWithTag("Ship").GetComponent<ShipScript>();      
    }

    // Update is called once per frame
    void Update()
    {
      if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            SpawnEnemy();
            timer = 0;
        }
        
    }

    void SpawnEnemy()
    {
        if(ship.shipIsAlive == true)
        {
        float spawnX = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
        float spawnY = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
       Instantiate(Enemy, new Vector3(Random.Range(spawnX, spawnY), Random.Range(spawnX, spawnY), 0), transform.rotation);
        }
    }
}