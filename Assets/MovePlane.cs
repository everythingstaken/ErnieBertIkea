using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlane : MonoBehaviour
{
    //public int interpolationFramesCount = 45;
    //int elapsedFrames = 0;
    //public Transform startMarker;
    //public Transform endMarker;
    public Vector3 PosA;
    public Vector3 PosB;
    private Vector3 targetNew;
    private Vector3 targetOld;

    public Vector3 AngleA;
    public Vector3 AngleB;
    private Vector3 targetAngle;
    public Vector3 targetB;
    private Vector3 currentAngle;

    float speedR = 0.1f;

    public float speed;

    public float startTime;

    public float journeyLength;

    public float fractionOfJourney;

    //public bool back = false;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;

        journeyLength = Vector3.Distance(transform.position, targetNew);

        targetNew = PosB;
        targetOld = PosA;

        currentAngle = transform.eulerAngles;

    }

    // Update is called once per frame
    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;

        fractionOfJourney = distCovered / journeyLength;

        transform.position = Vector3.Lerp(targetOld, targetNew, fractionOfJourney);


        currentAngle = new Vector3(
                Mathf.LerpAngle(currentAngle.x, targetAngle.x, fractionOfJourney),
                Mathf.LerpAngle(currentAngle.y, targetAngle.y, fractionOfJourney),
                Mathf.LerpAngle(currentAngle.z, targetAngle.z, fractionOfJourney));

        transform.eulerAngles = currentAngle;

        if (transform.position == PosB)
        {
            startTime = Time.time;
            targetOld = PosB;
            targetNew = PosA;
        }
        else if (transform.position == PosA)
        {
            startTime = Time.time;
            targetOld = PosA;
            targetNew = PosB;
        }



    }
}
