using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TimerView : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private TextMeshProUGUI _numberText;
    private float _number = 0;
    private float _timeInterval = 0.5f;
    private Coroutine _coroutine;

    private WaitForSecondsRealtime _wait;

    private void Start()
    {
        _wait = new WaitForSecondsRealtime(_timeInterval);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SwitchState();
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