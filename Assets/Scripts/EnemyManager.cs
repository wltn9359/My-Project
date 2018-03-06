using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {


    public List<GameObject>Enemy;

    private static EnemyManager _instance = null;
    public static EnemyManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(EnemyManager)) as EnemyManager;
                if (_instance == null)
                {
                    Debug.Log("ERROR");
                }
            }
            return _instance;
        }
    }

    void Start ()
    {
		
	}
	

	void Update ()
    {
		
	}

    public void Tri()
    {

    }
}
