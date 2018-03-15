using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour {

    public List<GameObject> Tem;

	void Start ()
    {
		
	}
	

	void Update ()
    {
		
	}

    public void TriggerExit(Collider col)
    {
        if(col.gameObject.tag=="Item")
        {
            Tem.Add(col.gameObject);
            if(Tem[0].GetComponent<Icon>().Slots.Count>0)
            {
                Tem[0].GetComponent<Icon>().Slots[0].transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }

            if (Tem[0].GetComponent<Icon>().Conts.Count > 0)
            {
                Tem[0].GetComponent<Icon>().Conts[0].transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }
    }
}
