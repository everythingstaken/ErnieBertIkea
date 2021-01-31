using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoTo : MonoBehaviour
{

    public Vector3 targetPos;
    public Vector3 startPos;
    public Quaternion targetRot;
    public Quaternion startRot;


    public float lerpSpeed=1f;
    public float percentage;


    private void Awake()
    {
        //transform.position = new Vector3(0, 0, 0);
        targetPos = transform.position;
        targetRot = transform.rotation;
        percentage = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {// Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            //Debug.Log("Did not Hit");
        }

        if (percentage < 1f)
        {
            percentage += lerpSpeed * Time.deltaTime;
        } 

        transform.position = Vector3.Lerp(startPos, targetPos, percentage);
        transform.rotation = Quaternion.Slerp(startRot, targetRot, percentage);

       // if ()
        {
            //SceneManager.LoadScene("Game");
        }

    }

    public void MoveCamera(Vector3 _targetPos, Quaternion _targetRot, float _speed)
    {

        if (_targetPos == transform.position)
        {
            return;
        }

        startPos = transform.position;
        startRot = transform.rotation;
        percentage = 0f;
        targetPos = _targetPos;
        targetRot = _targetRot;
        lerpSpeed = _speed;
    }
}
