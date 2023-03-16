using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Floater : MonoBehaviour
{
    public float underWaterDrag = 3.0f;
    public float underWaterAngularDrag = 1.0f;

    public float airDrag = 0f;
    public float airAngularDrag = 0.05f;

    public float floatingPower = 35f;

    public float waterHeight = 0f;

    public float objectWeight = 4.0f;

    Rigidbody m_rigidBody;

    bool underWater;

    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();
        m_rigidBody.mass = objectWeight;
    }

    void FixedUpdate()
    {
        float distance = transform.position.y - waterHeight;
        Debug.LogWarning(distance);

        if(distance < 0)
        {
            m_rigidBody.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(distance), transform.position, ForceMode.Force);
            if (!underWater)
            {
                underWater = true;
                SwitchState(true);
            }
        }
        else if (underWater)
        {
            underWater = false;
            SwitchState(false);
        }
    }

    void SwitchState(bool isUnderWater)
    {
        if(isUnderWater)
        {
            m_rigidBody.drag = underWaterDrag;
            m_rigidBody.angularDrag = underWaterAngularDrag;
        }
        else
        {
            m_rigidBody.drag = airDrag;
            m_rigidBody.angularDrag = airAngularDrag;
        }
    }
}
