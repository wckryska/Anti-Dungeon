using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public bool isOpen;
    public Sprite floor;

	// Use this for initialization
	void Start () {
        isOpen = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isOpen)
        {
            Vector3 position = transform.position;
            Instantiate(floor, position, Quaternion.identity);
            Destroy(gameObject);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            GameObject tempPlayer = collision.gameObject;
            Player player = tempPlayer.GetComponent<Player>();
            if (player.keyCount > 0)
            {
                isOpen = true;
            }
        }
    }
}
