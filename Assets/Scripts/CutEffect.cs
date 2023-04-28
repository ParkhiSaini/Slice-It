using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(TrailRenderer),typeof(BoxCollider))]
public class CutEffect : MonoBehaviour
{
    

    private GameManager gameManager;
    private Camera cam;
    private Vector3  mouse;
    private TrailRenderer trail;
    private BoxCollider boxCollider;
    private bool swipe =false;


    // Start is called before the first frame update
    void Awake()
    {
        cam=Camera.main;
        trail=GetComponent<TrailRenderer>();
        boxCollider=GetComponent<BoxCollider>();
        trail.enabled=false;
        boxCollider.enabled=false;
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGameActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                swipe=true;
                UpdateComponents();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                swipe=false;
                UpdateComponents();

            }
            if(swipe)
            {
                UpdateMousePosition();
            }
        }
        
    }

    void UpdateMousePosition()
    {
        mouse=cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x , Input.mousePosition.y,10.0f));
        transform.position=mouse;

    }

    void UpdateComponents()
    {
        trail.enabled=swipe;
        boxCollider.enabled=swipe;

    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.GetComponent<Target>())
        {
            collision.gameObject.GetComponent<Target>().DestroyTarget();

        }
        
    }
}
