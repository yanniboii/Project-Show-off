using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] float bulletSpeed;
    [SerializeField] float cooldown;

    public bool canShoot = true;

    BasicMovement movement;


    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<BasicMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShootBullet()
    {
        StartCoroutine(ShootCooldown());
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);

        Vector3 forceDirection = transform.forward.normalized;
        bullet.GetComponent<Rigidbody>().AddForce(forceDirection * bulletSpeed, ForceMode.Impulse);

        bullet.transform.rotation = Quaternion.LookRotation(forceDirection);

        movement.Shoot();
    }

    IEnumerator ShootCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(cooldown);
        canShoot = true;
    }
}
