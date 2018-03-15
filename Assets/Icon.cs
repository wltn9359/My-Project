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

        Vector3 ConPos = new Vector3(transform.position.x, transform.position.y, 0);
    }

    void Start()
    {



    }


    void Update()
    {

        Items = GameObject.FindGameObjectsWithTag("Item");
        //if (gameObject.transform.position == Items[].)
        //{

        //}
    }

    public void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.tag);

        if(col.gameObject.tag == "Back")
        {
           
            if(Conts.Count>0)
            {
                Conts[0].GetComponent<ConT>().ConTp[0].transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }

            if(Slots.Count>0)
            {
                Slots[0].GetComponent<Slot>().PI[0].transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }

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

            if (Slots.Count > 1)
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

            if (Conts.Count > 1)
            {
              
                if (Conts[0].GetComponent<ConT>().ConTp.Count > 0)
                {
                    Conts[0].GetComponent<ConT>().ConTp.RemoveAt(0);
                }
                if (Conts.Count > 1)
                {
                    Conts.RemoveAt(0);
                }
            }

        }

        if (col.gameObject.tag == "Item")
        {
           

        }
    }
}
