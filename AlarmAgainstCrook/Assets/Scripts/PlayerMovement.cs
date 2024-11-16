using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 50f;
    [SerializeField] private float _moveSpeed = 5f;
    
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    private void Update()
    {
        Move();
    }
    
    private void Move()
    {
        var direction = new Vector3(Input.GetAxis(Horizontal), 0f, Input.GetAxis(Vertical));
        var distance = _moveSpeed *  Time.deltaTime * direction;
        transform.Translate(distance);
    }
}
