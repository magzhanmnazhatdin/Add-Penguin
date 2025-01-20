using System;
using TMPro;
using UnityEngine;

[Serializable]
public class AnimalUI
{
    [SerializeField] private CanvasFader _fader;
    [SerializeField] private TMP_Text _animalNameText;

    public void Initialize(AnimalStats stats)
    {
        _animalNameText.text = stats.name;
    }

    public void OnHoverEnter()
    {
        _fader.FadeOut();
    }

    public void OnHoverExit()
    {
        _fader.FadeIn();
    }
}