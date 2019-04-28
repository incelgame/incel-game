using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorteleport : MonoBehaviour {

    public float x;
    public float y;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag== "Player")
        {
            collision.gameObject.transform.position = new Vector3(x, y, transform.position.z);
        }
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
