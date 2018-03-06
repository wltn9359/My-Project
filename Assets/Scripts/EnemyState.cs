using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour {

    public Animator Flonne;
    public int Hp = 10;
    public float stateTime = 0;
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
        
        lookEM.RemoveAt(0);
        lookPL.RemoveAt(0);
    }

    void Start()
    {
   
        target = GameObject.FindGameObjectWithTag("Respawn").transform;
        target2 = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void Update()
    {

        switch (Enemystate)
        {
          case ENEMYSTATE.IDLE:

                if (lookEM.Count > 0)
                {
                    if (lookEM[0] != null)
                    {
                        return;
                    }
                }

                if (lookEM.Count == 0)
                {
                    Enemystate = ENEMYSTATE.MOVE;
                }

                if(lookPL.Count>0)
                {
                    Enemystate = ENEMYSTATE.ATTACK;
                }
                
                break;

            case ENEMYSTATE.MOVE:


                Flonne.SetBool("Attack", false);
                if (target2 != null)
                {
                    float distance = (target2.position - transform.position).magnitude;
                    if (distance < attackRange)
                    {
                        Enemystate = ENEMYSTATE.ATTACK;
                    }
                }
                    Vector3 dir = target.position - transform.position;
                    dir.Normalize();
                    gameObject.transform.Translate(dir * Speed * Time.deltaTime);
                if (lookEM.Count > 0)
                {
                    if (lookEM[0] != null)
                    {
                        Enemystate = ENEMYSTATE.IDLE;
                    }

                    else
                    {
                        lookEM.RemoveAt(0);
                    }

                }


                break;

            case ENEMYSTATE.ATTACK:
                Flonne.SetBool("Attack", true);

                if(lookPL.Count == 0)
                {

                }

                if ()
                {

                }
               
                break;

            case ENEMYSTATE.DAMAGE:

                break;
            case ENEMYSTATE.DEAD:

                GetComponent<PlayerController>().lookObj.RemoveAt(0);
                GetComponent<PlayerController>().PlayerState = PlayerController.PLAYERSTATE.KILL;
                Destroy(gameObject, 3f);
              
                break;

            case ENEMYSTATE.KILL:

                Debug.Log("kill");
                GetComponent<PlayerController>().lookObj.Remove(lookPL[0]);
                lookPL.RemoveAt(0);

                return;
      

                break;

        }

    }



    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
           
            lookEM.Add(col.gameObject);
        }

        if (col.gameObject.tag == "Player")
        {
            //Debug.Log(col.name);
            lookPL.Add(col.gameObject);
            target2 = col.gameObject.transform;
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