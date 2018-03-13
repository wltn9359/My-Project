using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public List<GameObject> PlayerList;
    public GameObject BtM;
    public GameObject[] Players;


	void Start ()
    {
       
	}
	
	
	void Update ()
    {
        Players = GameObject.FindGameObjectsWithTag("Player");
    }


}
