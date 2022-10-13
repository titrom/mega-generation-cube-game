using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Vector3 _move;
    private Vector3 _startPosition;
    public void CubeCreated(Vector3 startPosition)
    {
        _startPosition = startPosition;
    }
    private void Start()
    {
        DistributionMove();
    }

    private void DistributionMove()
    {
        var xMove = Random.Range(-1, 2);
        var yMove = Random.Range(-1, 2);
        if (xMove == 0 && yMove == 0) DistributionMove();
        else _move = new Vector3(xMove, 0, yMove);
    }

    private void FixedUpdate()
    {


        transform.Translate(new Vector3(_move.x * GameSettings.SpeedObject, 0, _move.z * GameSettings.SpeedObject));
        if (Vector3.Distance(_startPosition, transform.position) >= GameSettings.Distance)
        {
            Destroy(gameObject);
            GetComponentInParent<Spawner>().DestroyCount++;
        }
    }
}
