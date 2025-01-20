using UnityEngine;

public class Animal : MonoBehaviour, IHoverable
{
    [SerializeField] private AnimalAI _ai;
    [SerializeField] private AnimalUI _ui;
    
    private AnimalAnimation _animation;
    private AnimalData _animalData;

    public void Initialize(AnimalData animalData)
    {
        _animalData = animalData;
        var visuals = Instantiate(animalData.AnimalVisuals, transform);
        
        _ai.Initialize(_animalData.Stats);
        _ui.Initialize(_animalData.Stats);
        _animation = new AnimalAnimation(_ai, visuals.GetComponent<Animator>());
    }

    private void Update()
    {
        _animation.Update();
    }

    private void OnDestroy()
    {
        _ai.Dispose();
    }

    public void OnHoverEnter() => _ui.OnHoverEnter();

    public void OnHoverExit() => _ui.OnHoverExit();
}