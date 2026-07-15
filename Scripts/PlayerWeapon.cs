using Unity.VisualScripting;
using UnityEditor.Rendering.HighDefinition;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] laser;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targeDistance = 250f;

   
    bool isFiring = false;

    void Update()
    {
        ProcessFire();
        MoveCrosshair();
        MoveTargetPoint();
        FireToTarget();
    }

    void OnFire(InputValue fire)
{
    isFiring = fire.isPressed;
}

    void ProcessFire()
    {
    
        foreach(GameObject item in laser)
        {
            var Lasers = item.GetComponent<ParticleSystem>().emission;
            Lasers.enabled = isFiring;
        }
    
    }
    void MoveCrosshair()
    {
        crosshair.position = Mouse.current.position.ReadValue();
    }

    void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, targeDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }

    void FireToTarget()
    {
        foreach (GameObject lasers in laser)
        {
            Vector3 relativePos = targetPoint.position - transform.position;

            Quaternion rotation = Quaternion.LookRotation(relativePos);
            lasers.transform.rotation = rotation;
        }
    }

}
