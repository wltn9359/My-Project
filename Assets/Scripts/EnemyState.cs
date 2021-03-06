﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour {

    public GameObject TM;
    public Animator Flonne;
    public int Hp = 100;
    public int EnemyATK = 1;
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
    public List<GameObject> Enemy;
    public List<GameObject> Player;
    public GameObject Btnm;
    public int gol;
    public int Totalgol;


    public enum ENEMYSTATE
    {
        IDLE = 0,
        MOVE,
        ATTACK,
        DAMAGE,
        DEAD,
        FINISH,
        KILL
    }

    public ENEMYSTATE Enemystate;

    void Awake()
    {
        Btnm = GameObject.FindGameObjectWithTag("Btn");
        lookEM.RemoveAt(0);
        lookPL.RemoveAt(0);
    }

    void Start()
    {
        TM = GameObject.FindGameObjectWithTag("TIme");
        Btnm = GameObject.FindGameObjectWithTag("Btn");
        Player.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        target = GameObject.FindGameObjectWithTag("Respawn").transform;
        target2 = GameObject.FindGameObjectWithTag("Player").transform;
        //target3 = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    void Update()
    {

        switch (Enemystate)
        {
            case ENEMYSTATE.IDLE:

                if (lookEM.Count == 0)
                {
                    Enemystate = ENEMYSTATE.MOVE;
                }

                if (target2 == null)
                {
                    if (lookEM.Count != 0)
                    {
                        lookEM.RemoveAt(0);
                        target2 = GameObject.FindGameObjectWithTag("Player").transform;

                        if (target2 == null)
                        {
                            target2 = null;
                        }

                    }

                }
                

                if (lookPL.Count > 0)
                {
                    if (lookPL[0] != null)
                    {
                        Enemystate = ENEMYSTATE.ATTACK;
                    }
                }

                break;

            case ENEMYSTATE.MOVE:

                // if (target2 == null)
                // {
                //     if (lookPL.Count == 0)
                //     {
                //         target2 = GameObject.FindGameObjectWithTag("Player").transform;
                //     }
                //}
                Flonne.SetBool("Attack", false);
                if (target2 != null)
                {
                    float distance = (target2.position - transform.position).magnitude;
                    if (distance < attackRange)
                    {
                        Enemystate = ENEMYSTATE.ATTACK;
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

                if (lookEM.Count > 0)
                {
                    if (lookEM[0] != null)
                    {
                        Enemystate = ENEMYSTATE.IDLE;
                    }

                    //else
                    //{
                    //    lookEM.RemoveAt(0);
                    //}

                }

                Btnm.GetComponent<BtnManager>();

                break;

            case ENEMYSTATE.ATTACK:
                Flonne.SetBool("Attack", true);

                if (lookPL.Count == 0)
                {
                    Enemystate = ENEMYSTATE.MOVE;
                }

                stateTime += Time.deltaTime;
                if (stateTime > attackStateMaxTime)
                {
                    stateTime = 0f;
                    Enemystate = ENEMYSTATE.IDLE;
                    lookPL[0].GetComponent<PlayerState>().Playerstate = PlayerState.PLAYERSTATE.DAMAGE;
                }




                break;

            case ENEMYSTATE.DAMAGE:


                if (Hp <= 0)
                {
                    Enemystate = ENEMYSTATE.DEAD;
                    Hp = 0;

                }
                if (Hp > 0)
                {
                    Hp -= lookPL[0].GetComponent<PlayerState>().PlayerATK;

                    Enemystate = ENEMYSTATE.ATTACK;
                }
                break;
            case ENEMYSTATE.DEAD:
                Flonne.SetBool("Dead", true);

                lookPL[0].GetComponent<PlayerState>().Playerstate = PlayerState.PLAYERSTATE.KILL;

                if (Totalgol==0)
                {
                    Totalgol += gol;
                    TM.GetComponent<TimeManager>().GSU += Totalgol;
                    Btnm.GetComponent<BtnManager>().LV.width += 10;
                }
                Destroy(gameObject,1f);

               
               

                break;

            case ENEMYSTATE.KILL:
                //target3 = GameObject.FindGameObjectWithTag("Enemy").transform;
                Enemystate = ENEMYSTATE.MOVE;
                Debug.Log("kill");

                lookPL.Clear();



                lookEM.Clear();

                
                

           
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

            case ENEMYSTATE.FINISH:
    
                gameObject.transform.Translate(Speed * Time.deltaTime, 0, 0);
               
                break;

        }

        //if(Enemystate == ENEMYSTATE.DEAD )
        //{
        //    TM.GetComponent<TimeManager>().GSU += gol;
        //}

    }

    public void GOLD()
    {
       
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
           
            lookEM.Add(col.gameObject);
            gameObject.transform.Translate(-0.01f, 0, 0);
        }

        if (col.gameObject.tag == "Player")
        {
            //Debug.Log(col.name);
            lookPL.Add(col.gameObject);
            target2 = col.gameObject.transform;
        }

        if(col.gameObject.name == "EnemyGoal")
        {
            Enemystate = ENEMYSTATE.FINISH;
            gameObject.transform.Rotate(0, 180, 0);
        }
        if(col.gameObject.name == "PlayerGoal")
        {
            Btn = GameObject.FindGameObjectWithTag("Btn");           
            Btn.GetComponent<BtnManager>().QuestBtn[0].SetActive(true);
            Destroy(gameObject);
        }        
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            //Debug.Log(col.name);
            lookEM.Remove(col.gameObject);
            Enemystate = ENEMYSTATE.MOVE;
        }

        if (col.gameObject.tag == "Player")
        {
            //Debug.Log(col.name);
            lookPL.Remove(col.gameObject);
        }
    }
}