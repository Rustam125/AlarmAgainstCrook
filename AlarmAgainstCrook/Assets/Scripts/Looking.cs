using UnityEngine;

public class Looking : MonoBehaviour
{
    [SerializeField] private float _speed = 150f;
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _body;

    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";

    private void Update()
    {
        _camera.Rotate(_speed * -Input.GetAxis(MouseY) * Time.deltaTime * Vector3.right);
        _body.Rotate(_speed * Input.GetAxis(MouseX) * Time.deltaTime * Vector3.up);
    }
}
