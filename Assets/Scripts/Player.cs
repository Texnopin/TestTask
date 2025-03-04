using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    private MovemantHandler _handler;
    [SerializeField] private float speed;
    private Camera _mainCamera;
    private CharacterController _characterController;
    private float XMove;
    private float YMove;
    private float XRotation;
    public Vector2 LockAxis;
    public float Sensivity = 40f;

    void Start()
    {
        _mainCamera = Camera.main;
        _characterController = GetComponent<CharacterController>();
    }

    [Inject]
    private void Construct(MovemantHandler handler)
    {
        _handler = handler;
    }

    public void Move(Vector3 direction)
    {
        Vector3 movement = transform.TransformDirection(direction);
        _characterController.Move(movement * Time.deltaTime * speed);
    }


    void LateUpdate()
    {
        Vector3 offset = new Vector3(0, 0.7f, 0.5f);
        _mainCamera.transform.position = transform.position + transform.rotation * offset;
    }


    void OnDestroy()
    {

    }

}
