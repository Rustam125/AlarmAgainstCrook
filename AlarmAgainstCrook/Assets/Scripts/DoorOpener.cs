using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DoorOpener : MonoBehaviour
{
    [SerializeField] private Door _door;
    [SerializeField] private Animator _animator;
    
    private readonly int _openTrigger = Animator.StringToHash("Open");
    private readonly int _closeTrigger = Animator.StringToHash("Close");

    private bool _hasOpener;

    private void Update()
    {
        if (_hasOpener && Input.GetKeyDown(KeyCode.E))
        {
            if (_door.IsOpened)
            {
                Close();
            }
            else
            {
                Open();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            _hasOpener = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            _hasOpener = false;
        }
    }

    private void Open()
    {
        _animator.ResetTrigger(_closeTrigger);
        _animator.SetTrigger(_openTrigger);
        _door.Open();
    }
    
    private void Close()
    {
        _animator.ResetTrigger(_openTrigger);
        _animator.SetTrigger(_closeTrigger);
        _door.Close();
    }
}
