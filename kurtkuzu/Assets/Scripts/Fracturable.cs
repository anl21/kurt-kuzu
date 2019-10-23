using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fracturable : MonoBehaviour
{
    public GameObject fracturedPrefab;
    public bool noScale;
    public float extraFoce = 1f;

    private Rigidbody body;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    public void fraction(bool destroy = true)
    {
        GameObject fractured = Instantiate(fracturedPrefab);
        Rigidbody[]  componentsInChildren = fractured.GetComponentsInChildren<Rigidbody>();
        fractured.transform.position = transform.position;
        if (!noScale)
        {
            fractured.transform.localScale = transform.localScale;
        }
        fractured.transform.rotation = transform.rotation;

        Vector3 velocity = Vector3.zero;
        if (body != null)
        {
            velocity = GetComponent<Rigidbody>().velocity;
        }

        foreach (Rigidbody childBody in componentsInChildren)
        {
            childBody.transform.parent = null;
            childBody.GetComponent<MeshRenderer>().material = base.gameObject.GetComponent<MeshRenderer>().material;
            childBody.velocity = new Vector3(Random.Range(1f, 2f) * velocity.x, Random.Range(1f, 2f) * velocity.y, Random.Range(1f, 2f) * velocity.z) + childBody.transform.localPosition.normalized * Random.Range(0.5f, 1.5f) * extraFoce;
            Destroy(childBody.gameObject, 3f);
        }
        if (destroy)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
        Destroy(fractured);
    }
}
