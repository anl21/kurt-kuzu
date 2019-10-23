using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class dusmanKontrol : MonoBehaviour
{
    public static dusmanKontrol instance;
    GameManager gm;
    

    private void Awake()
    {
        instance = this;
    }

    public NavMeshAgent takip_et;
    public GameObject hedef_kup;
    public int can = 2;
    //public GameObject[] dogum_Noktasi;

    void Start()
    {
        gm = GetComponent<GameManager>();
        takip_et = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        takip_et.destination = hedef_kup.transform.position;
       // Can();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "kursun")
        {
            Destroy(gameObject);
            GameManager.instance.score += 1;
        }
    }
}
