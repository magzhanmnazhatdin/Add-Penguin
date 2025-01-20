using UnityEngine;

public class AnimalSpawnMenu : MonoBehaviour
{
    [SerializeField] private AnimalSpawnButton _buttonPrefab;
    [SerializeField] private AnimalSpawner _spawner;

    private AnimalData[] GetAnimals() => Resources.LoadAll<AnimalData>("Animals");

    private void Start()
    {
        foreach (var animal in GetAnimals())
        {
            var button = Instantiate(_buttonPrefab, transform);
            button.Initialize(animal, _spawner);
        }
    }
}
