using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderVis : MonoBehaviour {

    private bool mIsVisible = false;

    public bool IsVisible
    {
        get { return mIsVisible; }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnBecameVisible()
    {
        mIsVisible = true;
    }

    void OnBecameInvisible()
    {
        mIsVisible = false;
    }
}
