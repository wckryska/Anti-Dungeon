using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private GameObject player;
    public int health;
    public float speed;
    public Sprite[] walkNorth;
    public Sprite[] walkSouth;
    public Sprite[] walkWest;
    public Sprite[] walkEast;


    private int animationFrame = 0;
    private float changeTime;
    private int animationTracker = 0;

    public Direction facing;


    // Use this for initialization
    void Start () {
        health = 2;
        changeTime = Time.time;
        player = GameObject.Find("Player");
        facing = Direction.South;
	}
	
    
	// Update is called once per frame
	void Update () {
        if(Mathf.Abs(Vector3.Distance(transform.position, player.transform.position)) > 5.0f)
        {
            if (Time.time - changeTime > 2.0f)
            {
                float xdirection = Random.Range(-0.5f, 1);
                float ydirection = Random.Range(-0.5f, 1);
                Vector3 move = new Vector3(xdirection, ydirection, 0);
                if(Mathf.Abs(xdirection) > Mathf.Abs(ydirection))
                {
                    if(xdirection > 0)
                    {
                        facing = Direction.East;
                    }
                    else
                    {
                        facing = Direction.West;
                    }
                }
                if (Mathf.Abs(xdirection) < Mathf.Abs(ydirection))
                {
                    if (ydirection > 0)
                    {
                        facing = Direction.North;
                    }
                    else
                    {
                        facing = Direction.South;
                    }
                }
                transform.position += move * speed * Time.deltaTime;
            }
        }
        else
        {
            Vector3 move = player.transform.position - transform.position;
            if (Mathf.Abs(move.x) > Mathf.Abs(move.y))
            {
                if (move.x > 0)
                {
                    facing = Direction.East;
                }
                else
                {
                    facing = Direction.West;
                }
            }
            if (Mathf.Abs(move.x) < Mathf.Abs(move.y))
            {
                if (move.y > 0)
                {
                    facing = Direction.North;
                }
                else
                {
                    facing = Direction.South;
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }

        switch (facing)
        {
            case Direction.North:
                this.transform.GetComponent<SpriteRenderer>().sprite = walkNorth[animationFrame];
                break;

            case Direction.South:
                this.transform.GetComponent<SpriteRenderer>().sprite = walkSouth[animationFrame];
                break;

            case Direction.East:
                this.transform.GetComponent<SpriteRenderer>().sprite = walkEast[animationFrame];
                break;

            case Direction.West:
                this.transform.GetComponent<SpriteRenderer>().sprite = walkWest[animationFrame];
                break;
            default:
                break;
        }
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        if(animationTracker < 10)
        {
            animationTracker++;
        }
        else
        {
            animationTracker = 0;
            if(animationFrame == 1)
            {
                animationFrame = 0;
            }
            else if (animationFrame == 0)
            {
                animationFrame = 1;
            }
        }

        
	}
}
