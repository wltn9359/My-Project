using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnManager : MonoBehaviour {

    public GameObject WarSpawn;
    public GameObject[] Fast;
    public GameObject[] EnemyQ;
    public GameObject[] PlayerQ;
    public float StayTime;
    public float DelTime;
    public GameObject[] QuestBtn;
    public GameObject close;
    public GameObject[] EnemySpawn;
    public GameObject[] PlayerSpawn;
    public List<GameObject> Fighting;
    public GameObject War;
    public List<GameObject> Warning;


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

        if (War.transform.position.x<-1260)
        {
            War.transform.position = new Vector3(1280,transform.position.y,transform.position.z);
        }
        Time.timeScale = 1;
        QuestBtn[1].SetActive(false);
        close.SetActive(false);
        if (Warning.Count == 0)
        {
            Instantiate(EnemyQ[0], EnemySpawn[0].transform.position, EnemySpawn[0].transform.rotation);
            Instantiate(EnemyQ[1], EnemySpawn[1].transform.position, EnemySpawn[1].transform.rotation);
            Fighting.Add(EnemyQ[0]);
            Fighting.Add(EnemyQ[1]);
            
            if (Fighting.Count == 0)
            {
                QuestBtn[0].SetActive(false);
                GetComponent<PlayerState>().Playerstate = PlayerState.PLAYERSTATE.FIND;
            }
        }
        Instantiate(War, WarSpawn.transform.position, WarSpawn.transform.rotation);
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
