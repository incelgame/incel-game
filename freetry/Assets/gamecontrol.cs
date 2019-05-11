using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamecontrol : MonoBehaviour {


    public GameObject[] chapters;
    public GameObject[] startchp;

    public int index;

	// Use this for initialization
	void Start () {
        foreach (GameObject g in chapters)
        {
            g.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {

        chapters[index].SetActive(true);

	}
}
