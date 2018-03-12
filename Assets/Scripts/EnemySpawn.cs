using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {


    public List<GameObject> Enemys;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void SpawnEnemy()
    {

        Instantiate(Enemys[0],transform.position,transform.rotation);

    }
}
