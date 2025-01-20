using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnimalSpawnButton : MonoBehaviour
{
    private Button _button;
    private TMP_Text _text;

    private void Awake()
    {
        _button = GetComponentInChildren<Button>();
        _text = GetComponentInChildren<TMP_Text>();
    }

    public void Initialize(AnimalData data, AnimalSpawner spawner)
    {
        _text.text = data.Stats.name;
        _button.onClick.AddListener(() => spawner.StartSpawnAnimal(data));
    }
}