using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Orginal code by https://www.youtube.com/watch?v=5q4JHuJAAcQ&t=332s

public class SoldierPatrol : MonoBehaviour
{
    [SerializeField]
    bool patrolWaiting;

    [SerializeField]
    float waitingTime;
    
    [SerializeField]
    Checkpoint[] checkPoints;

    [SerializeField]
    float switchProb;

    Animator animator;
    NavMeshAgent navMeshAgent;
    int currPatrolIndex = 0;
    bool isMoving;
    bool isWaiting;
    bool isDetected = false;
    bool originalPath = true;
    float timeElapsed;

    public GameObject UiObject;

    public GameOver gameOverScene;

    //


    public bool isAudioPlaying = false;
    public AudioSource audioSound;

    private const float timeToCharge = 10.5f;
    private float chargeTimer = 0.0f;

    public SphereCollider detectionRange;

    Transform target;
    //NavMeshAgent agent;


    //

    // Start is called before the first frame update
    void Start()
    {
        //
        detectionRange = GetComponent<SphereCollider>();
        target = PlayerManager.instance.player.transform;
        //agent = GetComponent<NavMeshAgent>();
        audioSound = GetComponent<AudioSource>();
        //
        UiObject.SetActive(false);

        navMeshAgent = this.GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();
        
        if (navMeshAgent != null)
        {
            if(checkPoints.Length >= 2)
            {
                currPatrolIndex = 0;
                SetDestination();
            }
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (isDetected)
        {
            UiObject.SetActive(true);
        }
        else
        {
            UiObject.SetActive(false);
        }
        if (isMoving)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (isMoving && navMeshAgent.remainingDistance <= 1.0f)
        {
            isMoving = false;

            if (patrolWaiting)
            {
                timeElapsed = 0;
                isWaiting = true;
            }
            else
            {
                ChangeCheckPoint();
                SetDestination();
            }
        }

        //makes the AI wait before turning 
        if (isWaiting)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= waitingTime)
            {
                ChangeCheckPoint();
                SetDestination();
                isWaiting = false;
            }
        }
    }

    private void SetDestination()
    {
        //Set the destination of the AI
        Vector3 checkpointVector = checkPoints[currPatrolIndex].transform.position;
        navMeshAgent.SetDestination(checkpointVector);
        isMoving = true;
    }

    private void ChangeCheckPoint ()
    {
        //Determine if change of course
        if (UnityEngine.Random.Range(0f,1f) <= switchProb)
        {
            originalPath = !originalPath;
        }
        if (originalPath)
        {
            currPatrolIndex++;

            //Check if out of bounds
            if (currPatrolIndex >= checkPoints.Length)
            {
                //Go back to the previous check point
                currPatrolIndex = checkPoints.Length - 2;
                originalPath = !originalPath;
            }
        }
        else
        {
            //Check if out of bounds
            if (--currPatrolIndex < 0)
            {
                //Go back to the previous check point
                currPatrolIndex = 1;
                originalPath = !originalPath;
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Player")
        {
            Debug.Log("HIT!!!!");
            gameOverScene.gameOver();
        }
    }



    void OnTriggerStay(Collider other)
    {
        isDetected = false;
        //UiObject.SetActive(false);
        if (other.gameObject.CompareTag("Player"))
        {
            isDetected = true;
            //get the angle of where the player was detected.
            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);
            //check if the player is within the angle of sight
            if (angle < 90.0f * 0.5f)
            {
                //UiObject.SetActive(true);
                isDetected = true;
                RaycastHit hit;
                if (Physics.Raycast(transform.position + Vector3.up, direction, out hit, detectionRange.radius))
                {
                    isDetected = true;
                    if (hit.collider.gameObject.CompareTag("Player"))
                    {
                        isDetected = true;
                        Debug.DrawRay(transform.position + Vector3.up, direction, Color.red);
                        //Debug.Log("Playerfound");
                        
                        navMeshAgent.SetDestination(target.position);

                        if (isAudioPlaying == false)
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
