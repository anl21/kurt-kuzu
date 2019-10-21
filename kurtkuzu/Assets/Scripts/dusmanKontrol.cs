using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class dusmanKontrol : MonoBehaviour
{
    public NavMeshAgent takip_et;
    public GameObject hedef_kup;
    //public GameObject[] dogum_Noktasi;

    void Start()
    {

        takip_et = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        takip_et.destination = hedef_kup.transform.position;
        //Instantiate(gameObject, transform.position, transform.rotation);
    }
}
