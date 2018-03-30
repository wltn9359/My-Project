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
        ////gameObject.transform.Translate(-Speed * Time.deltaTime, 0, 0);
        //if (gameObject.transform.position.x <= -10)
        //{
        //    Debug.Log("M");
            
        //}



        //if (gameObject.transform.position.x >= 9.9f)
        //{
        //    Debug.Log("P");
        //    gameObject.transform.Rotate(0, 0, 0);
        //}

    }

    public void ST()
    {

        Application.LoadLevel(1);

    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Re")
        {
            gameObject.transform.Rotate(0, 180, 0);
        }

        if (col.gameObject.tag == "AU")
        {
            gameObject.transform.Rotate(0, 180, 0);
        }
    }
}

