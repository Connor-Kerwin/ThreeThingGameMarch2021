using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;
    public float StrafeSpeed;
    public float TurnRate;

    public float HeadLerpFactor = 0.3f;
    public float HeadBobMagnitude = 0.1f;
    public float HeadBobFrequency = 0.1f;
    public float HeadBobLerpFactor = 0.3f;

    public Rigidbody rBody;
    public Transform head;
    public Transform innerHead;

    private Vector3 input;
    private Vector3 rotation;
    private float bob;

    //public void SetMode(PlayerMode mode)
    //{
    //    if(mode == PlayerMode.Local)
    //    {
    //        enabled = true;
    //    }
    //    else // Not local!
    //    {
    //        enabled = false;
    //    }
    //}

    private void LateUpdate()
    {
        float axisX = Input.GetAxis("Horizontal") * StrafeSpeed;
        float axisY = Input.GetAxis("Vertical") * MoveSpeed;
        input = new Vector3(axisX, axisY, 0.0f);

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotation.x += -mouseY * TurnRate * Time.deltaTime;
        rotation.y += mouseX * TurnRate * Time.deltaTime;
        rotation.x = Mathf.Clamp(rotation.x, -90.0f, 90.0f);

        Quaternion curHeadRotation = head.transform.rotation;
        head.transform.rotation = Quaternion.Lerp(curHeadRotation, Quaternion.Euler(rotation), HeadLerpFactor);

        float sum = Mathf.Clamp(Mathf.Abs(axisX) + Mathf.Abs(axisY), 0.0f, 1.0f);
        float sin = Mathf.Sin(Time.time * HeadBobFrequency) * HeadBobMagnitude * Time.deltaTime;
        bob = sin * sum;

        Vector3 curInnerHeadPos = innerHead.transform.localPosition;
        innerHead.transform.localPosition = Vector3.Lerp(curInnerHeadPos, new Vector3(0.0f, bob, 0.0f), HeadBobLerpFactor);

        //Vector3 fwd = head.forward;

        //Quaternion curRot = head.transform.rotation;
        //curRot *= Quaternion.Euler(mouseY * TurnRate, mouseX * TurnRate, 0.0f);

        //fwd = curRot * fwd;
        //Quaternion result = Quaternion.LookRotation(fwd, Vector3.up);
        //head.transform.rotation = result;

        //Vector3 curEuler = head.rotation.eulerAngles;
        //curEuler.y += mouseX * Time.deltaTime * TurnRate;
        //head.transform.rotation = Quaternion.Euler(curEuler);

        //Quaternion.ro

        //head.transform.rotation = Quaternion.LookRotation()
    }

    private void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime;

        float x = input.x * delta;
        float y = input.y * delta;

        Vector3 fwd = head.transform.forward;
        fwd.y = 0.0f;
        Vector3 right = head.transform.right;
        right.y = 0.0f;

        Vector3 velocity = (fwd * y) + (right * x);
        Vector3 mPos = transform.position + velocity;
        rBody.MovePosition(mPos);
    }
}
