using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    private int _randObs;
    private DeadCondition _player;
    private AudioPeer _music;

    public int _band;

    private bool _activarSpawn, _blockSpawn;
    public GameObject[] _spawners;

    [Range(0.1f,2)]
    public float _difficulty = 1;

    void Start()
    {
        _activarSpawn = _blockSpawn = false;
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<DeadCondition>();
        _music = GameObject.FindGameObjectWithTag("Sound").GetComponent<AudioPeer>();
    }

    void Update()
    {
        if (!_player._dead)
        {
            Spawn();
            SoundSpawn();
        }
    }
    void Spawn()
    {
        if (_activarSpawn)
        {
            _spawners[_randObs].GetComponent<Spawn>()._activarSpawn = true;
            _activarSpawn = false;
        }
    }
    void SoundSpawn()
    {
        if(AudioPeer._bandBuffer[_band] > _difficulty && !_blockSpawn)
        {
            _randObs = Random.Range(0, 3);
            _activarSpawn = true;
            _blockSpawn = true;
        }
        if(AudioPeer._bandBuffer[_band] <= _difficulty)
        {
            _blockSpawn = false;
        }
    }
}
