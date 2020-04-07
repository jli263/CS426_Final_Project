using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class EnemyController : MonoBehaviour
{


    public bool isAudioPlaying = false;
    public AudioSource audioSound;

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
        audioSound = GetComponent<AudioSource>();
    }


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
