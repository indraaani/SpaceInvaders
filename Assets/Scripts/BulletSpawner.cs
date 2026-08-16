using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject shipGun;
    [SerializeField] private float bulletOffset = 2f;

        public void SpawnBullet()
    {

       Instantiate(Bullet, new Vector3(shipGun.transform.position.x, shipGun.transform.position.y, shipGun.transform.position.z + bulletOffset), transform.rotation);        

    }
}
