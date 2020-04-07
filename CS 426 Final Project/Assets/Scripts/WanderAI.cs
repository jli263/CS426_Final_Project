using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderAI : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float rotSpeed = 80f;

    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isIdle", true);
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.DrawRay(transform.position + Vector3.up, transform.TransformDirection(Vector3.forward), Color.red);

        if (isWandering == false)
        {
            StartCoroutine(Wander());
        }

        if (isRotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
        }

        if (isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
        }
        if (isWalking == true)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }

    }

    IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 3);
        int rotateLorR = Random.Range(0, 3);
        int walkWait = Random.Range(1, 3);
        int walkTime = Random.Range(1, 4);

        isWandering = true;
        anim.SetBool("isIdle", true);
        yield return new WaitForSeconds(walkWait);
        RaycastHit hit;
        if (!Physics.Raycast(transform.position + Vector3.up, transform.TransformDirection(Vector3.forward), out hit, 2))
        {
            anim.SetBool("isIdle", false);
            isWalking = true;
            yield return new WaitForSeconds(walkTime);
        }
        anim.SetBool("isIdle", true);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait / 2);

        if (rotateLorR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;

        }
        else
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }
        isWandering = false;
    }
}
