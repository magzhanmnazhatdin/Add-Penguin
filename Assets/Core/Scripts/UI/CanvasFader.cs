using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class CanvasFader : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    private Coroutine _fadeRoutine;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void FadeIn()
    {
        if (_fadeRoutine != null) StopCoroutine(_fadeRoutine);
        _fadeRoutine = StartCoroutine(FadeRoutine(0f));
    }

    public void FadeOut()
    {
        if (_fadeRoutine != null) StopCoroutine(_fadeRoutine);
        _fadeRoutine = StartCoroutine(FadeRoutine(1f));
    }
    
    private IEnumerator FadeRoutine(float target)
    {
        while (Mathf.Abs(_canvasGroup.alpha - target) > 0.01f)
        {
            _canvasGroup.alpha = Mathf.Lerp(_canvasGroup.alpha, target, 0.05f);
            yield return null;
        }
        _canvasGroup.alpha = target;
    }
}
