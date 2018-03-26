using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icon : MonoBehaviour
{
    
    public GameObject[] Slot;
    public List<GameObject> Items;
    public List<GameObject> Slots;
    public List<GameObject> Conts;
    public List<GameObject> Players;
    public GameObject Btn;
    public Collider Ennd;

    //public List<GameObject> Item;
    public List<GameObject> cha;
    public List<GameObject> PL;

    void Awake()
    {
        
        cha.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        Btn = GameObject.FindGameObjectWithTag("Btn");
        Ennd = GetComponent<Collider>();

       
        //Vector3 ConPos = new Vector3(transform.position.x, transform.position.y, 0);
        Items.AddRange(GameObject.FindGameObjectsWithTag("Item"));
        Slot = GameObject.FindGameObjectsWithTag("Slot");
    }

    void Start()
    {

        if (cha.Count == 4)
        {
            Items[3].GetComponent<Icon>().Ennd.enabled = true;
            Items[2].GetComponent<Icon>().Ennd.enabled = true;
            Items[1].GetComponent<Icon>().Ennd.enabled = true;
            Items[3].GetComponent<UITexture>().mainTexture = Resources.Load(cha[3].name) as Texture;
            Items[2].GetComponent<UITexture>().mainTexture = Resources.Load(cha[2].name) as Texture;
            Items[1].GetComponent<UITexture>().mainTexture = Resources.Load(cha[1].name) as Texture;
            Items[0].GetComponent<UITexture>().mainTexture = Resources.Load(cha[0].name) as Texture;
        }
        if (cha.Count == 3)
        {
            Items[3].GetComponent<Icon>().Ennd.enabled = false;
            Items[2].GetComponent<Icon>().Ennd.enabled = true;
            Items[1].GetComponent<Icon>().Ennd.enabled = true;
            Items[2].GetComponent<UITexture>().mainTexture = Resources.Load(cha[2].name) as Texture;
            Items[1].GetComponent<UITexture>().mainTexture = Resources.Load(cha[1].name) as Texture;
            Items[0].GetComponent<UITexture>().mainTexture = Resources.Load(cha[0].name) as Texture;

        }

        if (cha.Count == 2)
        {
            Items[3].GetComponent<Icon>().Ennd.enabled = false;
            Items[2].GetComponent<Icon>().Ennd.enabled = false;
            Items[1].GetComponent<Icon>().Ennd.enabled = true;
            Items[1].GetComponent<UITexture>().mainTexture = Resources.Load(cha[1].name) as Texture;
            Items[0].GetComponent<UITexture>().mainTexture = Resources.Load(cha[0].name) as Texture;
        }

        if (cha.Count == 1)
        {
            Items[3].GetComponent<Icon>().Ennd.enabled = false;
            Items[2].GetComponent<Icon>().Ennd.enabled = false;
            Items[1].GetComponent<Icon>().Ennd.enabled = false;
            Items[0].GetComponent<UITexture>().mainTexture = Resources.Load(cha[0].name) as Texture;
        }

    }


    void Update()
    {
        
          


    }

    public void OnTriggerEnter(Collider col)
    {



        if (col.gameObject.tag == "Back")
        {

            if (Conts.Count > 0)
            {
                gameObject.transform.position = new Vector3(Conts[0].transform.position.x, Conts[0].transform.position.y, Conts[0].transform.position.z);
            }

            if (Slots.Count > 0)
            {
                gameObject.transform.position = new Vector3(Slots[0].transform.position.x, Slots[0].transform.position.y, Slots[0].transform.position.z);
            }

        }

        if (col.gameObject.tag == "Item")
        {
            //Players.Add(col.gameObject);

            //if (col.gameObject.GetComponent<Icon>().Slots.Count > 1)
            //{
            //    gameObject.transform.position = new Vector3(col.gameObject.GetComponent<Icon>().Slots[1].transform.position.x, col.gameObject.GetComponent<Icon>().Slots[1].transform.position.y, col.gameObject.GetComponent<Icon>().Slots[1].transform.position.z);

            //}

            //if (col.gameObject.GetComponent<Icon>().Conts.Count > 1)
            //{
            //    gameObject.transform.position = new Vector3(col.gameObject.GetComponent<Icon>().Conts[1].transform.position.x, col.gameObject.GetComponent<Icon>().Conts[1].transform.position.y, col.gameObject.GetComponent<Icon>().Conts[1].transform.position.z);
            //}

            //if (col.gameObject.GetComponent<Icon>().Slots.Count == 1)
            //{
            //    if (col.gameObject.GetComponent<Icon>().Conts.Count > 0)
            //    {
            //        gameObject.transform.position = new Vector3(col.gameObject.GetComponent<Icon>().Conts[1].transform.position.x, col.gameObject.GetComponent<Icon>().Conts[1].transform.position.y, col.gameObject.GetComponent<Icon>().Conts[1].transform.position.z);
            //    }
            //}

            //Players.RemoveAt(0);

        }




        if (col.gameObject.tag == "Slot")
        {
            Slots.Add(col.gameObject);
            


            if (col.gameObject.name == "Slot1")
            {
                if (gameObject.name == "Item1")
                {
                    cha[0].transform.position = new Vector3(col.gameObject.GetComponent<Slot>().PR[2].transform.position.x, col.gameObject.GetComponent<Slot>().PR[2].transform.position.y, col.gameObject.GetComponent<Slot>().PR[2].transform.position.z);
                    cha[0].SetActive(true);
                    cha[0].GetComponent<PlayerState>().Playerstate = PlayerState.PLAYERSTATE.NONE;
                }
                if (gameObject.name == "Item2")
                {
                    cha[1].transform.position = new Vector3(col.gameObject.GetComponent<Slot>().PR[2].transform.position.x, col.gameObject.GetComponent<Slot>().PR[2].transform.position.y, col.gameObject.GetComponent<Slot>().PR[2].transform.position.z);
                    cha[1].SetActive(true);
                    cha[1].GetComponent<PlayerState>().Playerstate = PlayerState.PLAYERSTATE.NONE;
                }
                if (gameObject.name == "Item3")
                {
                    cha[2].transform.position = new Vector3(col.gameObject.GetComponent<Slot>().PR[2].transform.position.x, col.gameObject.GetComponent<Slot>().PR[2].transform.position.y, col.gameObject.GetComponent<Slot>().PR[2].transform.position.z);
                    cha[2].SetActive(true);
                    cha[2].GetComponent<PlayerState>().Playerstate = PlayerState.PLAYERSTATE.NONE;
                }
                if (gameObject.name == "Item4")
                {
                    cha[3].transform.position = new Vector3(col.gameObject.GetComponent<Slot>().PR[2].transform.position.x, col.gameObject.GetComponent<Slot>().PR[2].transform.position.y, col.gameObject.GetComponent<Slot>().PR[2].transform.position.z);
                    cha[3].SetActive(true);
                    cha[3].GetComponent<PlayerState>().Playerstate = PlayerState.PLAYERSTATE.NONE;
                }
            }

            if (col.gameObject.name == "Slot2")
            {
                if (gameObject.name == "Item1")
                {
                    cha[0].transform.position = new Vector3(col.gameObject.GetComponent<Slot>().PR[1].transform.position.x, col.gameObject.GetComponent<Slot>().PR[1].transform.position.y, col.gameObject.GetComponent<Slot>().PR[1].transform.position.z);
                    cha[0].SetActive(true);
                    cha[0].GetComponent<PlayerState>().Playerstate = PlayerState.PLAYERSTATE.NONE;
                }
                if (gameObject.name == "Item2")
                {
                    cha[1].transform.position = new Vector3(col.gameObject.GetComponent<Slot>().PR[1].transform.position.x, col.gameObject.GetComponent<Slot>().PR[1].transform.position.y, col.gameObject.GetComponent<Slot>().PR[1].transform.position.z);
                    cha[1].SetActive(true);
                    cha[1].GetComponent<PlayerState>().Playerstate = PlayerState.PLAYERSTATE.NONE;
                }
                if (gameObject.name == "Item3")
                {
                    cha[2].transform.position = new Vector3(col.gameObject.GetComponent<Slot>().PR[1].transform.position.x, col.gameObject.GetComponent<Slot>().PR[1].transform.position.y, col.gameObject.GetComponent<Slot>().PR[1].transform.position.z);

                    cha[2].SetActive(true);
                    cha[2].GetComponent<PlayerState>().Playerstate = PlayerState.PLAYERSTATE.NONE;
                }
                if (gameObject.name == "Item4")
                {
                    cha[3].transform.position = new Vector3(col.gameObject.GetComponent<Slot>().PR[1].transform.position.x, col.gameObject.GetComponent<Slot>().PR[1].transform.position.y, col.gameObject.GetComponent<Slot>().PR[1].transform.position.z);
                    cha[3].SetActive(true);
                    cha[3].GetComponent<PlayerState>().Playerstate = PlayerState.PLAYERSTATE.NONE;
                }
            }

            if (col.gameObject.name == "Slot3")
            {
                if (gameObject.name == "Item1")
                {
                    cha[0].transform.position = new Vector3(col.gameObject.GetComponent<Slot>().PR[0].transform.position.x, col.gameObject.GetComponent<Slot>().PR[0].transform.position.y, col.gameObject.GetComponent<Slot>().PR[0].transform.position.z);
                    cha[0].SetActive(true);
                    cha[0].GetComponent<PlayerState>().Playerstate = PlayerState.PLAYERSTATE.NONE;
                }
                if (gameObject.name == "Item2")
                {
                    cha[1].transform.position = new Vector3(col.gameObject.GetComponent<Slot>().PR[0].transform.position.x, col.gameObject.GetComponent<Slot>().PR[0].transform.position.y, col.gameObject.GetComponent<Slot>().PR[0].transform.position.z);
                    cha[1].SetActive(true);
                    cha[0].GetComponent<PlayerState>().Playerstate = PlayerState.PLAYERSTATE.NONE;
                }
                if (gameObject.name == "Item3")
                {
                    cha[2].transform.position = new Vector3(col.gameObject.GetComponent<Slot>().PR[0].transform.position.x, col.gameObject.GetComponent<Slot>().PR[0].transform.position.y, col.gameObject.GetComponent<Slot>().PR[0].transform.position.z);
                    cha[2].SetActive(true);
                    cha[0].GetComponent<PlayerState>().Playerstate = PlayerState.PLAYERSTATE.NONE;
                }
                if (gameObject.name == "Item4")
                {
                    cha[3].transform.position = new Vector3(col.gameObject.GetComponent<Slot>().PR[0].transform.position.x, col.gameObject.GetComponent<Slot>().PR[0].transform.position.y, col.gameObject.GetComponent<Slot>().PR[0].transform.position.z);
                    cha[3].SetActive(true);
                    cha[0].GetComponent<PlayerState>().Playerstate = PlayerState.PLAYERSTATE.NONE;
                }
            }

            if (Conts.Count > 0)
            {
                if (Conts[0].GetComponent<ConT>().ConTp.Count > 0)
                {
                    Conts[0].GetComponent<ConT>().ConTp.RemoveAt(0);
                }
                if (Conts.Count > 0)
                {
                    Conts.RemoveAt(0);
                }
            }

            if (Slots.Count >0)
            {

                if (Slots[0].GetComponent<Slot>().PI.Count > 0)
                {
                    Slots[0].GetComponent<Slot>().PI.RemoveAt(0);
                }
                if (Slots.Count > 1)
                {
                    Slots.RemoveAt(0);
                }

            }

        }

        if (col.gameObject.tag == "Conty")
        {
            cha[0].GetComponent<PlayerState>().gameObject.SetActive(false);
            cha[1].GetComponent<PlayerState>().gameObject.SetActive(false);
            cha[2].GetComponent<PlayerState>().gameObject.SetActive(false);
            cha[3].GetComponent<PlayerState>().gameObject.SetActive(false);
            Conts.Add(col.gameObject);
            if (Btn.GetComponent<BtnManager>().Players.Count > 0)
            {
                if (col.gameObject.name == "Icon1")
                {
                    if (gameObject.name == "Item1")
                    {
                        cha[0].transform.position = new Vector3(col.gameObject.GetComponent<ConT>().PB[3].transform.position.x, col.gameObject.GetComponent<ConT>().PB[3].transform.position.y, col.gameObject.GetComponent<ConT>().PB[3].transform.position.z);
                        //cha[0].SetActive(false);
                        cha[0].GetComponent<PlayerState>().Endcol.enabled = false;

                    }
                    if (gameObject.name == "Item2")
                    {
                        cha[1].transform.position = new Vector3(col.gameObject.GetComponent<ConT>().PB[3].transform.position.x, col.gameObject.GetComponent<ConT>().PB[3].transform.position.y, col.gameObject.GetComponent<ConT>().PB[3].transform.position.z);
                        //cha[1].SetActive(false);
                        cha[1].GetComponent<PlayerState>().Endcol.enabled = false;
                    }
                    if (gameObject.name == "Item3")
                    {
                        cha[2].transform.position = new Vector3(col.gameObject.GetComponent<ConT>().PB[3].transform.position.x, col.gameObject.GetComponent<ConT>().PB[3].transform.position.y, col.gameObject.GetComponent<ConT>().PB[3].transform.position.z);
                        //cha[2].SetActive(false);
                        cha[2].GetComponent<PlayerState>().Endcol.enabled = false;
                    }
                    if (gameObject.name == "Item4")
                    {
                        cha[3].transform.position = new Vector3(col.gameObject.GetComponent<ConT>().PB[3].transform.position.x, col.gameObject.GetComponent<ConT>().PB[3].transform.position.y, col.gameObject.GetComponent<ConT>().PB[3].transform.position.z);
                        //cha[3].SetActive(false);
                        cha[3].GetComponent<PlayerState>().Endcol.enabled = false;
                    }
                }


                if (col.gameObject.name == "Icon2")
                {
                    if (gameObject.name == "Item1")
                    {
                        cha[0].transform.position = new Vector3(col.gameObject.GetComponent<ConT>().PB[2].transform.position.x, col.gameObject.GetComponent<ConT>().PB[2].transform.position.y, col.gameObject.GetComponent<ConT>().PB[2].transform.position.z);
                        //cha[0].SetActive(false);
                        cha[0].GetComponent<PlayerState>().Endcol.enabled = false;
                    }
                    if (gameObject.name == "Item2")
                    {
                        cha[1].transform.position = new Vector3(col.gameObject.GetComponent<ConT>().PB[2].transform.position.x, col.gameObject.GetComponent<ConT>().PB[2].transform.position.y, col.gameObject.GetComponent<ConT>().PB[2].transform.position.z);
                        //cha[1].SetActive(false);
                        cha[1].GetComponent<PlayerState>().Endcol.enabled = false;
                    }
                    if (gameObject.name == "Item3")
                    {
                        cha[2].transform.position = new Vector3(col.gameObject.GetComponent<ConT>().PB[2].transform.position.x, col.gameObject.GetComponent<ConT>().PB[2].transform.position.y, col.gameObject.GetComponent<ConT>().PB[2].transform.position.z);
                        //cha[2].SetActive(false);
                        cha[2].GetComponent<PlayerState>().Endcol.enabled = false;
                    }
                    if (gameObject.name == "Item4")
                    {
                        cha[3].transform.position = new Vector3(col.gameObject.GetComponent<ConT>().PB[2].transform.position.x, col.gameObject.GetComponent<ConT>().PB[2].transform.position.y, col.gameObject.GetComponent<ConT>().PB[2].transform.position.z);
                        //cha[3].SetActive(false);
                        cha[3].GetComponent<PlayerState>().Endcol.enabled = false;
                    }
                }

                if (col.gameObject.name == "Icon3")
                {
                    if (gameObject.name == "Item1")
                    {
                        cha[0].transform.position = new Vector3(col.gameObject.GetComponent<ConT>().PB[1].transform.position.x, col.gameObject.GetComponent<ConT>().PB[1].transform.position.y, col.gameObject.GetComponent<ConT>().PB[1].transform.position.z);
                        //cha[0].SetActive(false);
                        cha[0].GetComponent<PlayerState>().Endcol.enabled = false;
                    }
                    if (gameObject.name == "Item2")
                    {
                        cha[1].transform.position = new Vector3(col.gameObject.GetComponent<ConT>().PB[1].transform.position.x, col.gameObject.GetComponent<ConT>().PB[1].transform.position.y, col.gameObject.GetComponent<ConT>().PB[1].transform.position.z);
                        //cha[1].SetActive(false);
                        cha[1].GetComponent<PlayerState>().Endcol.enabled = false;
                    }
                    if (gameObject.name == "Item3")
                    {
                        cha[2].transform.position = new Vector3(col.gameObject.GetComponent<ConT>().PB[1].transform.position.x, col.gameObject.GetComponent<ConT>().PB[1].transform.position.y, col.gameObject.GetComponent<ConT>().PB[1].transform.position.z);
                        //cha[2].SetActive(false);
                        cha[2].GetComponent<PlayerState>().Endcol.enabled = false;
                    }
                    if (gameObject.name == "Item4")
                    {
                        cha[3].transform.position = new Vector3(col.gameObject.GetComponent<ConT>().PB[1].transform.position.x, col.gameObject.GetComponent<ConT>().PB[1].transform.position.y, col.gameObject.GetComponent<ConT>().PB[1].transform.position.z);
                        //cha[3].SetActive(false);
                        cha[3].GetComponent<PlayerState>().Endcol.enabled = false;
                    }
                }

                if (col.gameObject.name == "Icon4")
                {
                    if (gameObject.name == "Item1")
                    {
                        cha[0].transform.position = new Vector3(col.gameObject.GetComponent<ConT>().PB[0].transform.position.x, col.gameObject.GetComponent<ConT>().PB[0].transform.position.y, col.gameObject.GetComponent<ConT>().PB[0].transform.position.z);
                        //cha[0].SetActive(false);
                        cha[0].GetComponent<PlayerState>().Endcol.enabled = false;
                    }
                    if (gameObject.name == "Item2")
                    {
                        cha[1].transform.position = new Vector3(col.gameObject.GetComponent<ConT>().PB[0].transform.position.x, col.gameObject.GetComponent<ConT>().PB[0].transform.position.y, col.gameObject.GetComponent<ConT>().PB[0].transform.position.z);
                        //cha[1].SetActive(false);
                        cha[1].GetComponent<PlayerState>().Endcol.enabled = false;
                    }
                    if (gameObject.name == "Item3")
                    {
                        cha[2].transform.position = new Vector3(col.gameObject.GetComponent<ConT>().PB[0].transform.position.x, col.gameObject.GetComponent<ConT>().PB[0].transform.position.y, col.gameObject.GetComponent<ConT>().PB[0].transform.position.z);
                        //cha[2].SetActive(false);
                        cha[2].GetComponent<PlayerState>().Endcol.enabled = false;
                    }
                    if (gameObject.name == "Item4")
                    {
                        cha[3].transform.position = new Vector3(col.gameObject.GetComponent<ConT>().PB[0].transform.position.x, col.gameObject.GetComponent<ConT>().PB[0].transform.position.y, col.gameObject.GetComponent<ConT>().PB[0].transform.position.z);
                        //cha[3].SetActive(false);
                        cha[3].GetComponent<PlayerState>().Endcol.enabled = false;
                    }
                }



                if (Slots.Count > 0)
                {
                    if (Slots[0].GetComponent<Slot>().PI.Count > 0)
                    {
                        Slots[0].GetComponent<Slot>().PI.RemoveAt(0);
                    }
                    if (Slots.Count > 0)
                    {
                        Slots.RemoveAt(0);
                    }
                }

                if (Conts.Count > 0)
                {

                    if (Conts[0].GetComponent<ConT>().ConTp.Count > 0)
                    {
                        Conts[0].GetComponent<ConT>().ConTp.RemoveAt(0);
                    }
                    if (Conts.Count > 1)
                    {
                        Conts.RemoveAt(0);
                    }

                    //if (col.gameObject.GetComponent<ConT>().ConTp[0] != null)
                    //{
                    //    gameObject.transform.position = new Vector3(Players[0].transform.position.x, Players[0].transform.position.y, Players[0].transform.position.z);
                    //}


                }
            }
        }

    }

    public void FInd()
    {
        Debug.Log("HI");
        cha.Clear();
            cha.AddRange(GameObject.FindGameObjectsWithTag("Player"));
            if (cha.Count == 4)
            {
                Items[3].GetComponent<Icon>().Ennd.enabled = true;
                Items[2].GetComponent<Icon>().Ennd.enabled = true;
                Items[1].GetComponent<Icon>().Ennd.enabled = true;
                Items[3].GetComponent<UITexture>().mainTexture = Resources.Load(cha[3].name) as Texture;
                Items[2].GetComponent<UITexture>().mainTexture = Resources.Load(cha[2].name) as Texture;
                Items[1].GetComponent<UITexture>().mainTexture = Resources.Load(cha[1].name) as Texture;
                Items[0].GetComponent<UITexture>().mainTexture = Resources.Load(cha[0].name) as Texture;
            }
            if (cha.Count == 3)
            {
                Items[3].GetComponent<Icon>().Ennd.enabled = false;
                Items[2].GetComponent<Icon>().Ennd.enabled = true;
                Items[1].GetComponent<Icon>().Ennd.enabled = true;
                Items[2].GetComponent<UITexture>().mainTexture = Resources.Load(cha[2].name) as Texture;
                Items[1].GetComponent<UITexture>().mainTexture = Resources.Load(cha[1].name) as Texture;
                Items[0].GetComponent<UITexture>().mainTexture = Resources.Load(cha[0].name) as Texture;

            }

            if (cha.Count == 2)
            {
                Items[3].GetComponent<Icon>().Ennd.enabled = false;
                Items[2].GetComponent<Icon>().Ennd.enabled = false;
                Items[1].GetComponent<Icon>().Ennd.enabled = true;
                Items[1].GetComponent<UITexture>().mainTexture = Resources.Load(cha[1].name) as Texture;
                Items[0].GetComponent<UITexture>().mainTexture = Resources.Load(cha[0].name) as Texture;
            }

            if (cha.Count == 1)
            {
                Items[3].GetComponent<Icon>().Ennd.enabled = false;
                Items[2].GetComponent<Icon>().Ennd.enabled = false;
                Items[1].GetComponent<Icon>().Ennd.enabled = false;
                Items[0].GetComponent<UITexture>().mainTexture = Resources.Load(cha[0].name) as Texture;
            }
        
    }
}