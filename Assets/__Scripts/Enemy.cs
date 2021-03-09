using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    protected BoundsCheck bndCheck;

    private void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }

    public Vector3 pos
    {
        get
        {
            return (this.transform.position);
        }
        set
        {
            this.transform.position = value;
        }
    }

     private void Update()
     {
        Move();

        if(bndCheck != null && !bndCheck.isOnScreen)
        {
            Destroy(gameObject);
        }
     }

    public virtual void Move()
    {
        Vector3 tempPos = pos;
       
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }
}
