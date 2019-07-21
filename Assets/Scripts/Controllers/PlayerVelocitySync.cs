using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVelocitySync : MonoBehaviour
{
    CharacterController controller;
    public GameObject sunlight;
    Vector3 _MovingSpeed = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _MovingSpeed.x = controller.velocity.x;
        sunlight.GetComponent<AutoIntensity>()._MovingSpeed = _MovingSpeed;
    }
}
