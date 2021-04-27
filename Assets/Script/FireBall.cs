using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private float _ballVelocity = 15f;
    public GameObject ball;
    public static bool canThrow = true;

    void Update()
    {
        if (Input.GetKeyDown("space") && canThrow) Function();
    }

    private void Function()
    {
        canThrow = false;
        GameObject go = Instantiate(ball, this.transform.position, this.transform.rotation);
        go.GetComponent<Rigidbody>().velocity = go.transform.forward * _ballVelocity;
        FindObjectOfType<PickUpReturn>().targetBall = go;
    }

    private void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            if (collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude == 0) 
            {
                FindObjectOfType<Seek>().targetGameObject = null;
                Destroy(collision.gameObject);
                canThrow = true;
            }
        }
    }
}
