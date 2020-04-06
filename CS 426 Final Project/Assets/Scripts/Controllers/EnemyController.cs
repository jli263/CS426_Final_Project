using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;
    static Animator anim;
    public AudioSource audio1;
    public AudioSource audio2;
    public bool audio = false;

    private const float timeToCharge = 10.5f;
    private float chargeTimer = 0.0f;

    Transform target;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        //audio2 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //yelling.Play();
        float distance = Vector3.Distance(target.position, transform.position);
        //anim.SetBool("isJogging", true);
        if (distance <= lookRadius)
        {
            //anim.SetBool("isIdle", false);
            //anim.SetBool("isJogging", true);
            
            if(audio == false)
            {
                audio2.Play();
                audio = true;
            }
            chargeTimer += Time.deltaTime;
            if (chargeTimer >= timeToCharge)
            {
                chargeTimer -= timeToCharge;
                audio1.Play();
            }
            agent.SetDestination(target.position);
        }
        else if (distance <= lookRadius)
        {
            audio2.Play();
            chargeTimer = 0.0f;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
