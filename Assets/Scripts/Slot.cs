using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {

    public GameObject[] Slots;
    public List<GameObject>PI;

	void Start ()
    {

        Slots = GameObject.FindGameObjectsWithTag("Slot");

	}
	
	
	void Update ()
    {
		
	}

    public void OnTriggerEnter(Collider col)
    {

        
        if(col.gameObject.tag == "Item")
        {
            PI.Add(col.gameObject);
            if (PI.Count > 1)
            {
                PI.RemoveAt(0);
            }
            PI[0].transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);




            //if(PI[0].GetComponent<Icon>().Conts.Count>0)
            //{
            //    PI[0].GetComponent<Icon>().Conts.RemoveAt(0);
            //}

        }    

      

    }

  

}
