using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animmov : MonoBehaviour {

    public GameObject npc;
    public int indexmove;
    public Vector3[] nextpos;

    private Vector2 velocity;
    private bool starts;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(indexmove == gameObject.GetComponent<talkpoint>().index & npc.transform.position != new Vector3(nextpos[0].x, nextpos[0].y, npc.transform.position.z))
        {
            velocity = new Vector3(nextpos[0].x, nextpos[0].y, npc.transform.position.z) - npc.transform.position;
            Debug.DrawLine(npc.transform.position, new Vector3(nextpos[0].x, nextpos[0].y, npc.transform.position.z));
            velocity = velocity.normalized;
            velocity = velocity * nextpos[0].z;
            npc.GetComponent<Rigidbody2D>().velocity = velocity;
            starts = true;
        }
        if (starts)
        {
            if ((npc.transform.position - new Vector3(nextpos[0].x, nextpos[0].y, npc.transform.position.z)).magnitude < 0.1 & indexmove == gameObject.GetComponent<talkpoint>().index)
            {
                npc.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                starts = false;
            }
            if (npc.transform.position != new Vector3(nextpos[0].x, nextpos[0].y, npc.transform.position.z) & indexmove < gameObject.GetComponent<talkpoint>().index)
            {
                npc.transform.position = new Vector3(nextpos[0].x, nextpos[0].y, npc.transform.position.z);
                npc.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                starts = false;
            }
        }

	}
}
