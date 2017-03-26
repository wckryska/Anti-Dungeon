using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    North,
    South,
    East,
    West
};

public class Player : MonoBehaviour {

    public Sprite[] walkingNorth;
    public Sprite[] walkingSouth;
    public Sprite[] walkingEast;
    public Sprite[] walkingWest;
    public Sprite[] attack;

    public float speed = 100f;

    private Direction facing;

    private bool isWalking;
    private bool isAttacking;



    private float attackTime;
    private float currTime;
    private float walkingTime = 0;
    private int animationTracker = 0;
    private int animationState = 0;

    // Use this for initialization
    void Start () {
        isWalking = false;
        isAttacking = false;
        facing = Direction.South;
        speed = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKey(KeyCode.LeftArrow) && !isAttacking)
        {
            if (!isWalking)
            {
                
                isWalking = true;
            }
            if(animationTracker < 13)
            {
                animationTracker++;
            }
            if (animationTracker == 13)
            {
                animationTracker = 0;
                if(animationState == 0)
                {
                    animationState = 1;
                }
                else
                {
                    animationState = 0;
                }
            }
            this.transform.GetComponent<SpriteRenderer>().sprite = walkingWest[animationState];
            facing = Direction.West;
        }
        if (Input.GetKey(KeyCode.RightArrow) && !isAttacking)
        {
            if (!isWalking)
            {

                isWalking = true;
            }
            if (animationTracker < 13)
            {
                animationTracker++;
            }
            if (animationTracker == 13)
            {
                animationTracker = 0;
                if (animationState == 0)
                {
                    animationState = 1;
                }
                else
                {
                    animationState = 0;
                }
            }
            this.transform.GetComponent<SpriteRenderer>().sprite = walkingEast[animationState];
            facing = Direction.East;
        }
        if (Input.GetKey(KeyCode.UpArrow) && !isAttacking)
        {
            if (!isWalking)
            {

                isWalking = true;
            }
            if (animationTracker < 13)
            {
                animationTracker++;
            }
            if (animationTracker == 13)
            {
                animationTracker = 0;
                if (animationState == 0)
                {
                    animationState = 1;
                }
                else
                {
                    animationState = 0;
                }
            }
            this.transform.GetComponent<SpriteRenderer>().sprite = walkingNorth[animationState];
            facing = Direction.North;
        }
        if (Input.GetKey(KeyCode.DownArrow) && !isAttacking)
        {
            if (!isWalking)
            {

                isWalking = true;
            }
            if (animationTracker < 13)
            {
                animationTracker++;
            }
            if (animationTracker == 13)
            {
                animationTracker = 0;
                if (animationState == 0)
                {
                    animationState = 1;
                }
                else
                {
                    animationState = 0;
                }
            }
            this.transform.GetComponent<SpriteRenderer>().sprite = walkingSouth[animationState];
            facing = Direction.South;
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            isWalking = false;
        }

        if(isAttacking && Time.time - attackTime > 0.3f)
        {
            isAttacking = false;
            switch (facing)
            {
                case Direction.North:
                    this.transform.GetComponent<SpriteRenderer>().sprite = walkingNorth[0];
                    break;

                case Direction.South:
                    this.transform.GetComponent<SpriteRenderer>().sprite = walkingSouth[0];
                    break;

                case Direction.East:
                    this.transform.GetComponent<SpriteRenderer>().sprite = walkingEast[0];
                    break;

                case Direction.West:
                    this.transform.GetComponent<SpriteRenderer>().sprite = walkingWest[0];
                    break;
                default:
                    break;
            }
        }
        if (!isAttacking)
        {
            
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            transform.position += move * speed * Time.deltaTime;
        }



        if (Input.GetKeyDown(KeyCode.Z) && !isAttacking)
        {
            isAttacking = true;
            attackTime = Time.time;
            switch (facing)
            {
                case Direction.North:
                    this.transform.GetComponent<SpriteRenderer>().sprite = attack[0];
                    break;

                case Direction.South:
                    this.transform.GetComponent<SpriteRenderer>().sprite = attack[1];
                    break;

                case Direction.East:
                    this.transform.GetComponent<SpriteRenderer>().sprite = attack[2];
                    break;

                case Direction.West:
                    this.transform.GetComponent<SpriteRenderer>().sprite = attack[3];
                    break;
                default:
                    break;

            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.gameObject.tag == "Enemy")
        {
            
        }
    }


}
