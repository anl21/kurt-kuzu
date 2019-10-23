using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI scoretext;
    public GameObject ototur1, ototur2;
    public GameObject tur1, tur2;


    private void Awake()
    {
        instance = this;
    }

    public int score = 0;
    private void Start()
    {
        scoretext.text = ("Score");
    }

    private void Update()
    {
        AddScore();
        Debug.Log(score);
        if(score == 2)
        {
            ototur1.SetActive(true);
        }
        else if (score == 4)
        {
            ototur2.SetActive(true);
        }
    }

    public void AddScore()
    {
        scoretext.text = (score).ToString();
    }

    public void Ototur1()
    {
        tur1.SetActive(true);
    }

    public void Ototur2()
    {
        tur2.SetActive(true);
    }
}
