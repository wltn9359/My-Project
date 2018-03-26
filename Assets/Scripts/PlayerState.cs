using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public Animator Asagi;
    public int FullHp;
    public int Hp;
    public int PlayerATK;
    public float stateTime = 0;
    public float attackRange = 1;
    public float idleStateMaxTime;
    public float attackStateMaxTime = 1;
    public float Speed;
    public Transform target;
    public Transform target2;
    //public Transform target3;
    public List<GameObject> lookEM;
    public List<GameObject> lookPL;
    public GameObject Btn;
    public  Collider Endcol;
    public List<GameObject> Respawns;
    public List<GameObject> PlayerB;
    public List<GameObject> Enemyf;
    public List<GameObject> Playerse;
    

    public enum PLAYERSTATE
    {
        NONE = -1,
        IDLE = 0,
        FIND,
        MOVE,
        ATTACK,
        DAMAGE,
        DEAD,
        FINISH,
        KILL
    }

    public PLAYERSTATE Playerstate;

    void Awake()
    {
        //Respawns.Add(GameObject.FindGameObjectWithTag("PlayerRespawn"));
        Btn = GameObject.FindGameObjectWithTag("Btn");
        lookEM.RemoveAt(0);
        lookPL.RemoveAt(0);
        Endcol = GetComponent<Collider>();
    }

    public void Start()
    {
      
        target = GameObject.FindGameObjectWithTag("Re").transform;
      
        //target2 = GameObject.FindGameObjectWithTag("Enemy").transform;

        //target3 = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    void Update()
    {

        switch (Playerstate)
        {

            case PLAYERSTATE.NONE:

               
                break;

            case PLAYERSTATE.IDLE:

                target2 = null;
                if (lookPL.Count == 0)
                {
                    if (target2 == null)
                    {
                        Playerstate = PLAYERSTATE.MOVE;
                    }
                }

                //if (target2 == null)
                //{
                //    target2 = GameObject.FindGameObjectWithTag("Enemy").transform;
                //    if(gameObject.GetComponent<PlayerState>().target2 ==null)
                //    {
                //        Playerstate = PLAYERSTATE.MOVE;
                //    }
                //}




                if (lookEM.Count > 0)
                {
                    if (lookEM[0] != null)
                    {
                        Playerstate = PLAYERSTATE.ATTACK;
                    }
                }

                break;

            case PLAYERSTATE.FIND:

                if (target2 != null)
                {
                    target2 = GameObject.FindGameObjectWithTag("Enemy").transform;
                }  
                if (target2 == null)
                {
                    Playerstate = PLAYERSTATE.MOVE;
                    target2 = null;
                    
                }


                Playerstate = PLAYERSTATE.MOVE;

                break;

            case PLAYERSTATE.MOVE:

                if(gameObject.transform.position.x>10)
                {
                    Endcol.enabled = false;
                }

                else
                {
                    Endcol.enabled = true;
                }
                
                Asagi.SetBool("Attack", false);
                if (target2 != null)
                {
                    float distance = (target2.position - transform.position).magnitude;
                    if (distance < attackRange)
                    {
                        Playerstate = PLAYERSTATE.ATTACK;
                    }
                }

                Vector3 dir = target.position - transform.position;
                dir.Normalize();
                gameObject.transform.Translate(dir * Speed * Time.deltaTime);

                
                if (lookPL.Count > 0)
                {
                    if (lookPL[0] != null)
                    {
                        Playerstate = PLAYERSTATE.IDLE;
                    }
                }

                break;

            case PLAYERSTATE.ATTACK:
                Asagi.SetBool("Attack", true);

                if (lookEM.Count == 0)
                {
                    Playerstate = PLAYERSTATE.MOVE;
                }
                
                stateTime += Time.deltaTime;
                if (stateTime > attackStateMaxTime)
                {
                    stateTime = 0f;
                    Playerstate = PLAYERSTATE.IDLE;
                    lookEM[0].GetComponent<EnemyState>().Enemystate = EnemyState.ENEMYSTATE.DAMAGE;
                }

                break;

            case PLAYERSTATE.DAMAGE:

                if (Hp <= 0)
                {
                    Playerstate = PLAYERSTATE.DEAD;
                    Hp = 0;
                
                }
                if (Hp > 0)
                {
                    Hp -= lookEM[0].GetComponent<EnemyState>().EnemyATK;

                    Playerstate = PLAYERSTATE.ATTACK;
                }

                break;

            case PLAYERSTATE.DEAD:
                //lookPL[0].GetComponent<PlayerState>().lookPL.Clear();
                target2 = null;
                //gameObject.SetActive(false);
                //Destroy(gameObject);
                lookEM[0].GetComponent<EnemyState>().Enemystate = EnemyState.ENEMYSTATE.KILL;
                Hp = FullHp;
                gameObject.transform.position = new Vector3(gameObject.GetComponent<PlayerState>().Respawns[0].transform.position.x, gameObject.GetComponent<PlayerState>().Respawns[0].transform.position.y, gameObject.GetComponent<PlayerState>().Respawns[0].transform.position.z);
                Playerstate = PLAYERSTATE.NONE;
                Endcol.enabled = false;
                lookEM.Clear();
                lookPL.Clear();

                Btn.GetComponent<BtnManager>().Players.RemoveAt(0);

                break;

            case PLAYERSTATE.KILL:
               
                Debug.Log("kill");
                target2 = null;

                if (lookPL.Count > 0)
                {
                    lookPL.RemoveAt(0);
                }

                if (lookEM.Count > 0)
                {
                    lookEM.RemoveAt(0);
                }
                Playerstate = PLAYERSTATE.MOVE;
                lookEM.Clear();

                //Btnm.GetComponent<BtnManager>().Enemys.Clear();
                Btn.GetComponent<BtnManager>().FInds();
                break;

            case PLAYERSTATE.FINISH:
                target2 = null;
                Endcol.enabled =false;
                gameObject.transform.Translate(-Speed * Time.deltaTime, 0, 0);
                stateTime += Time.deltaTime;
                if (gameObject.transform.position.x>15)
                {
                    Endcol.enabled = false;
                    Playerstate = PLAYERSTATE.NONE;
                    Btn.GetComponent<BtnManager>().QuestBtn[0].SetActive(true);
                    Debug.Log("HIT");
                    gameObject.transform.Rotate(0, 180, 0);
                    gameObject.transform.position = new Vector3(gameObject.GetComponent<PlayerState>().Respawns[0].transform.position.x, gameObject.GetComponent<PlayerState>().Respawns[0].transform.position.y, gameObject.GetComponent<PlayerState>().Respawns[0].transform.position.z);

                }
                lookEM.Clear();
                lookPL.Clear();
                break;

        }

 
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            lookPL.Add(col.gameObject);
            gameObject.transform.Translate(0.1f, 0, 0);
            if (Playerstate != PLAYERSTATE.FINISH)
            {
                Playerstate = PLAYERSTATE.IDLE;   
            }
        }

        if (col.gameObject.tag == "Enemy")
        {
            lookEM.Add(col.gameObject);
            target2 = col.gameObject.transform;
        }

        if (col.gameObject.tag == "Re")
        {
            Playerstate = PLAYERSTATE.FINISH;
            gameObject.transform.Rotate(0, 180, 0);
        }

        //if (col.gameObject.tag == "Respawn")
        //{
        //    Endcol.enabled = false;
        //    Playerstate = PLAYERSTATE.NONE;
        //    Btn.GetComponent<BtnManager>().QuestBtn[0].SetActive(true);
        //    Debug.Log("HIT");
        //    gameObject.transform.Rotate(0, 180, 0);
        //    gameObject.transform.position = new Vector3(gameObject.GetComponent<PlayerState>().Respawns[0].transform.position.x, gameObject.GetComponent<PlayerState>().Respawns[0].transform.position.y, gameObject.GetComponent<PlayerState>().Respawns[0].transform.position.z);
           
        //}

        if (col.gameObject.tag == "PlayerRespawn")
        {
            if (Respawns.Count < 1)
            {
                Respawns.Add(col.gameObject);
                if (PlayerB.Count > 0)
                {
                    PlayerB[0].gameObject.GetComponent<PB>().Player.RemoveAt(0);
                }
            }
            if (PlayerB.Count > 0)
            {
                PlayerB.RemoveAt(0);
            }
        }


    }


    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            //Debug.Log(col.name);
            lookEM.Remove(col.gameObject);
        }

        if (col.gameObject.tag == "Player")
        {

            //Debug.Log(col.name);
            if (lookPL.Count > 0)
            {
                lookPL.RemoveAt(0);
            }
            Playerstate = PLAYERSTATE.IDLE;
            //Playerstate = PLAYERSTATE.FIND;
        }

        //if (col.gameObject.tag == "PlayerRespawn")
        //{
        //    if (Respawns.Count < 1)
        //    {
        //        Debug.Log("dd");
        //        Respawns.Add(col.gameObject);
        //    }
        //}
    }

    public void FindEne()
    {
        Enemyf.Clear();
        Enemyf.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        if(Enemyf.Count<1)
        {
            Playerstate = PLAYERSTATE.FINISH;
        }
    }
}