using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class EnemyController : MonoBehaviour
{

   // public float lookRadius = 10f;
    //public AudioSource audio1;
    //public AudioSource audio2;
    public bool isAudioPlaying = false;
    public AudioSource audioSound;
    //public Animator anim;

    private const float timeToCharge = 10.5f;
    private float chargeTimer = 0.0f;

    public SphereCollider detectionRange;

    Transform target;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        detectionRange = GetComponent<SphereCollider>();
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
      //  anim = GetComponent<Animator>();
        audioSound = GetComponent<AudioSource>();
       // anim.SetBool("isIdle", true);
    }

    // Update is called once per frame
    /*
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
    */

   // void OnDrawGizmosSelected()
   // {
   //     Gizmos.color = Color.red;
   //     Gizmos.DrawWireSphere(transform.position, lookRadius);
   // }


    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //get the angle of where the player was detected.
            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);

            //check if the player is within the angle of sight
            if (angle < 60.0f * 0.5f)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position + Vector3.up, direction, out hit, detectionRange.radius))
                {
                    if (hit.collider.gameObject.CompareTag("Player"))
                    {
                        Debug.DrawRay(transform.position + Vector3.up, direction, Color.red);
                        Debug.Log("Playerfound");
                        //audioSound.PlayOneShot(audioSound.GetComponent<AudioClip>());
                      //  anim.SetBool("isIdle", false);
                        agent.SetDestination(target.position);
                        if(isAudioPlaying == false)
                        {
                            isAudioPlaying = true;
                            audioSound.Play();
                        }
                        
                    }
                }
            }
        }
    }
}
