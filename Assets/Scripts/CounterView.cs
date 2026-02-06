using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _numberText;

    private void OnEnable()
    {
        _counter.NumberChanged += OnNumberChanged;
    }

    private void OnDisable()
    {
        _counter.NumberChanged -= OnNumberChanged;
    }

    private void OnNumberChanged(float number)
    {
        _numberText.text = number.ToString();
    }
}