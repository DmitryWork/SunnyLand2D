using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform _location;
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private int _amount;
    [SerializeField] private float _timeToWait;

    public void Spawn()
    {
        StartCoroutine(CreateObjects());
    }

    private IEnumerator CreateObjects()
    {
        for (int i = 0; i < _amount; i++)
        {
            Instantiate(_coinPrefab, _location.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(_timeToWait);
        }
    }
}