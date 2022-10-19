using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 3;
    int currentHealth;

    //INVENCIBLE
    public float timeInvencible = 2f;
    bool isInvencible;
    float invencibleTimer;


    // Start is called before the first frame update
    void Start()
    {
        //VIDA
        currentHealth = maxHealth;
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 10;

        //INVENCIBLE
        isInvencible = false;
    }

    // Update is called once per frame
    void Update()
    {
        checkMovement();
        checkInvencible();
    }


    void checkMovement()
    {
        //MOVIMIENTO
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        /*float rotIzq = Input.GetAxis("Fire1");
        float rotDer = Input.GetAxis("Fire2");*/

        Vector2 position = transform.position;
        position.x = position.x + 3f * horizontal* Time.deltaTime;
        position.y = position.y + 3f * vertical* Time.deltaTime;

        /*Quaternion rotation = transform.rotation;
        rotation.z = rotation.z + 0.01f * rotIzq;
        rotation.z = rotation.z - 0.01f * rotDer;

        Debug.Log(rotIzq);*/

        transform.position = position;
        //transform.rotation = rotation;

    }

    void checkInvencible()
    {
        //INVENCIBLE
        if (isInvencible)
        {
            invencibleTimer -= Time.deltaTime;
            if (invencibleTimer <= 0)
            {
                isInvencible = false;
            }
        }
    }

    public void changeHealth(int amount) {

        if (amount < 0)
        {
            if (isInvencible)
            {
                return;
            }
            
            isInvencible = true;
            invencibleTimer = timeInvencible;
        }
        currentHealth += amount;
        if (currentHealth < 0) {
            currentHealth = 0;
        } else if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }

        Debug.Log("currentHealth: " + currentHealth);
    }

}
