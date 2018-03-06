using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilState : MonoBehaviour
{
    public Animator Flonne;
    public int Hp = 10;
    public float stateTime=0;
    public float attackRange = 1;
    public float idleStateMaxTime;
    public float attackStateMaxTime = 3;
    public float Speed;
    public Transform target;
    public Transform target2;
    public List<GameObject> lookEM;
    public List<GameObject> lookPL;
    public enum ENEMYSTATE
    {
        NONE=-1,
        IDLE=0,
        MOVE,
        ATTACK,
        DAMAGE,
        DEAD
    }

    public ENEMYSTATE EnemyState;

    void Awake()
    {
        if (lookEM.Count == 0)
        {
          lookEM[0] = null;
        }
         if (lookEM.Count == 0)
        {
          lookPL[0] = null;
        }
    }

    void Start()
    {
       
        target = GameObject.FindGameObjectWithTag("Respawn").transform;
        target2 = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void Update()
    {

        switch (EnemyState)
        {

            case ENEMYSTATE.NONE:



                break;

            case ENEMYSTATE.IDLE:
       
                if (lookEM.Count > 0)
                {
                    if (lookEM[0] == null)
                    {
                        if (lookEM[1] == null)
                        {
                            EnemyState = ENEMYSTATE.MOVE;
                        }
                        if (lookPL[0] == null)
                        {
                            EnemyState = ENEMYSTATE.MOVE;
                        }
                        if (lookEM[1] != null)
                        {
                            lookEM.RemoveAt(0);
                            lookEM.RemoveAt(1);
                            EnemyState = ENEMYSTATE.MOVE;
                        }
                    }
                }

                break;

            case ENEMYSTATE.MOVE:

                Flonne.SetBool("Attack", false);
                float distance = (target2.position - transform.position).magnitude;
                if(distance<attackRange)
                {
                    EnemyState = ENEMYSTATE.ATTACK;
                }

                if (lookPL[0] == null)
                {
                    Vector3 dir = target.position - transform.position;
                    dir.Normalize();
                    gameObject.transform.Translate(dir * Speed * Time.deltaTime);
                    if(lookPL[0]!=null)
                    {
                        EnemyState = ENEMYSTATE.ATTACK;
                    }
                }

                else
                {
                    EnemyState = ENEMYSTATE.ATTACK;
                }

                if (lookEM.Count > 0)
                {
                    if (lookEM[0] != null)
                    {   
                      EnemyState = ENEMYSTATE.IDLE;
                    }

                    else
                    {
                        lookEM.RemoveAt(0);
                    }
                }

                if(lookPL.Count > 0)
                {
                    if(lookPL[0] != null)
                    {
                        EnemyState = ENEMYSTATE.ATTACK;
                    }

                    else
                    {
                        lookPL.RemoveAt(0);
                    }
                }

                break;

            case ENEMYSTATE.ATTACK:
                Flonne.SetBool("Attack", true);
                stateTime += Time.deltaTime;
                if (lookPL[0] == null)
                {
                    EnemyState = ENEMYSTATE.MOVE;
                }
                //if (attackStateMaxTime < stateTime)
                //{
                //    stateTime = 0;
                //    //EnemyState = ENEMYSTATE.MOVE;
                //    Debug.Log("dddd");
                //}


                break;

            case ENEMYSTATE.DAMAGE:

                break;
            case ENEMYSTATE.DEAD:

              lookEM.RemoveAt(0);   

                break;

        }

    }



    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            //Debug.Log(col.name);
            lookEM.Add(col.gameObject);
        }

        if (col.gameObject.tag == "Player")
        {
            //Debug.Log(col.name);
            lookPL.Add(col.gameObject);
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