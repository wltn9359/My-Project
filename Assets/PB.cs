using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PB : MonoBehaviour {

    public List<GameObject> PlayerGet;
    public List<GameObject> Player;

	void Start ()
    {
		


	}
	

	void Update ()
    {
        
        //PlayerGet.AddRange(GameObject.FindGameObjectsWithTag("Player"));

	}



    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            Player.Add(col.gameObject);
            if(Player.Count>1)
            {
                Player.RemoveAt(1);
            }
        }
    }
}
