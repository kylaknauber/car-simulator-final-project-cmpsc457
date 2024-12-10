using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{

    public AnimationCurve motionCurve;   
    public float openAngle = 90f;        
    public float animationDuration = 2f; 
    public KeyCode toggleKey = KeyCode.O; 
    private Quaternion closedRotation;   
    private Quaternion openRotation;     
    private bool isOpening = false;      
    private bool isClosed = true;        
    private float animationTime = 0f;    

    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, openAngle, 0));
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey) && !isOpening)
        {
            isOpening = true;
            animationTime = 0f; 
        }

        // Animate the door
        if (isOpening)
        {
            AnimateDoor();
        }
    }

    private void AnimateDoor()
    {
        animationTime += Time.deltaTime;

        if (animationTime <= animationDuration)
        {
            float t = animationTime / animationDuration;   
            float curveValue = motionCurve.Evaluate(t);   
            if (isClosed)
            {
                transform.rotation = Quaternion.Lerp(closedRotation, openRotation, curveValue);
            }
            else
            {
                transform.rotation = Quaternion.Lerp(openRotation, closedRotation, curveValue);
            }
        }
        else
        {
            isOpening = false;       
            isClosed = !isClosed;    
        }
    }
}

