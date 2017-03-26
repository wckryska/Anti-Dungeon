using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenWall : MonoBehaviour {

    public bool isPunched;
    public Sprite floor;

	// Use this for initialization
	void Start () {
        isPunched = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (isPunched)
        {
            Vector3 position = transform.position;
            Instantiate(floor, position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            GameObject tempPlayer = collision.gameObject;
            Player player = tempPlayer.GetComponent<Player>();
            if (player.isAttacking)
            {
                //determine whether the direction of collision is the same as the player's direction of mvmt
                Vector3 unitVec = Vector3.Normalize(new Vector3(collision.transform.position.x - transform.position.x, collision.transform.position.y - transform.position.y, 0));



                switch (player.facing)
                {
                    case (Direction.North):
                        if (Mathf.Abs(unitVec.y) > Mathf.Abs(unitVec.x) && unitVec.y < 0)
                        {
                            isPunched = true;
                        }
                        break;
                    case (Direction.South):
                        if (Mathf.Abs(unitVec.y) > Mathf.Abs(unitVec.x) && unitVec.y > 0)
                        {
                            isPunched = true;
                        }
                        break;
                    case (Direction.East):
                        if (Mathf.Abs(unitVec.x) > Mathf.Abs(unitVec.y) && unitVec.x < 0)
                        {
                            isPunched = true;
                        }
                        break;
                    case (Direction.West):
                        if (Mathf.Abs(unitVec.x) > Mathf.Abs(unitVec.y) && unitVec.x > 0)
                        {
                            isPunched = true;
                        }
                        break;
                }
            }
        }
    }
}
