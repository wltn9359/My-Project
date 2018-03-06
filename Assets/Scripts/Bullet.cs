using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

	
	void Update ()
    {
        transform.Translate(-3*Time.deltaTime, 0, 0);
        Destroy(gameObject,3);
	}
}
