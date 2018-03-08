using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{

    public Animator Asagi;
    public float Hp = 100;
    public int PlayerATK = 3;
    public float stateTime = 0;
    public float attackRange = 1;
    public float idleStateMaxTime;
    public float attackStateMaxTime = 3;
    public float Speed;
    public Transform target;
    public Transform target2;
    //public Transform target3;
    public List<GameObject> lookEM;
    public List<GameObject> lookPL;

    public enum PLAYERSTATE
    {
        IDLE = 0,
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

        lookEM.RemoveAt(0);
        lookPL.RemoveAt(0);
    }

    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Re").transform;
        target2 = GameObject.FindGameObjectWithTag("Enemy").transform;
        //target3 = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    void Update()
    {

        switch (Playerstate)
        {
            case PLAYERSTATE.IDLE:

                if (lookPL.Count == 0)
                {
                    Playerstate = PLAYERSTATE.MOVE;
                }

                if (target2 == null)
                {
                    if (lookPL.Count != 0)
                    {
                        lookPL.RemoveAt(0);
                        target2 = GameObject.FindGameObjectWithTag("Enemy").transform;

                        if (target2 == null)
                        {
                            target2 = null;
                        }

                    }

                }

                if (lookEM.Count > 0)
                {
                    if (lookEM[0] != null)
                    {
                        Playerstate = PLAYERSTATE.ATTACK;
                    }
                }

                break;

            case PLAYERSTATE.MOVE:

                // if (target2 == null)
                // {
                //     if (lookPL.Count == 0)
                //     {
                //         target2 = GameObject.FindGameObjectWithTag("Player").transform;
                //     }
                //}
                Asagi.SetBool("Attack", false);
                if (target2 != null)
                {
                    float distance = (target2.position - transform.position).magnitude;
                    if (distance < attackRange)
                    {
                        Playerstate = PLAYERSTATE.ATTACK;
                    }
                }

                //if(target3 == null)
                //{
                //    target3 = GameObject.FindGameObjectWithTag("Enemy").transform;
                //}

                //if(target3 != null)
                //{
                //    float distance2 = (target3.position - transform.position).magnitude;
                //    if (distance2 < attackRange)
                //    {
                //        Enemystate = ENEMYSTATE.IDLE;
                //    }
                //}

                Vector3 dir = target.position - transform.position;
                dir.Normalize();
                gameObject.transform.Translate(dir * Speed * Time.deltaTime);

                //if (target2 == null)
                //{
                //    Vector3 dis = target.position - transform.position;
                //    dis.Normalize();
                //    gameObject.transform.Translate(dis * Speed * Time.deltaTime);
                //}

                if (lookPL.Count > 0)
                {
                    if (lookPL[0] != null)
                    {
                        Playerstate = PLAYERSTATE.IDLE;
                    }

                    //else
                    //{
                    //    lookEM.RemoveAt(0);
                    //}

                }


                break;

            case PLAYERSTATE.ATTACK:
                Asagi.SetBool("Attack", true);

                if (lookEM.Count == 0)
                {
                    Playerstate = PLAYERSTATE.MOVE;
                }
                
                Playerstate = PLAYERSTATE.IDLE;
                lookEM[0].GetComponent<EnemyState>().Enemystate = EnemyState.ENEMYSTATE.DAMAGE;
                break;

            case PLAYERSTATE.DAMAGE:


                Hp -= lookEM[0].GetComponent<EnemyState>().EnemyATK;
                if (Hp == 0)
                {
                    Playerstate = PLAYERSTATE.DEAD;
                }

                break;
            case PLAYERSTATE.DEAD:

                
                Destroy(gameObject);
                lookEM[0].GetComponent<EnemyState>().Enemystate = EnemyState.ENEMYSTATE.KILL;


                break;

            case PLAYERSTATE.KILL:
                //target3 = GameObject.FindGameObjectWithTag("Enemy").transform;
                Debug.Log("kill");

                if (lookPL.Count > 0)
                {
                    lookPL.RemoveAt(0);
                }

                if (lookEM.Count > 0)
                {
                    lookEM.RemoveAt(0);
                }
                Playerstate = PLAYERSTATE.MOVE;
                //if(target3 != null)
                //{
                //    Vector3 dis = target.position - transform.position;
                //    dis.Normalize();
                //    gameObject.transform.Translate(dis * Speed * Time.deltaTime);
                //    if(lookEM.Count>0)
                //    {
                //        Enemystate = ENEMYSTATE.IDLE;
                //    }
                //}




                break;

            case PLAYERSTATE.FINISH:


                gameObject.transform.Translate(Speed * Time.deltaTime, 0, 0);

                break;

        }

      
    }

  

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {

            lookPL.Add(col.gameObject);
        
        }

        if (col.gameObject.tag == "Enemy")
        {
            //Debug.Log(col.name);
            lookEM.Add(col.gameObject);
            target2 = col.gameObject.transform;

        }

        if (col.gameObject.tag == "Re")
        {
            Playerstate = PLAYERSTATE.FINISH;
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
            lookPL.Remove(col.gameObject);
        }
    }
}