using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : GenericBehaviour
{

    public float days = 100f;
    public float daysOverTime = 0.25f;

    public static float hunger = 100f;
    public float hungerOverTime = 0.5f;

    public float stamina = 100f;
    public float staminaOverTime = 25f;

    public Slider hungerBar;
    public Slider staminaBar;
    public Slider dayBar;
    // Start is called before the first frame update

    Rigidbody myBody;
    void Start()
    {
        behaviourManager.SubscribeBehaviour(this);
        myBody = GetComponent<Rigidbody>();
        hungerBar.maxValue = hunger;
        staminaBar.maxValue = stamina;
        dayBar.maxValue = days;

        updateUi();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.C))
        {
            behaviourManager.GetAnim.SetBool("IsCrouching", true);
            transform.Translate(behaviourManager.GetH * Time.deltaTime * 2.0f, 0f, behaviourManager.GetV * Time.deltaTime * 2.0f);
            canSprint = false;
        }
        else
        {
            behaviourManager.GetAnim.SetBool("IsCrouching", false);
        }

        if (!Input.GetKey(KeyCode.W))
        {
            behaviourManager.GetAnim.SetBool("IsCrouching", false);
        }

        CalculateValues();
    }

    private void CalculateValues()
    {
        hunger -= hungerOverTime * Time.deltaTime;
        days -= daysOverTime * Time.deltaTime;

        if (hunger <= 10)
        {
            stamina -= (staminaOverTime) * Time.deltaTime;
        }

        if (canSprint && Input.GetKey(KeyCode.LeftShift))
        {
            stamina -= staminaOverTime * Time.deltaTime;
            hunger -= hungerOverTime * Time.deltaTime;
        }
        else
        {
            if (!Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.C))
            {
                stamina += staminaOverTime * Time.deltaTime;
            }
        }

        if (hunger <= 0.0f)
        {
            Debug.Log("Player has Died");
        }

        if (days <= 0.0f)
        {
            Debug.Log("Player has run out of time");
        }

        if (stamina <= 0)
        {
            canSprint = false;
        }
        else
        {
            if (!Input.GetKey(KeyCode.C))
            {
                canSprint = true;
            }
        }

        updateUi();
        

    }

    private void updateUi()
    {
        hunger = Mathf.Clamp(hunger, 0f, 100f);
        stamina = Mathf.Clamp(stamina, 0f, 100f);
        days = Mathf.Clamp(days, 0f, 100f);

        hungerBar.value = hunger;
        staminaBar.value = stamina;
        dayBar.value = days;
    }
}