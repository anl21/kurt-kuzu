using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yonetici : MonoBehaviour
{
    public GameObject dusman;
    public Transform[] DogmaNoktasi;
    void Start()
    {
        InvokeRepeating("dusman_Olustur", 0, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void dusman_Olustur()
    {
        int dgn = Random.Range(0, 8);

        GameObject yeni_dusman = Instantiate(dusman, DogmaNoktasi[dgn].position, Quaternion.identity);
    }
}
