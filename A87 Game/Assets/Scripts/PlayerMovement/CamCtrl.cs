using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCtrl : MonoBehaviour
{
    [SerializeField] private float lookSens;
    [SerializeField] private float smoothing;

    private GameObject player;
    private Vector2 smoothVelocity;
    private Vector2 currentLookingPosition;

    private void Start()
    {
        player = transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        RotateCamera();
        CheckForShooting();
    }

    private void RotateCamera()
    {
        Vector2 inputValues = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        inputValues = Vector2.Scale(inputValues, new Vector2(lookSens * smoothing, lookSens * smoothing));

        smoothVelocity.x = Mathf.Lerp(smoothVelocity.x, inputValues.x, 1f / smoothing);
        smoothVelocity.y = Mathf.Lerp(smoothVelocity.y, inputValues.y, 1f / smoothing);

        currentLookingPosition += smoothVelocity;

        transform.localRotation = Quaternion.AngleAxis(-currentLookingPosition.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(currentLookingPosition.x, player.transform.up);
        currentLookingPosition.y = Mathf.Clamp(currentLookingPosition.y, -80f, 80f);
    }

    private void CheckForShooting() 
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            RaycastHit whatIHit;
            if (Physics.Raycast(transform.position, transform.forward, out whatIHit, Mathf.Infinity)) 
            {
                IDamagable damagable = whatIHit.collider.GetComponent<IDamagable>();
                if (damagable != null) 
                {
                    damagable.Damage(10);
                }
            }
        }
    }
}