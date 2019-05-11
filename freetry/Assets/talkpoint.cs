using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class talkpoint : MonoBehaviour {

    public string[] alltext;
    public Sprite[] allimag;
    public Sprite incel;
    public Sprite itcel;

    public GameObject panel;
    public Text text;
    public Image imag;

    public bool ispoint;
    
    private bool start;
    public int index;
    private GameObject player;
    private AudioSource aud;


    private void OnTriggerStay2D(Collider2D collision)
    {
        player = collision.gameObject;
        panel.SetActive(true);
        collision.gameObject.GetComponent<playermov>().stopmoving = true;

        start = true;
    }

    // Use this for initialization
    void Start () {
        aud = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (start)
        {

            imag.sprite = allimag[index];
            text.text = alltext[index];

            if (Input.GetButtonDown("Fire1"))
            {
                index += 1;
                aud.Play();
            }
            
            if(index > alltext.Length-1)
            {

                index = 0;
                start = false;
                panel.SetActive(false);
                player.GetComponent<playermov>().stopmoving = false;
                if (ispoint)
                {
                    player.transform.GetChild(0).GetChild(0).gameObject.GetComponent<gamecontrol>().chapters[index].SetActive(false);
                    player.transform.GetChild(0).GetChild(0).gameObject.GetComponent<gamecontrol>().index += 1;

                }
                gameObject.SetActive(false);

            }

        }

	}
}
