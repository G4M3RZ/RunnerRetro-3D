using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesController : MonoBehaviour
{
    private Vector3 _startPos;
    public float _limit;

    private float _moves;

    private void Start()
    {
        _startPos = transform.position;
        _moves = 0;
    }
    private void Update()
    {
        _startPos = new Vector3(_moves, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, _startPos, Time.deltaTime * 10);
    }
    public void Left()
    {
        if(_moves > -_limit)
        {
            _moves -= _limit;
        }
    }
    public void Right()
    {
        if(_moves < _limit)
        {
            _moves += _limit;
        }
    }
}
