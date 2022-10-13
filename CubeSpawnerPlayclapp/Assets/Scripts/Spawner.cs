using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    [SerializeField] private TextMeshProUGUI _numberObjectsTextBox;

    private long _nuberObject;

    public int DestroyCount { get; set; }

    private bool _startAndStopSpawn = false;


    private void OnEnable()
    {
        GameSettings.StartAndStopSimulete += Spawn;
    }

    private void OnDisable()
    {
        GameSettings.StartAndStopSimulete -= Spawn;
    }

    private void Update()
    {
        _numberObjectsTextBox.text = $"In motion {transform.childCount}. Destroyed {DestroyCount} left {_nuberObject}";

    }

    private void Spawn()
    {
        _startAndStopSpawn = !_startAndStopSpawn;
        if (_startAndStopSpawn)
        {
            _nuberObject = GameSettings.NumberObjects;
            StartCoroutine(SpawnCoroutine());
        }
        else
        {
            StopSpawn();
        }
    }

    public void StopSpawn()
    {
        StopCoroutine(SpawnCoroutine());
        _nuberObject = 0;
        DestroyCount = 0;
        for (var i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    private IEnumerator SpawnCoroutine()
    {
        while(_nuberObject > 0)
        {
            var newCube = Instantiate(_prefab, transform);
            newCube.GetComponent<Cube>().CubeCreated(transform.position);
            _nuberObject--;
            yield return new WaitForSeconds(GameSettings.SpawnDelay);
        }
    }
}
