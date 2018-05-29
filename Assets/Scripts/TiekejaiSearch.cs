using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TiekejaiSearch : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    
	}

    public void OnSearch()
    {
        string search = gameObject.GetComponent<InputField>().text;
    }
}
