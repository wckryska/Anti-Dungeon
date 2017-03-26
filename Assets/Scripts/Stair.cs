using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair : MonoBehaviour {

    public GameObject pairedStair;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            other.transform.position = new Vector3(pairedStair.transform.position.x + 1.25f, pairedStair.transform.position.y, pairedStair.transform.position.z);
            GameObject player = other.gameObject;
            Player playerTemp = player.GetComponent<Player>();
            playerTemp.attackTime = Time.time;
            playerTemp.isAttacking = true;
        }
    }
}
