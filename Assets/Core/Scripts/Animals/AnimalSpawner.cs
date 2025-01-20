using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    [SerializeField] private LayerMask _applicableSurface;
    [SerializeField] private Animal _animalPrefab;
    
    private HashSet<Animal> _spawnedAnimals = new();
    private bool _isSpawning;
    private GameObject _spawnReticle;
    private RaycastHit _spawnPoint;
    private AnimalData _animalToSpawn;

    public void StartSpawnAnimal(AnimalData data)
    {
        _animalToSpawn = data;
        _spawnReticle = Instantiate(data.AnimalVisuals);
        _isSpawning = true;
    }

    public void ClearAnimals()
    {
        foreach (var animal in _spawnedAnimals)
        {
            Destroy(animal.gameObject);
        }
        _spawnedAnimals.Clear();
    }

    private void Update()
    {
        if (_isSpawning) ProcessSpawn();
    }

    private void ProcessSpawn()
    {
        if (!IsApplicablePoint()) return;
        
        AdaptReticle();

        if (Input.GetMouseButtonDown(0))
        {
            SpawnAnimal(_animalToSpawn, _spawnPoint.point);
            Destroy(_spawnReticle);
            _isSpawning = false;
        }
    }

    private bool IsApplicablePoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out _spawnPoint, Mathf.Infinity, _applicableSurface);
    }

    private void AdaptReticle()
    {
        if (_spawnReticle)
            _spawnReticle.transform.position = _spawnPoint.point;
    }

    private void SpawnAnimal(AnimalData data, Vector3 position)
    {
        var animal = Instantiate(_animalPrefab, position, Quaternion.identity, transform);
        animal.Initialize(data);
        _spawnedAnimals.Add(animal);
    }
}