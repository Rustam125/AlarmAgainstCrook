using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private const float MinVolume = 0f;
    private const float MaxVolume = 1f;
    private const float Duration = 0.5f;
    
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _coroutine;

    public void TurnOn()
    {
        StopSignalCoroutine();
        _audioSource.volume = MinVolume;
        _audioSource.Play();
        _coroutine = StartCoroutine(SmoothVolumeChange(true));
    }
    
    public void TurnOff()
    {
        StopSignalCoroutine();
        _coroutine = StartCoroutine(SmoothVolumeChange(false));
    }
    
    private IEnumerator SmoothVolumeChange(bool zoomIn)
    {
        var volume = zoomIn ? MinVolume : MaxVolume;
        var isNotReachedValue = true;

        while (isNotReachedValue)
        {
            var duration = Time.deltaTime * Duration;
            volume += zoomIn ? duration : duration * -1;
            _audioSource.volume = volume;
            isNotReachedValue = zoomIn ? volume < MaxVolume : volume > MinVolume;
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