using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour {

    public List<GameObject> Tem;
    

	void Start ()
    {
        //Tem.AddRange(GameObject.FindGameObjectsWithTag("Item"));
	}
	

	void Update ()
    {
        
		
	}

    public void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Item")
        {
           gameObject.transform.position = new Vector3(col.gameObject.GetComponent<Back>().Tem[0].transform.position.x, col.gameObject.GetComponent<Back>().Tem[0].transform.position.y, col.gameObject.GetComponent<Back>().Tem[0].transform.position.z);
           //col.gameObject.transform.position = new Vector3(gameObject.GetComponent<Back>().Tem[0].transform.position.x, gameObject.GetComponent<Back>().Tem[0].transform.position.y, gameObject.GetComponent<Back>().Tem[0].transform.position.z);
        }

        if (col.gameObject.tag=="Slot")
        {
            Tem.Add(col.gameObject);
            if (Tem.Count > 1)
            {
                Tem.RemoveAt(0);
            }
            
        }

        if(col.gameObject.tag == "Conty")
        {
            Tem.Add(col.gameObject);
            if (Tem.Count > 1)
            {
                Tem.RemoveAt(0);
            }
            
        }
    }
}
