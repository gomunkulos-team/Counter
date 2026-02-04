using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _numberText;
    [SerializeField] private Button _button;
    private float _number = 0;
    private float _timeInterval = 0.5f;
    private Coroutine _coroutine;

    private WaitForSecondsRealtime _wait;

    private void Start()
    {
        _wait = new WaitForSecondsRealtime(_timeInterval);
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(SwitchState);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(SwitchState);
    }

    private IEnumerator DisplayNumber()
    {
        while (enabled)
        {
            yield return _wait;
            _number++;
            _numberText.text = _number.ToString();
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