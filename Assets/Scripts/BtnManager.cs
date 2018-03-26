using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnManager : MonoBehaviour {

    public List<GameObject> Warning;
    public List<GameObject> Fighting;
    public List<GameObject> Item;

    public GameObject War;
    public GameObject[] close;
    public GameObject WarSpawn;
    public GameObject PlayerManagers;
    public GameObject Wall;
    public GameObject Shop;
    public GameObject Inshop;
    public GameObject InGotcha;

    public GameObject[] Fast;
    public GameObject[] EnemyQ;
    public List<GameObject> Players;
    public GameObject[] Enemys;
    public GameObject[] QuestBtn;
    public GameObject[] EnemySpawn;
    public GameObject[] PlayerSpawn;
    public GameObject[] slot;
    public GameObject[] PlayerIcon;
    public GameObject[] Pause;

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

    void Start()
    {



    }

    void Update()
    {



    }

    public void ViewQuest()
    {
        Players.Clear();
        QuestBtn[0].SetActive(false);
        QuestBtn[1].SetActive(true);
        close[0].SetActive(true);
        //Players = GameObject.FindGameObjectsWithTag("Player");
        //Players.Add(GameObject.FindGameObjectWithTag("Player"));
        Players.AddRange(GameObject.FindGameObjectsWithTag("Player"));

        //Time.timeScale = 0;

        //if (Players[0].GetComponent<PlayerState>().lookEM.Count > 0)
        //{
        //    Players[0].GetComponent<PlayerState>().lookEM.RemoveAt(0);
        //    Players[1].GetComponent<PlayerState>().lookEM.RemoveAt(0);
        //    Players[2].GetComponent<PlayerState>().lookEM.RemoveAt(0);
        //}
    }

    public void CloseQuest()
    {
        QuestBtn[0].SetActive(true);
        QuestBtn[1].SetActive(false);
        close[0].SetActive(false);
        //Time.timeScale = 1;
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
       
        if (Players.Count > 0)
        {
            QuestBtn[1].SetActive(false);
            close[0].SetActive(false);
            //Time.timeScale = 1
           
          if(Players[0] != null)
            {
                Players[0].GetComponent<PlayerState>().Playerstate = PlayerState.PLAYERSTATE.IDLE;
                Players[0].GetComponent<PlayerState>().Endcol.enabled = true; ;
            }

            if (Players[1] != null)
            {
                Players[1].GetComponent<PlayerState>().Playerstate = PlayerState.PLAYERSTATE.IDLE;
                Players[1].GetComponent<PlayerState>().Endcol.enabled = true; ;
            }

            if (Players[2] != null)
            {
                Players[2].GetComponent<PlayerState>().Playerstate = PlayerState.PLAYERSTATE.IDLE;
                Players[2].GetComponent<PlayerState>().Endcol.enabled = true; ;
            }
         
                
               
               
                
           



            Instantiate(EnemyQ[0], EnemySpawn[0].transform.position, EnemySpawn[0].transform.rotation);
            Instantiate(EnemyQ[1], EnemySpawn[1].transform.position, EnemySpawn[1].transform.rotation);


            Enemys = GameObject.FindGameObjectsWithTag("Enemy");

            //if (Players.Count == 1)
            //{
            //    if (Players[0] != null)
            //    {
            //        slot[0].GetComponent<Slot>().PI[0].GetComponent<Icon>().cha[0].GetComponent<PlayerState>().Playerstate = PlayerState.PLAYERSTATE.IDLE;
            //        slot[0].GetComponent<Slot>().PI[0].GetComponent<Icon>().cha[0].GetComponent<PlayerState>().Endcol.enabled = true;
            //        slot[0].GetComponent<Slot>().PI[0].GetComponent<Icon>().cha[0].GetComponent<PlayerState>().target2 = null;
            //        slot[0].GetComponent<Slot>().PI[0].GetComponent<Icon>().cha[0].GetComponent<PlayerState>().lookEM.Clear();

            //    }
            //}
            //if (Players.Count == 2)
            //{
            //    if (Players[0] != null)
            //    {
            //        slot[0].GetComponent<Slot>().PI[0].GetComponent<Icon>().cha[0].GetComponent<PlayerState>().Playerstate = PlayerState.PLAYERSTATE.IDLE;
            //        slot[0].GetComponent<Slot>().PI[0].GetComponent<Icon>().cha[0].GetComponent<PlayerState>().Endcol.enabled = true;
            //        slot[0].GetComponent<Slot>().PI[0].GetComponent<Icon>().cha[0].GetComponent<PlayerState>().target2 = null;
            //        slot[0].GetComponent<Slot>().PI[0].GetComponent<Icon>().cha[0].GetComponent<PlayerState>().lookEM.Clear();
            //    }
            //    if (Players[1] != null)
            //    {
            //        slot[1].GetComponent<Slot>().PI[0].GetComponent<Icon>().cha[1].GetComponent<PlayerState>().Playerstate = PlayerState.PLAYERSTATE.IDLE;
            //        slot[1].GetComponent<Slot>().PI[0].GetComponent<Icon>().cha[1].GetComponent<PlayerState>().Endcol.enabled = true;
            //        slot[1].GetComponent<Slot>().PI[0].GetComponent<Icon>().cha[1].GetComponent<PlayerState>().target2 = null;
            //        slot[1].GetComponent<Slot>().PI[0].GetComponent<Icon>().cha[1].GetComponent<PlayerState>().lookEM.Clear();
            //    }
            //}
            //if (Players.Count>2)
            //{
            //    if (Players[0] != null)
            //    {
            //        slot[0].GetComponent<Slot>().PI[0].GetComponent<Icon>().cha[0].GetComponent<PlayerState>().Playerstate = PlayerState.PLAYERSTATE.IDLE;
            //        slot[0].GetComponent<Slot>().PI[0].GetComponent<Icon>().cha[0].GetComponent<PlayerState>().Endcol.enabled = true;
            //        slot[0].GetComponent<Slot>().PI[0].GetComponent<Icon>().cha[0].GetComponent<PlayerState>().target2 = null;
            //        slot[0].GetComponent<Slot>().PI[0].GetComponent<Icon>().cha[0].GetComponent<PlayerState>().lookEM.Clear();
            //    }
            //    if (Players[1] != null)
            //    {
            //        slot[1].GetComponent<Slot>().PI[0].GetComponent<Icon>().cha[1].GetComponent<PlayerState>().Playerstate = PlayerState.PLAYERSTATE.IDLE;
            //        slot[1].GetComponent<Slot>().PI[0].GetComponent<Icon>().cha[1].GetComponent<PlayerState>().Endcol.enabled = true;
            //        slot[1].GetComponent<Slot>().PI[0].GetComponent<Icon>().cha[1].GetComponent<PlayerState>().target2 = null;
            //        slot[1].GetComponent<Slot>().PI[0].GetComponent<Icon>().cha[1].GetComponent<PlayerState>().lookEM.Clear();
            //    }
            //    if (Players[2] != null)
            //    {
            //        slot[2].GetComponent<Slot>().PI[0].GetComponent<Icon>().cha[2].GetComponent<PlayerState>().Playerstate = PlayerState.PLAYERSTATE.IDLE;
            //        slot[2].GetComponent<Slot>().PI[0].GetComponent<Icon>().cha[2].GetComponent<PlayerState>().Endcol.enabled = true;
            //        slot[2].GetComponent<Slot>().PI[0].GetComponent<Icon>().cha[2].GetComponent<PlayerState>().target2 = null;
            //        slot[2].GetComponent<Slot>().PI[0].GetComponent<Icon>().cha[2].GetComponent<PlayerState>().lookEM.Clear();
            //    }
              
            //}
            //if (slot[0].GetComponent<Slot>().PI.Count > 0)
            //{
            //    slot[0].GetComponent<Slot>().PI[0].GetComponent<Icon>().cha[0].transform.position = new Vector3(slot[0].GetComponent<Slot>().PR[2].transform.position.x, slot[0].GetComponent<Slot>().PR[2].transform.position.y, slot[0].GetComponent<Slot>().PR[2].transform.position.z);
            //}

            slot[0].GetComponent<Slot>().PI.Clear();

            Instantiate(War, WarSpawn.transform.position, WarSpawn.transform.rotation);
            //Players[0].GetComponent<PlayerState>().Playerstate = PlayerState.PLAYERSTATE.FIND;
        }
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

    public void Change()
    {
        close[1].SetActive(true);
       
        //if (Players.Count==4)
        //{
        //    Item[0].GetComponent<Icon>().cha.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        //    Item[1].GetComponent<Icon>().cha.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        //    Item[2].GetComponent<Icon>().cha.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        //    Item[3].GetComponent<Icon>().cha.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        //}
        //if (Players.Count == 3)
        //{
        //    Item[0].GetComponent<Icon>().cha.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        //    Item[1].GetComponent<Icon>().cha.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        //    Item[2].GetComponent<Icon>().cha.AddRange(GameObject.FindGameObjectsWithTag("Player"));
            
        //}
        //if (Players.Count ==2)
        //{
        //    Item[0].GetComponent<Icon>().cha.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        //    Item[1].GetComponent<Icon>().cha.AddRange(GameObject.FindGameObjectsWithTag("Player"));


        //}
        //if (Players.Count ==1)
        //{
        //    Item[0].GetComponent<Icon>().cha.AddRange(GameObject.FindGameObjectsWithTag("Player"));
           
        //}
        //Players = GameObject.FindGameObjectsWithTag("Player");
    }

    public void ChangeClose()
    {
        close[1].SetActive(false);


    }


    public void Pause1()
    {
        Time.timeScale = 0;
        Pause[0].SetActive(false);
        Pause[1].SetActive(true);
    }


    public void Pause2()
    {
        Pause[0].SetActive(true);
        Pause[1].SetActive(false);

        if (Fast[0] == true)
        {
            Time.timeScale = 1;
        }
        if (Fast[1] == true)
        {
            Time.timeScale = 2;
        }
        if (Fast[2] == true)
        {
            Time.timeScale = 3;
        }


    }


    public void OpenShop()
    {
        Shop.SetActive(true);
        
    }

    public void CloseShop()
    {
        Shop.SetActive(false);
        Players.AddRange(GameObject.FindGameObjectsWithTag("Player"));
       
    }

    public void InShop()
    {
        Inshop.SetActive(true);
        InGotcha.SetActive(false);
    }

    public void InGotCha()
    {

        Inshop.SetActive(false);
        InGotcha.SetActive(true);

    }

    public void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name == "Slot1")
        {
            gameObject.transform.position = new Vector3(-314, 124, 0);
        }

    }
}
