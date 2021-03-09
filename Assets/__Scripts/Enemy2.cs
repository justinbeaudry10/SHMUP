using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    private float direction;
    private float rand;

    private void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
        rand = Random.Range(0, 2);
    }

    public override void Move()
    {
        Vector3 tempPos = pos;
        
        if (rand == 0)
            direction = -1;
        else
            direction = 1;

        tempPos.x += speed * direction * Time.deltaTime;
        tempPos.y -= speed * Time.deltaTime;

        pos = tempPos;
    }


}
