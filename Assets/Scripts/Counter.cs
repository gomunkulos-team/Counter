using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Counter : MonoBehaviour
{
    public event Action<float> NumberChanged;
    private Coroutine _coroutine;
    private float _timeInterval = 0.5f;

    public float Number { get; private set; }

    private WaitForSecondsRealtime _wait;

    private void Start()
    {
        _wait = new WaitForSecondsRealtime(_timeInterval);
        Number = 0;
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
            SwitchState();
    }

    private IEnumerator DisplayNumber()
    {
        while (enabled)
        {
            yield return _wait;
            Number++;
            NumberChanged?.Invoke(Number);
        }
    }

    private void SwitchState()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(DisplayNumber());
        }
        else
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }
}