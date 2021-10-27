using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextWave : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Button _nexWaveButton;

    private void Start()
    {
        _nexWaveButton.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        _spawner.AllEnemySpawned += OnAllEnemySpawned;
        _nexWaveButton.onClick.AddListener(OnNextWaveButtonCLick);
    }

    private void OnDisable()
    {
        _spawner.AllEnemySpawned -= OnAllEnemySpawned;
        _nexWaveButton.onClick.RemoveListener(OnNextWaveButtonCLick);
    }

    public void OnAllEnemySpawned()
    {
        _nexWaveButton.gameObject.SetActive(true);
    }

    public void OnNextWaveButtonCLick()
    {
        _spawner.NextWave();
       _nexWaveButton.gameObject.SetActive(false);
    }
}
