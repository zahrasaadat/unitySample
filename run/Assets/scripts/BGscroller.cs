using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGscroller : MonoBehaviour {

    private MeshRenderer mesh;
    private float speed = 0.1f;
    float x;
    public bool canScroll=false;
    void Start () {
        mesh = GetComponent<MeshRenderer>();
        
	}
	
	void Update () {
        if (canScroll)
        {
            x = Mathf.Repeat(Time.time * speed, 0.52f);
            mesh.material.mainTextureOffset = new Vector2(x, 0);
        }
	}
}
