using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AUDIO : MonoBehaviour
{
    public GameObject FM;
    public AudioSource BGM;
	


	void Start ()
    {
		
	}
	
	
	void Update ()
    {

        if (FM.activeSelf == true)
        {
            BGM.mute = true;

        }

        else
        {
            BGM.mute = false;
        }


    }
}
