using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using DG.Tweening;
public class Manager : MonoBehaviour
{
    public static Manager instance = null;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    public Text Altın;
    public GameObject Win;
    public GameObject Over;
    public GameObject Pause;
    public Collider Winner;
    public int Gold = 0;
    private bool thetime = true;
    public bool thegame = false;
    void Start()
    {
        Time.timeScale = 0;
    }
    public void GameOver()
    {
        Over.SetActive(true);
        Time.timeScale = 0;
        thegame = false;
    }

    // Update is called once per frame
    public void GameWin()
    {
        Win.SetActive(true);
        Gold += 100;
        Time.timeScale = 0;
        thegame = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (thetime)
            {
                Pause.SetActive(true);
                thegame = false;
                thetime = false;
                Time.timeScale = 0;
            }
            else
            {
                Pause.SetActive(false);
                thegame = true;
                thetime = true;
                Time.timeScale = 1;
            }
        }
        if (!thegame && Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }

    }
    private void OnTriggerEnter(Collider Winner)
    {
        GameWin();
    }

    public void Collect_Gold()
    {
        Gold += 20;
        Debug.Log("Golded");
        Altın.text = "Gold:"+Gold.ToString();
    }
}
