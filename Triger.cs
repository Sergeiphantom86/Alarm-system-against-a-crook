using System.Collections;
using UnityEngine;

public class Triger : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;

    private float _maxVolume;

    private AudioSource audioSource => GetComponent<AudioSource>();

    private void OnTriggerEnter(Collider criminal)
    {
        if (criminal.TryGetComponent(out Rogue _))
        {
            _maxVolume = 1;

            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(_audioClip, audioSource.volume);
            }

            StartCoroutine(ChangeVolume());
        }
    }

    private void OnTriggerExit(Collider criminal)
    {
        if (criminal.TryGetComponent(out Rogue _))
        {
            _maxVolume = 0;
        }
    }

    private IEnumerator ChangeVolume()
    {
        float delay = 0.1f;
        float stepUpVolume = 0.01f;
        float minVolume = 0;

        WaitForSeconds wait = new(delay);

        while (enabled)
        {
            audioSource.volume = minVolume;

            minVolume = Mathf.MoveTowards(minVolume, _maxVolume, stepUpVolume);

            yield return wait;
        }
    }
}