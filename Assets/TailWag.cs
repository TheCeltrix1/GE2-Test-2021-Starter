using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailWag : MonoBehaviour
{
    private float _speed = 2f;
    private float _maxTurn = 30;

    void Update()
    {
        WagBitchWag();
    }

    public void WagBitchWag()
    {
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(0, _maxTurn, 0), _speed);
        if (transform.localRotation == Quaternion.Euler(0, _maxTurn, 0)) _maxTurn = -_maxTurn;
    }
}
