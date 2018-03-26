using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConT : MonoBehaviour {

    public List<GameObject> ConTp;
    public GameObject[] PB;
    public GameObject[] Cont;
    void Start ()
    {

        //PB = GameObject.FindGameObjectsWithTag("PlayerBack");

    }
	
	
	void Update ()
    {

     
    }



    public void OnTriggerEnter(Collider col)
    {
        

        if (col.gameObject.tag == "Item")
        {
           
                ConTp.Add(col.gameObject);
            //if(Cont[0].GetComponent<ConT>().ConTp.Count>0)
            //{
            //    PB[3].GetComponent<PB>().Player.Add(col.gameObject);
            //}
            //if (Cont[0].GetComponent<ConT>().ConTp.Count < 1)
            //{
            //    PB[3].GetComponent<PB>().Player.Clear();
            //}

            

            if (ConTp.Count == 2)
            {
                ConTp.RemoveAt(0);
            }
            ConTp[0].transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        }




    }



}
