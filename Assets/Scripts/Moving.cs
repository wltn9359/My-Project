using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour {

    public float Speed;

	void Start ()
    {

       

	}
	void Update ()
    {
        gameObject.transform.Translate(Speed*Time.deltaTime,0,0);
        Destroy(gameObject, 3);

	}
}
