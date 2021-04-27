using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpReturn : SteeringBehaviour
{
    private GameObject _player;
    public Transform ballHoldPosition;
    [HideInInspector]public GameObject targetBall;
    private bool _hasBall;
    private float _dropDistance = 4;

    private void Start()
    {
        _player = FindObjectOfType<FPSController>().gameObject;
    }

    public override Vector3 Calculate()
    {
        Proximity();
        return Vector3.zero/*boid.ArriveForce(targetPosition, slowingDistance)*/;
    }

    public Vector3 Proximity()
    {
        if (_hasBall && Vector3.Distance(this.transform.position, _player.transform.position) <= _dropDistance)
        {
            _hasBall = false;
            DropBall();
        } 
        else if (!_hasBall && Vector3.Distance(this.transform.position, _player.transform.position) > _dropDistance)
        {
            _hasBall = true;
            PickUpBall();
        } 
        if (_hasBall)
        {
            return boid.ArriveForce(targetPosition, slowingDistance);
        }
        else if (!_hasBall)
        {
            return boid.SeekForce(targetBall.transform.position);
        }
    }
    
    public void DropBall()
    {
        targetBall.GetComponent<Rigidbody>().useGravity = true;
        targetBall.transform.SetParent(null);
    }

    public void PickUpBall()
    {
        targetBall.GetComponent<Rigidbody>().useGravity = false;
        targetBall.transform.SetParent(ballHoldPosition);
    }
}
