

using UnityEngine;

public class bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;

    public GameObject impacteffect;
    dusmanKontrol dk;
    GameManager gm;

    public void Start()
    {
        dk = GetComponent<dusmanKontrol>();
        gm = GetComponent<GameManager>();
    }
    public void Seek(Transform _target)
    {
        target = _target;
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }


    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impacteffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        dusmanKontrol.instance.can -= 1;
       if(dusmanKontrol.instance.can == 0)
        {
            Destroy(target.gameObject);
            GameManager.instance.score += 1;
        }

        Destroy(gameObject);
    }

}
