using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour {


    public Transform[] Slot;
    public GameObject[] Items;
    public List<GameObject> Slots;
    public List<GameObject> Conts;
    public enum ICONST
    {
        NONE = 0,
        SLOTREMOVE,
        CONTYREMOVE
    }

    public ICONST iconst;

    void Awake()
    {
        Items = GameObject.FindGameObjectsWithTag("Item");

        Vector3 ConPos = new Vector3(transform.position.x, transform.position.y,0);
       
    }

    void Start ()
    {
		


	}
	

	void Update ()
    {

        switch (iconst)
        {
            case ICONST.NONE:

                break;
            case ICONST.SLOTREMOVE:

               
                if (Slots[0].GetComponent<Slot>().PI.Count > 0)
                {
                    Slots[0].GetComponent<Slot>().PI.RemoveAt(0);
                }
                iconst = ICONST.NONE;

                break;
            case ICONST.CONTYREMOVE:

                if (Conts[0].GetComponent<ConT>().ConTp.Count > 0)
                {
                    Conts[0].GetComponent<ConT>().ConTp.RemoveAt(0);
                }
                iconst = ICONST.NONE;

                break;
              
        }

        Items = GameObject.FindGameObjectsWithTag("Item");

    }

    public void OnTriggerEnter(Collider col)
    {
      
        if (col.gameObject.tag=="Slot")
        {
            Slots.Add(col.gameObject);
            //iconst = ICONST.CONTYREMOVE;
            Debug.Log(Slots[0].name);
            if (Conts.Count > 0)
            {
                if (Conts[0].GetComponent<ConT>().ConTp.Count > 0)
                {
                    Conts[0].GetComponent<ConT>().ConTp.RemoveAt(0);
                }
            }
        }

        if (col.gameObject.tag == "Conty")
        {

            Conts.Add(col.gameObject);
            //iconst = ICONST.SLOTREMOVE;
            Debug.Log(Conts[0].name);
            if (Slots.Count > 0)
            {
                if (Slots[0].GetComponent<Slot>().PI.Count > 0)
                {
                    Slots[0].GetComponent<Slot>().PI.RemoveAt(0);
                }
            }
        }

    }

 

}
