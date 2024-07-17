using System.Collections;
using UnityEngine;

public class Triger : MonoBehaviour
{
    private float _target;
    private float _minVolume = 0;
    private float _stepUpVolume = 0.01f;
    private Coroutine _coroutine;

    private AudioSource _audioSource => GetComponent<AudioSource>();

    private void Start()
    {
        _audioSource?.Stop();
    }

    private void OnTriggerEnter(Collider criminal)
    {
        if (criminal.TryGetComponent(out Rogue _))
        {
            _target = 1;

            _audioSource.Play();

            _coroutine = StartCoroutine(ChangeVolume());
        }
    }

    private void OnTriggerStay(Collider criminal)
    {
        if (criminal.TryGetComponent(out Rogue _))
        {
            if (_audioSource.volume >= _target)
            {
                StopCoroutine(_coroutine);
            }
        }
    }

    private void OnTriggerExit(Collider criminal)
    {
        if (criminal.TryGetComponent(out Rogue _))
        {
            _target = 0;
        }
    }

    private IEnumerator ChangeVolume()
    {
        float delay = 0.1f;
        
        WaitForSeconds wait = new(delay);

        while (enabled)
        {
            _audioSource.volume = _minVolume;

            _minVolume = Mathf.MoveTowards(_minVolume, _target, _stepUpVolume);

            yield return wait;
        }
    }
}
