using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _rotateSpeed;
    private float _rotation;
    private float _lastRotation;

    private float _afkTime = 0f;

    void Start()
    {
        _lastRotation = _rotation = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_rotation == _lastRotation)
        {
            _afkTime += 0.1f * Time.deltaTime;
        }
        if (_rotation != _lastRotation)
        {
            _afkTime = 0;
            _lastRotation = _rotation;
            _animator.speed = 0;
            _animator.Play("PingPong", 0, 0f);
        }
        if (_afkTime >= 0.1f)
        {
            _animator.speed = 1;
        }
        _rotation = Input.GetAxis("Horizontal") * _rotateSpeed * Time.deltaTime;
    }
    private void LateUpdate()
    {
        _player.transform.Rotate(0f, 0f, _rotation);
    }
}