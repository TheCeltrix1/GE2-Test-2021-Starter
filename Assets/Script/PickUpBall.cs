using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBall : MonoBehaviour
{
    public GameObject location;
    private float _pickUpRange = 2f;

    private void Update()
    {
        if (FindObjectOfType<Seek>().targetGameObject && Vector3.Distance(this.transform.position, FindObjectOfType<Seek>().targetGameObject.transform.position) <= _pickUpRange) PickUp(FindObjectOfType<Seek>().targetGameObject);
        /*if (Vector3.Distance(this.transform.position, FindObjectOfType<FPSController>().transform.position) <= 4)
        {
            if(FindObjectOfType<Seek>().targetGameObject != null) FindObjectOfType<Seek>().targetGameObject.transform.SetParent(null);
            if (!GetComponent<AudioSource>().isPlaying) GetComponent<AudioSource>().Play();
        }*/
        DropBall();
    }

    private void PickUp(GameObject obj)
    {
        if (Vector3.Distance(this.transform.position, FindObjectOfType<FPSController>().transform.position) > 4)
        {
            obj.transform.position = location.transform.position;
            obj.transform.SetParent(location.transform);
            FindObjectOfType<Seek>().enabled = false;
            FindObjectOfType<Arrive>().enabled = true;
        }
    }

    private void DropBall()
    {
        if (Vector3.Distance(this.transform.position, FindObjectOfType<FPSController>().transform.position) <= 4)
        {
            FindObjectOfType<Seek>().targetGameObject.transform.position = location.transform.position;
            FindObjectOfType<Seek>().targetGameObject.transform.SetParent(null);
            FindObjectOfType<Seek>().enabled = true;
            FindObjectOfType<Arrive>().enabled = false;
        }
    }
}