using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour
{

    public Transform[] Slot;
    public GameObject[] Items;
    public List<GameObject> Slots;
    public List<GameObject> Conts;
    public List<GameObject> Players;
    //public List<GameObject> Item;


    void Awake()
    {
        Items = GameObject.FindGameObjectsWithTag("Item");

        //Vector3 ConPos = new Vector3(transform.position.x, transform.position.y, 0);
    }

    void Start()
    {



    }


    void Update()
    {

        Items = GameObject.FindGameObjectsWithTag("Item");
        
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
            Players.Add(col.gameObject);




            //if (Conts.Count > 0)
            //{
            //    if (Conts.Count == 2)
            //    {

            //        col.gameObject.transform.position = new Vector3(Conts[1].transform.position.x, Conts[1].transform.position.y, Conts[1].transform.position.z);

            //    }
            //    if (Conts.Count == 1)
            //    {
            //        if (Slots == null)
            //        {
            //            col.gameObject.transform.position = new Vector3(Conts[0].transform.position.x, Conts[0].transform.position.y, Conts[0].transform.position.z);
            //        }
            //        if (Slots.Count == 1)
            //        {
            //            Players[0].transform.position = new Vector3(Slots[0].transform.position.x, Slots[0].transform.position.y, Slots[0].transform.position.z);
            //        }
            //        if (Slots.Count == 2)
            //        {
            //            Players[0].transform.position = new Vector3(Slots[1].transform.position.x, Slots[1].transform.position.y, Slots[1].transform.position.z);
            //        }
                   
                    
            //    }

            //}
           
            //if (Slots.Count > 0)
            //{
            //    if (Slots.Count == 2)
            //    {
            //        Players[0].transform.position = new Vector3(Slots[1].transform.position.x, Slots[1].transform.position.y, Slots[1].transform.position.z);
            //    }

            //    if (Slots.Count == 1)
            //    {
            //        if (Conts.Count == 2)
            //        {
            //            Players[0].transform.position = new Vector3(Conts[1].transform.position.x, Conts[1].transform.position.y, Conts[1].transform.position.z);
            //        }
            //        if (Conts.Count == 1)
            //        {
            //            Players[0].transform.position = new Vector3(Conts[0].transform.position.x, Conts[0].transform.position.y, Conts[0].transform.position.z);
            //        }
            //        if (Conts.Count == 0)
            //        {
            //            Players[0].transform.position = new Vector3(Slots[0].transform.position.x, Slots[0].transform.position.y, Slots[0].transform.position.z);
            //        }

            //    }
            //}
            Players.RemoveAt(0);
        }




        if (col.gameObject.tag == "Slot")
        {
            Slots.Add(col.gameObject);
    
            

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
            
            Conts.Add(col.gameObject);

           

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