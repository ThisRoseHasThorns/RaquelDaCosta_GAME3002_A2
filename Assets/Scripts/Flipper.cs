using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{

    public float basePosition = 0f;
    public float pressedPosition = 45f;
    public float hitStrength = 10000f;
    HingeJoint hinge;
    public float flipperDamper = 150f;

    public string inputName;
    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
    }

    // Update is called once per frame
    void Update()
    {
        JointSpring spring = new JointSpring();
        spring.spring = hitStrength;
        spring.damper = flipperDamper;

        if (Input.GetAxis(inputName) == 1)
        {
            spring.targetPosition = pressedPosition;
        }
        else
        {
            spring.targetPosition = basePosition;
        }
        hinge.spring = spring;
        hinge.useLimits = true;
    }
}
