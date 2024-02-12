using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Door : MonoBehaviour
{
    public Action DoorOpened;
    public Action DoorClosed;
    public Action<bool> DoorRotating;

    [SerializeField] private GameObject _doorHindge;
    [SerializeField] private float _openingTime = 1f;
    [SerializeField] private float _closingTime = 0.5f;

    private bool _isRotating = false;
    private bool _isOpen = false;
    private Quaternion _originalRotation;


    // Start is called before the first frame update
    void Start()
    {
        _originalRotation = _doorHindge.transform.localRotation;
    }

    public void OpenDoor(float rotation)
    {
        if(_isRotating || _isOpen)
        return;

        Quaternion targetRotation = Quaternion.Euler(_originalRotation.x, rotation, _originalRotation.z);
        StartCoroutine(AnimateDoor(targetRotation, _openingTime));
    }

    private IEnumerator AnimateDoor(Quaternion targetRotation, float duration)
    {
        float timeElapsed = 0;
        Quaternion startingRotation = _doorHindge.transform.localRotation;

        while (timeElapsed < duration)
        {
            _doorHindge.transform.localRotation = Quaternion.Lerp(startingRotation, targetRotation, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        _doorHindge.transform.localRotation = targetRotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
