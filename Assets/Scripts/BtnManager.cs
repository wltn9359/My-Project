using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnManager : MonoBehaviour {

    public List<GameObject> Warning;
    public List<GameObject> Fighting;

    public GameObject War;
    public GameObject close;
    public GameObject WarSpawn;

    public GameObject[] Fast;
    public GameObject[] EnemyQ;
    public GameObject[] Players;
    public GameObject[] Enemys;
    public GameObject[] QuestBtn;
    public GameObject[] EnemySpawn;
    public GameObject[] PlayerSpawn;

    public float StayTime;
    public float DelTime;
    
    
  



    private static BtnManager _instance = null;
    public static BtnManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(BtnManager)) as BtnManager;
                if (_instance == null)
                {
                    Debug.Log("ERROR");
                }
            }
            return _instance;
        }
    }

    void Start ()
    {

        Players = GameObject.FindGameObjectsWithTag("Player");

	}

	void Update ()
    {
       
     


    }

    public void ViewQuest()
    {
        QuestBtn[0].SetActive(false);
        QuestBtn[1].SetActive(true);
        close.SetActive(true);
        Time.timeScale = 0; 

    }

    public void CloseQuest()
    {
        QuestBtn[0].SetActive(true);
        QuestBtn[1].SetActive(false);
        close.SetActive(false);
        Time.timeScale = 1;
    }


    public void ViewMenu()
    {

        QuestBtn[1].SetActive(true);

    }

    public void CloseMenu()
    {

        QuestBtn[1].SetActive(false);

    }


    public void Quest1()
    {
        QuestBtn[1].SetActive(false);
        close.SetActive(false);
        Time.timeScale = 1;

        Instantiate(EnemyQ[0], EnemySpawn[0].transform.position, EnemySpawn[0].transform.rotation);
        Instantiate(EnemyQ[1], EnemySpawn[1].transform.position, EnemySpawn[1].transform.rotation);

        Players = GameObject.FindGameObjectsWithTag("Player");
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");

        Instantiate(War, WarSpawn.transform.position, WarSpawn.transform.rotation);
        //Players[0].GetComponent<PlayerState>().Playerstate = PlayerState.PLAYERSTATE.FIND;
    }

    public void Quest2()
    {

    }

    public void Quest3()
    {

    }

    public void X1()
    {
        Fast[0].SetActive(false);
        Fast[1].SetActive(true);
        Time.timeScale = 2f;
    }

    public void X2()
    {
        Fast[1].SetActive(false);
        Fast[2].SetActive(true);
        Time.timeScale = 3;
    }

    public void X3()
    {
        Fast[2].SetActive(false);
        Fast[0].SetActive(true);
        Time.timeScale = 1;
    }
}
