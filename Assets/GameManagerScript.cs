using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public Texture2D cursor;
    public Texture2D cursorClicked;

    private CursorControls controls;
    private Camera mainCamera;
    public GameObject bigCamera;

    public Vector3 newPos;
    private ClickScript click_script;
    private GoTo goToScript;
    //public VideoPlayer movieTexture;

    //private GoTo goToScript;

    //[SerializeField] private @Controls _controls;

    //ClickScript clickScript = GameObject.Find("name of your object").GetComponent<ClickScript>();


    private void Awake()
    {


        controls = new CursorControls();
        ChangeCursor(cursor);
        Cursor.lockState = CursorLockMode.Confined;
        mainCamera = Camera.main;
        goToScript = mainCamera.GetComponent<GoTo>();
    }

    private void OnEnable()
    {
        controls.Enable();
       // _controls.Reset.Reset.performed += gameReset;
    }

    //private void gameReset; (InputAction.CallbackContext context){}

    private void Reset_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    // Start is called before the first frame update
    private void Start()
    {
        controls.Mouse.Click.started += _ => StartedClick();
        controls.Mouse.Click.performed += _ => EndedClick();
    }

    private void StartedClick()
    {
        if (goToScript.percentage >= 1f)
        {
            ChangeCursor(cursorClicked);
            DetectObject();

        }

    }

    private void EndedClick()
    {
        ChangeCursor(cursor);
    }

    private void DetectObject()
    {
        Ray ray = mainCamera.ScreenPointToRay(controls.Mouse.Position.ReadValue<Vector2>());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                //if(render)
                ClickScript cs = hit.collider.gameObject.GetComponent<ClickScript>();
                Debug.Log("3D Hit: " + hit.collider.tag);

                if (cs == null)
                {
                    Debug.Log("shut up");
                } else {

                goToScript.MoveCamera(cs.newCamPos, Quaternion.Euler(cs.newCamRot), cs.speed);
                cs.GetComponent<AudioSource>().Play();
                if (cs.GetComponent<UnityEngine.Video.VideoPlayer>() != null)
                {
                    //videoPlayer.url = System.IO.Path.Combine (Application.streamingAssetsPath, "myfile.mp4")
                    cs.GetComponent<UnityEngine.Video.VideoPlayer>().Play();
                }


            }

                //cs.GetComponent<Renderer>().material.mainTexture = movieTexture;

                //if (movieTexture.isPlaying)
                //{
                //    movieTexture.Pause();
                //    AudioSource.Pause();
                //}
            }
        }

        //RaycastHit[] hits = Physics.RaycastAll(ray, 200);
        //for (int i = 0; i <hits.Length; ++i) {
        //    if(hits[i].collider != null)
        //    {
        //        Debug.Log("3D Hit All:" + hits[i].collider.tag);
        //    }
        //}

        //RaycastHit[] hitsNonAlloc = new RaycastHit[1];
        //int numberOfHits = Physics.RaycastNonAlloc(ray, hitsNonAlloc);
        //for (int i = 0; i < numberOfHits; ++i)
        //{
        //    if (hitsNonAlloc[i].collider != null)
        //    {
        //        ClickScript cs = hitsNonAlloc[i].collider.gameObject.GetComponent<ClickScript>();
        //        //mainCamera.transform.position = cs.newCamPos;
        //        Debug.Log("3D Hit Non Alloc All:" + hitsNonAlloc[i].transform.position);
        //        goToScript.MoveCamera(cs.newCamPos, Quaternion.Euler(cs.newCamRot),cs.speed);
        //    }
        //}

        //RaycastHit2D hits2D = Physics2D.GetRayIntersection(ray);
        //if (hits2D.collider != null)
        //    Debug.Log("Hit 2D Collider" + hits2D.collider);
    }

    private void ChangeCursor(Texture2D cursorType)
    {
        //Vector2 hotspot = new Vector2(cursorType.width / 2, cursorType.height / 2);
        Cursor.SetCursor(cursorType,Vector2.zero,CursorMode.Auto);
    }




}
