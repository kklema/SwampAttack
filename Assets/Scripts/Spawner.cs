using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Wave
{
    [SerializeField] private List<GameObject> _templates;

    public int TemplateCount => _templates.Count;

    public GameObject GetTemplate(int index)
    {
        if (index < _templates.Count)
        {
            return _templates[index];
        }
        else
        {
            return null;
        }
    }
}

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;
    [SerializeField] private float _delay;

    private List<Wave> _currentWaves;
    private int _currentWaveIndex = 0;
    private int _spawned;
    private int _spawnedMax;
    private int _allUnitsInWaves;
    private int _currentTemplateIndex = 0;
    private bool _isNextWaveNotReady;

    public event UnityAction AllEnemySpawned;
    public event UnityAction<int, int> EnemyCountChanged;

    private void Start()
    {
        InitWave();
    }

    private IEnumerator SpawnWave()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_delay);

        while (_isNextWaveNotReady)
        {
            if (_currentWaveIndex <= _currentWaves.Count)
            {
                if (_currentTemplateIndex <= _currentWaves[_currentWaveIndex].TemplateCount - 1)
                {
                    InstantiateEnemy(_currentWaveIndex, _currentTemplateIndex++);
                    _spawnedMax++;
                    EnemyCountChanged?.Invoke(_spawnedMax, _allUnitsInWaves);
                }
            }

            yield return waitForSeconds;

            if (_spawned >= _currentWaves[_currentWaveIndex].TemplateCount)
            {
                _isNextWaveNotReady = false;
                _currentWaveIndex++;
                _currentTemplateIndex = 0;
                AllEnemySpawned?.Invoke();
            }
        }
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;

        _player.AddMoney(enemy.Reward);
    }

    private void InstantiateEnemy(int waveIndex, int templateIndex)
    {
        Enemy enemy = Instantiate(_currentWaves[waveIndex].GetTemplate(templateIndex), _spawnPoint.position, _spawnPoint.rotation, _spawnPoint).GetComponent<Enemy>();
        enemy.Init(_player);
        enemy.Dying += OnEnemyDying;
        _spawned++;
    }

    private void InitWave()
    {
        _currentWaves = _waves;

        foreach (Wave wave in _currentWaves)
        {
            _allUnitsInWaves += wave.TemplateCount;
        }
    }

    public void NextWave()
    {
        _isNextWaveNotReady = true;
        _spawned = 0;
        StartCoroutine(SpawnWave());
    }
}