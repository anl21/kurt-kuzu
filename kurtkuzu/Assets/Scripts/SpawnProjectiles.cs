using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectiles : MonoBehaviour
{
    public GameObject firepoint;
    public Vector3 firepointPos;
    public List<GameObject> vfx = new List<GameObject>();
    public RotateToMouse rotateToMouse;

    private GameObject effectToSpawn;
    private float timeToFire = 0;

    void Start()
    {
        effectToSpawn = vfx[0];

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / effectToSpawn.GetComponent<ProjectileMove>().fireRate;
            firepointPos = firepoint.transform.position;
            SpawnFx();
        }
    }

    void SpawnFx()
    {
        GameObject vfx;
        if (firepoint != null)
        {
            vfx = Instantiate(effectToSpawn, firepointPos, Quaternion.identity);
            if (rotateToMouse != null)
            {
                vfx.transform.localRotation = rotateToMouse.GetRotation();
            }

        }
        else
        {
            Debug.Log("No point");
        }
    }
}
