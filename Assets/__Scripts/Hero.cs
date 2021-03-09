using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    static public Hero S; // Singleton

    public float speed = 30;
    public float rollMult = -45;
    public float pitchMult = 30;

    private void Awake()
    {
        if (S == null)
        {
            S = this; // Set the Singleton
        }
        else
        {
            Debug.LogError("Hero.Awake() - Attempted to assign second Hero.S!");
        }
    }

    private void Update()
    {
        // Pull in information from the Input class
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        // Change transform.position based on the axes
        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;

        // Rotate the ship
        transform.rotation = Quaternion.Euler(yAxis * pitchMult, xAxis * rollMult, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.transform.root.gameObject);
        Destroy(gameObject);
        Main.S.DelayedRestart();
    }

    
}
