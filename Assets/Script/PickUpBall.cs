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
        Debug.Log(Vector3.Distance(this.transform.position, FindObjectOfType<FPSController>().transform.position));
        if (Vector3.Distance(this.transform.position, FindObjectOfType<FPSController>().transform.position) <= _pickUpRange)
        {
            FindObjectOfType<Seek>().targetGameObject.transform.SetParent(null);
            if(!GetComponent<AudioSource>().isPlaying) GetComponent<AudioSource>().Play();
        }
    }

    private void PickUp(GameObject obj)
    {
        obj.transform.position = location.transform.position;
        obj.transform.SetParent(location.transform);
        FindObjectOfType<Seek>().enabled = false;
        FindObjectOfType<Arrive>().enabled = true;
    }
}