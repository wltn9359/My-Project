using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConT : MonoBehaviour {

    public List<GameObject> ConTp;

    void Start ()
    {
		
	}
	
	
	void Update ()
    {

     
    }



    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Item")
        {
            ConTp.Add(col.gameObject);
            ConTp[0].transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Debug.Log(ConTp[0].name);

            if (ConTp[0].GetComponent<Icon>().Slots.Count > 0)
            {
                ConTp[0].GetComponent<Icon>().Slots.RemoveAt(0);
            }
        }


    }



}
