using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public UILabel Niku;
    public UILabel Gold;
    public float _Times;
    public int NSU;
    public int GSU;
    public UILabel Timee;
    public int TITI_;
    public int BU;


	void Start ()
    {


		
	}
	
	
	void Update ()
    {

        _Times += Time.deltaTime;



        Timee.text = ("0"+TITI_+":"+BU+(int)_Times).ToString();
        Niku.text = (NSU).ToString();
        Gold.text = (GSU).ToString();

        if(_Times>9)
        {
            _Times = 0;
            BU += 1;
        }
        if(BU > 5)
        {
            TITI_ += 1;
            BU = 0;
        }

        if(TITI_ > 4)
        {
            TITI_ = 0;
            _Times = 0;
            NSU += 10;
        }

	}

}
