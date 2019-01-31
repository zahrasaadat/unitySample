using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moonscroller : MonoBehaviour {

    private Renderer rend = new Renderer();
    public float moonSpeed = 0.1f;
    float x;
    public bool grndCanScroll=false;
	void Start () {
        rend = GetComponent<Renderer>();	
	}
	
	// Update is called once per frame
	void Update () {
        if (grndCanScroll)
        {
            x = Mathf.Repeat(Time.time * moonSpeed, 0.52f);
            rend.material.mainTextureOffset = new Vector2(x, 0);
        }
    }
}
