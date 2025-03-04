using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera_look : MonoBehaviour
{
    private float XMove;
    private float YMove;
    private float XRotation;
    private float YRotation;
    [SerializeField] private Transform PlayerBody;
    public Vector2 LockAxis;
    public float Sensivity = 40f;
    public FixedTouchField _FixedTouchField;

    private InteractiveObject interactiveObject;
    [SerializeField] private Transform Hand_targetForInteractiveObject;
    [SerializeField] private GameObject throwButton;

    void Start()
    {

    }


    void Update()
    {
        LockAxis = _FixedTouchField.TouchDist;

        XMove = LockAxis.x * Sensivity * Time.deltaTime;
        YMove = LockAxis.y * Sensivity * Time.deltaTime;
        XRotation -= YMove;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);

        YRotation += XMove;

        transform.localRotation = Quaternion.Euler(XRotation, YRotation, 0);
        PlayerBody.Rotate(Vector3.up * XMove);

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);

            if (Physics.Raycast(ray, out RaycastHit hit, 10f))
            {
                InteractiveObject interactive = hit.transform.GetComponent<InteractiveObject>();
                if (interactive != null)
                {
                    if (interactiveObject == null)
                    {
                        interactiveObject = hit.transform.GetComponent<InteractiveObject>();

                        interactiveObject.TakeObject(Hand_targetForInteractiveObject);

                        Rigidbody rb = interactiveObject.GetComponent<Rigidbody>();
                        Collider collider = interactiveObject.GetComponent<Collider>();
                        if (rb != null)
                        {
                            rb.isKinematic = true;
                        }
                        if (collider != null)
                        {
                            collider.enabled = false;
                        }

                        throwButton.SetActive(true);
                    }
                }
            }
        }
    }

    public void ThrowObject()
    {
        if (interactiveObject != null)
        {
            interactiveObject.DropObject();
            Rigidbody rb = interactiveObject.GetComponent<Rigidbody>();
            Collider collider = interactiveObject.GetComponent<Collider>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }
            if (collider != null)
            {
                collider.enabled = true;
            }

            Vector3 throwDirection = transform.forward;
            rb.AddForce(throwDirection * 10f, ForceMode.Impulse);

            interactiveObject = null;

            throwButton.SetActive(false);
        }
    }
}
