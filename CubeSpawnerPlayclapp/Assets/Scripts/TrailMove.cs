using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailMove : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float angle = 0f;

    private bool _isMove = false;

    private void OnEnable()
    {
        GameSettings.StartAndStopSimulete += StartAndStopTrailMove;
    }
    private void OnDisable()
    {
        GameSettings.StartAndStopSimulete -= StartAndStopTrailMove;
    }

    private void Update()
    {
        if (_isMove)
        {
            angle += Time.deltaTime;
            var x = Mathf.Cos(angle * _speed) * GameSettings.Distance;
            var z = Mathf.Sin(angle * _speed) * GameSettings.Distance;
            transform.position = new Vector3(x, transform.position.y, z);
        }
        else
        {
            transform.position = Vector3.zero;
        }
        
    }

    private void StartAndStopTrailMove() => _isMove = !_isMove;

}
