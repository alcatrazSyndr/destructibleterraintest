using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTest_PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Transform _lookRoot;
    [SerializeField] private float _mouseSensitivity = 1.5f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        if (_rb != null)
        {
            _rb.MovePosition(_rb.position + (transform.TransformVector(new Vector3(movementInput.x, 0f, movementInput.y)).normalized * 0.04f));
        }

        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Quaternion lookRotation = _lookRoot.localRotation;
        lookRotation *= Quaternion.Euler(-mouseInput.y * _mouseSensitivity, 0f, 0f);
        _lookRoot.localRotation = lookRotation;

        Quaternion rbRotation = _rb.rotation;
        rbRotation *= Quaternion.Euler(0f, mouseInput.x * _mouseSensitivity, 0f);
        _rb.MoveRotation(rbRotation);
    }
}
