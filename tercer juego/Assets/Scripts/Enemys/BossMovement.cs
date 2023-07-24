using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public Transform leftPoint;
    public Transform rightPoint;
    public float movementSpeed = 5f;

    private bool movingRight = true;
    
    // Update is called once per frame
    void Update()
    {
        if(movingRight)
        {
            transform.Translate(Vector2.right* movementSpeed*Time.deltaTime);
            
            if (transform.position.x >= rightPoint.position.x)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector2.left *movementSpeed* Time.deltaTime);

            if (transform.position.x <= leftPoint.position.x)
            {
                movingRight = true;
            }
        }    
    }
}
