using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator Asagi;
    public float stateTime;
    public float attackRange = 2.5f;
    public float idleStateMaxTime;
    public float attackStateMaxTime;
    public float Speed;
    public GameObject players;
    Transform target;
    Transform target2;
    public GameObject Bullet;
    public float coolTime;
    public List<GameObject> lookObj;
    public enum PLAYERSTATE
    {
        IDLE = 0,
        MOVE,
        ATTACK,
        DAMAGE,
        DEAD,
        KILL
    }

    public PLAYERSTATE PlayerState;
    
    void Awake()
    {
        PlayerState = PLAYERSTATE.IDLE;
    }

    void Start()
    {


        GetComponent<EnemyState>().Enemystate = EnemyState.ENEMYSTATE.KILL;
        
        target = GameObject.FindWithTag("Enemy").transform;
        target2 = GameObject.FindWithTag("Player").transform;


    }

    void Update()
    {

        switch (PlayerState)
            {
                case PLAYERSTATE.IDLE:
                    stateTime += Time.deltaTime;
                    if (stateTime > idleStateMaxTime)
                    {
                        stateTime = 0f;
                        PlayerState = PLAYERSTATE.MOVE;
                    }
                    break;
                case PLAYERSTATE.MOVE:

                    float distance = (target.position - transform.position).magnitude;
                    if (distance < attackRange)
                    {
                        PlayerState = PLAYERSTATE.ATTACK;
                        stateTime = attackStateMaxTime;
                    }

                    else
                    {
                        Vector3 dir = target.position - transform.position;
                        dir.Normalize();
                        gameObject.transform.Translate(dir * Speed * Time.deltaTime);
                    }

                    break;
                case PLAYERSTATE.ATTACK:
                    stateTime += Time.deltaTime;
                    Asagi.SetBool("Attack", true);


                    if (stateTime > coolTime)
                    {
                        stateTime = 0f;
                        Instantiate(Bullet, transform.position, transform.rotation);
                    }



                    break;
                case PLAYERSTATE.DAMAGE:

                    break;

                case PLAYERSTATE.DEAD:
                GetComponent<EnemyState>().Enemystate = EnemyState.ENEMYSTATE.KILL;


                GetComponent<EnemyState>().target2 = null;
                Destroy(gameObject);
              
                break;

            case PLAYERSTATE.KILL:

                GetComponent<EnemyState>().lookEM.Remove(lookObj[0]);

                break;

            }

        }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {

            lookObj.Add(col.gameObject);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            //Debug.Log(col.name);
            lookObj.Remove(col.gameObject);
        }
    }



}

    

