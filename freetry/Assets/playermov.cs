using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermov : MonoBehaviour {

    public int speed;
    public float animint;
    public Sprite[] sprites;
    public Sprite stop;
    public bool stopmoving;

    private Vector2 input;
    private float nextframe;
    private int index;
    private bool speed0;
    
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!stopmoving)
        {
            speed0 = true;
            input.x = Input.GetAxis("Horizontal");
            input.y = Input.GetAxis("Vertical");
        }
        else
        {
            if (speed0)
            {
                input.x = 0;
                input.y = 0;
                speed0 = false;
            }
        }


        if (input.x > 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
        }
        if (input.x < 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
        }

        if(Time.time > nextframe & input != new Vector2(0,0))
        {
            nextframe = Time.time + animint;
            GetComponent<SpriteRenderer>().sprite = sprites[index];
            index += 1;
            if(index >= sprites.Length)
            {
                index = 0;
            }
        }
        if(input == new Vector2(0, 0))
        {
            GetComponent<SpriteRenderer>().sprite = stop;
        }
    }


    void FixedUpdate()
    {

        GetComponent<Rigidbody2D>().velocity = input * speed;

    }
}
