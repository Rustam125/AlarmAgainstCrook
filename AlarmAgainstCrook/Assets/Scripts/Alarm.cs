using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private const float MinVolume = 0f;
    private const float MaxVolume = 1f;
    private const float Duration = 0.5f;

    private bool _isSignalized;
    private Coroutine _coroutine;

    private void Awake()
    {
        _isSignalized = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() == false)
        {
            return;
        }

        _isSignalized = !_isSignalized;
        Signalize();
    }

    private void OnDestroy()
    {
        StopSignalCoroutine();
    }

    private void Signalize()
    {
        StopSignalCoroutine();

        if (_isSignalized)
        {
            _audioSource.volume = MinVolume;
            _audioSource.Play();
            _coroutine = StartCoroutine(SmoothSignalIncrease());
        }
        else
        {
            _coroutine = StartCoroutine(SmoothSignalReduce());
        }
    }

    private IEnumerator SmoothSignalIncrease()
    {
        var volume = MinVolume;

        while (volume < MaxVolume)
        {
            volume += Time.deltaTime * Duration;
            _audioSource.volume = volume;
            yield return null;
        }
    }

    private IEnumerator SmoothSignalReduce()
    {
        var volume = MaxVolume;

        while (volume > MinVolume)
        {
            volume -= Time.deltaTime * Duration;
            _audioSource.volume = volume;
            yield return null;
        }
    }

    private void StopSignalCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }
}