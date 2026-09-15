using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _mouseSensitivity;
    [SerializeField] private Transform _cameraPivot;
    [SerializeField] private float _minPitch;
    [SerializeField] private float _maxPitch;
    private Rigidbody _rigidbody;
    private float _pitch;

    private void Awake()
    {
        CacheComponents();
    }

    public void Move()
    {
        // 입력을 통한 방향 구하기
        Vector3 input = ReadMoveInput();

        // 새로운 속도값 설정
        //Vector3 newVelocity = new Vector3(
        //    input.x * _moveSpeed,
        //    _rigidbody.velocity.y,
        //    input.z * _moveSpeed
        //    );
        Vector3 direction = transform.right * input.x + transform.forward * input.z;
        Vector3 newVelocity = new Vector3(
           direction.x * _moveSpeed,
           _rigidbody.velocity.y,
            direction.z * _moveSpeed
            );
        // _rigidbody.velocity에 적용.
        _rigidbody.velocity = newVelocity;
    }

    private Vector3 ReadMoveInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        return new Vector3(x, 0, z).normalized;
    }

    private void CacheComponents()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Rotate()
    {
        // 마우스 입력 받기
        // Vector3 input = ReadRotateInput();만 하면 정해진 것이 없음.
        // 감도를 추가해볼 것임. 
        Vector3 input = ReadRotateInput() * _mouseSensitivity;

        // 회전
        // 좌우 -> 회전 (로컬 좌표에서 돌아가야 하므로 Self).
        transform.Rotate(0, input.y, 0, Space.Self);
        // 상하 -> 범위 내로 들어오게 해야 함. Clamp 함수로 가능.
        // 입력받은 x값을 더했을 때, 범위 밖으로 벗어나지는 않는지?
        _pitch = Mathf.Clamp(_pitch + input.x, _minPitch, _maxPitch);
        // 회전. 부모에 속한 것을 돌려야 하므로 로컬.
        _cameraPivot.localRotation = Quaternion.Euler(_pitch, 0, 0);
    }

    private Vector3 ReadRotateInput()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        return new Vector3(-y, x, 0);
    }
}
