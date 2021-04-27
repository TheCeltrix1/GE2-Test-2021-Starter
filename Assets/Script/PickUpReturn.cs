using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpReturn : SteeringBehaviour
{
    private GameObject _player;
    public Transform ballHoldPosition;
    [HideInInspector] public GameObject targetBall;
    private bool _hasBall = false;
    private float _dropDistance = 5;

    private void Start()
    {
        _player = FindObjectOfType<FPSController>().gameObject;
    }

    public override Vector3 Calculate()
    {
        return Proximity();
    }

    public Vector3 Proximity()
    {
        if (targetBall != null)
        {
            if (_hasBall && Vector3.Distance(this.transform.position, _player.transform.position) <= _dropDistance)
            {
                _hasBall = false;
                DropBall();
            }
            else if (!_hasBall && Vector3.Distance(this.transform.position, _player.transform.position) > _dropDistance && Vector3.Distance(this.transform.position, targetBall.transform.position) <= _dropDistance)
            {
                _hasBall = true;
                PickUpBall();
            }
            if (_hasBall) return boid.ArriveForce(_player.transform.position, .5f);
            else if (!_hasBall) return boid.SeekForce(targetBall.transform.position);
        }
        else if (!targetBall)
        {
            /*if (Vector3.Distance(transform.position, _player.transform.position) <= 4) return Vector3.zero;
            else*/ return boid.ArriveForce(_player.transform.position, 0.5f);
        }
        return Vector3.zero;
    }

    public void DropBall()
    {
        GetComponent<AudioSource>().Play();
        targetBall.GetComponent<Rigidbody>().useGravity = true;
        targetBall.transform.SetParent(null);
        //targetBall = null;
    }

    public void PickUpBall()
    {
        targetBall.GetComponent<Rigidbody>().useGravity = false;
        targetBall.transform.position = ballHoldPosition.transform.position;
        targetBall.transform.SetParent(ballHoldPosition);
    }
}
