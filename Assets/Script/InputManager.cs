using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
  
    [SerializeField]
    private float moveTime = 0.3f;
    private bool isMove = false;
    private Vector2 moveDirection = Vector2.right;
    public AudioSource walkingEffect;



    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame



    public bool MoveTo(Vector3 moveDir)
    {
        if (isMove)
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
        isMove = true;
        while (percent < moveTime)
        {
            percent += Time.deltaTime;
            transform.position = Vector2.Lerp(StartPos, endPos, percent / moveTime);
          
            yield return null;


        }
        isMove = false;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveDirection = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveDirection = Vector2.down;

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            moveDirection = Vector2.right;

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            moveDirection = Vector2.left;

        }
        if (Input.anyKeyDown)
        {

            MoveTo(moveDirection);
            walkingEffect.Play();
        }

    }
}
