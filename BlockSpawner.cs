using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    private Vector3 Min;
    private Vector3 Max;
    private float _xAxis;
    private float _zAxis;
    private Vector3 _randomPosition;
    public bool _canInstantiate;

    private int _int;

    [SerializeField] GameObject _game;
    [SerializeField] float _spawnerSpeed;
    [SerializeField] int _tuglaSayisi;
    [SerializeField] int _spawnYuksekligi;
    private void Start()
    {
        SetRanges();
        StartCoroutine(TuglaSpawn());
    }
    private void Update()
    {
        
    }
    private void SetRanges()
    {
        Min = new Vector3(-6.5f, 0, -6.5f); 
        Max = new Vector3(6.5f, 0, 6.5f); 
    }
    private void InstantiateRandomObjects()
    {
        if (_canInstantiate)
        {
            Instantiate(_game, _randomPosition, Quaternion.identity);

        }
    }

    IEnumerator TuglaSpawn()
    {
        while (_int < _tuglaSayisi)
        {
            _xAxis = Random.Range(Min.x, Max.x);
            _zAxis = Random.Range(Min.z, Max.z);
            _randomPosition = new Vector3(_xAxis, _spawnYuksekligi, _zAxis);
            InstantiateRandomObjects();
            yield return new WaitForSeconds(_spawnerSpeed);
            _int++;
        }
    }
}
