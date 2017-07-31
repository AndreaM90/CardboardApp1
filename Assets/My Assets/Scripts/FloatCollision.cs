using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatCollision : MonoBehaviour {

    //distruzione dei terreni fluttuanti a contatto con i nemici

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "FloatGround")
        {
            Destroy(collision.gameObject);
        }
    }
}
