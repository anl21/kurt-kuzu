using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoturret : MonoBehaviour
{
    private Transform target;

    [Header("Özellikler")]

    public float range = 15f;
    public float fireRate = 1f;
    private float firecountdown = 0f;

    public string enemyTag = "Enemy";

    public Transform rotatingpart;
    public float turretturningspeed = 5f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        //hedefe kitlenme 
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotatingpart.rotation, lookRotation, Time.deltaTime * turretturningspeed).eulerAngles;
        rotatingpart.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (firecountdown <= 0f)
        {
            Shoot();
            firecountdown = 1f / fireRate;
        }

        firecountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet bullet = bulletGo.GetComponent<bullet>();
        if (bullet != null)
            bullet.Seek(target);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
