using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private Door _door;
    [SerializeField] private AudioSource _audioSource;

    private bool _isSignalized;
    
    private void Awake()
    {
        _isSignalized = false;
        _door.Opened += Signalize;
    }

    private void Signalize()
    {
        if (_isSignalized)
        {
            return;
        }
        
        _audioSource.Play();
        _isSignalized = true;
    }
}
