using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmacController : MonoBehaviour
{

    private Vector2 Heading = Vector2.right;
    private InputManager inputManager;
    public AudioSource walkingEffect;
    private LayerMask mapLay;
    private float rayDis = 0.55f;
    // Start is called before the first frame update
    void Awake()
    {

        inputManager = GetComponent<InputManager>();
        mapLay = 1 << LayerMask.NameToLayer("Map");
    
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Heading= Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Heading = Vector2.down;

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            Heading = Vector2.right;

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            Heading = Vector2.left;

        }
        /*RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDis, mapLay);
        if (hit.transform == null)
        { 
          */  
        }
       


    }
        
    
