using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    public Vector2 movement;
    public float animint;
    public Sprite[] sprites;
    public Sprite stop;

    private float nextframe;
    private int index;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        movement = GetComponent<Rigidbody2D>().velocity;

        if (movement.x > 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
        }
        if (movement.x < 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
        }

        if (Time.time > nextframe & movement != new Vector2(0, 0))
        {
            nextframe = Time.time + animint;
            GetComponent<SpriteRenderer>().sprite = sprites[index];
            index += 1;
            if (index >= sprites.Length)
            {
                index = 0;
            }
        }
        if (movement == new Vector2(0, 0))
        {
            GetComponent<SpriteRenderer>().sprite = stop;
        }

    }
}
