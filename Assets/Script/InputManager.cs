using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
  
    [SerializeField]
    private float mTime = 0.3f;
    private bool moving = false;
    private Vector2 moveDir = Vector2.right;
    public AudioSource walkingEffect;



    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame



    public bool Heading(Vector3 moveDir)
    {
        if (moving)
        {
            return false;
        }
        StartCoroutine(GridMove(transform.position + moveDir));
        return true;
    }
    private IEnumerator GridMove(Vector2 endPos)
    {
        Vector2 StartPos = transform.position;
        float percent = 0;
        moving = true;
        while (percent < mTime)
        {
            percent += Time.deltaTime;
            transform.position = Vector2.Lerp(StartPos, endPos, percent / mTime);
          
            yield return null;


        }
        moving = false;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveDir = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveDir = Vector2.down;

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            moveDir = Vector2.right;

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            moveDir = Vector2.left;

        }
        if (Input.anyKeyDown)
        {

            Heading(moveDir);
            walkingEffect.Play();
        }

    }
}
