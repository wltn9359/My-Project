using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotchaManager : MonoBehaviour
{
    public int Per;
    public GameObject[] PrePlayers;
    public GameObject[] Pb;
    public List<GameObject> Playess;
    public GameObject BU;

	
	void Start ()
    {

        //Playess.AddRange(GameObject.FindGameObjectsWithTag("Player"));

	}
	
	
	void Update ()
    {
		


	}

    public void Gotcha()
    {

        if (BU.GetComponent<TimeManager>().GSU > 149)
        {

            BU.GetComponent<TimeManager>().GSU -= 150;

            Per = Random.Range(0, 4);

            if (Pb[0].GetComponent<PB>().Player.Count == 0)
            {
                if (Per == 0)
                {
                    GameObject Instance = Instantiate(PrePlayers[0], transform.position = new Vector3(Pb[0].transform.position.x, Pb[0].transform.position.y, Pb[0].transform.position.z), transform.rotation) as GameObject;
                    Instance.name = "Lime";
                }

                if (Per == 1)
                {
                    GameObject Instance = Instantiate(PrePlayers[1], transform.position = new Vector3(Pb[0].transform.position.x, Pb[0].transform.position.y, Pb[0].transform.position.z), transform.rotation) as GameObject;
                    Instance.name = "Kum";

                }

                if (Per == 2)
                {
                    GameObject Instance = Instantiate(PrePlayers[2], transform.position = new Vector3(Pb[0].transform.position.x, Pb[0].transform.position.y, Pb[0].transform.position.z), transform.rotation) as GameObject;
                    Instance.name = "Buster";

                }

                if (Per == 3)
                {
                    GameObject Instance = Instantiate(PrePlayers[3], transform.position = new Vector3(Pb[0].transform.position.x, Pb[0].transform.position.y, Pb[0].transform.position.z), transform.rotation) as GameObject;
                    Instance.name = "Lime";

                }
            }
            if (Pb[0].GetComponent<PB>().Player.Count > 0)
            {
                if (Pb[1].GetComponent<PB>().Player.Count == 0)
                {
                    if (Per == 0)
                    {
                        GameObject Instance = Instantiate(PrePlayers[0], transform.position = new Vector3(Pb[1].transform.position.x, Pb[1].transform.position.y, Pb[1].transform.position.z), transform.rotation) as GameObject;
                        Instance.name = "Lime";

                    }

                    if (Per == 1)
                    {
                        GameObject Instance = Instantiate(PrePlayers[1], transform.position = new Vector3(Pb[1].transform.position.x, Pb[1].transform.position.y, Pb[1].transform.position.z), transform.rotation) as GameObject;
                        Instance.name = "Kum";

                    }

                    if (Per == 2)
                    {
                        GameObject Instance = Instantiate(PrePlayers[2], transform.position = new Vector3(Pb[1].transform.position.x, Pb[1].transform.position.y, Pb[1].transform.position.z), transform.rotation) as GameObject;
                        Instance.name = "Buster";

                    }

                    if (Per == 3)
                    {
                        GameObject Instance = Instantiate(PrePlayers[3], transform.position = new Vector3(Pb[1].transform.position.x, Pb[1].transform.position.y, Pb[1].transform.position.z), transform.rotation) as GameObject;
                        Instance.name = "Lime";

                    }
                }
            }

            if (Pb[1].GetComponent<PB>().Player.Count > 0)
            {
                if (Pb[2].GetComponent<PB>().Player.Count == 0)
                {
                    if (Per == 0)
                    {
                        GameObject Instance = Instantiate(PrePlayers[0], transform.position = new Vector3(Pb[2].transform.position.x, Pb[2].transform.position.y, Pb[2].transform.position.z), transform.rotation) as GameObject;
                        Instance.name = "Lime";

                    }

                    if (Per == 1)
                    {
                        GameObject Instance = Instantiate(PrePlayers[1], transform.position = new Vector3(Pb[2].transform.position.x, Pb[2].transform.position.y, Pb[2].transform.position.z), transform.rotation) as GameObject;
                        Instance.name = "Kum";
                    }

                    if (Per == 2)
                    {
                        GameObject Instance = Instantiate(PrePlayers[2], transform.position = new Vector3(Pb[2].transform.position.x, Pb[2].transform.position.y, Pb[2].transform.position.z), transform.rotation) as GameObject;
                        Instance.name = "Buster";

                    }

                    if (Per == 3)
                    {
                        GameObject Instance = Instantiate(PrePlayers[3], transform.position = new Vector3(Pb[2].transform.position.x, Pb[2].transform.position.y, Pb[2].transform.position.z), transform.rotation) as GameObject;
                        Instance.name = "Lime";

                    }
                }
            }



            if (Pb[2].GetComponent<PB>().Player.Count > 0)
            {
                if (Pb[3].GetComponent<PB>().Player.Count == 0)
                {
                    if (Per == 0)
                    {
                        GameObject Instance = Instantiate(PrePlayers[0], transform.position = new Vector3(Pb[3].transform.position.x, Pb[3].transform.position.y, Pb[3].transform.position.z), transform.rotation) as GameObject;
                        Instance.name = "Lime";

                    }

                    if (Per == 1)
                    {
                        GameObject Instance = Instantiate(PrePlayers[1], transform.position = new Vector3(Pb[3].transform.position.x, Pb[3].transform.position.y, Pb[3].transform.position.z), transform.rotation) as GameObject;
                        Instance.name = "Kum";
                    }

                    if (Per == 2)
                    {
                        GameObject Instance = Instantiate(PrePlayers[2], transform.position = new Vector3(Pb[3].transform.position.x, Pb[3].transform.position.y, Pb[3].transform.position.z), transform.rotation) as GameObject;
                        Instance.name = "Buster";

                    }

                    if (Per == 3)
                    {
                        GameObject Instance = Instantiate(PrePlayers[3], transform.position = new Vector3(Pb[3].transform.position.x, Pb[3].transform.position.y, Pb[3].transform.position.z), transform.rotation) as GameObject;
                        Instance.name = "Lime";

                    }
                }
            }






        }

    }
   
}
