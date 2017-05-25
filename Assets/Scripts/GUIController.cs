using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {
    public GameObject MainCamera;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(MainCamera.transform.position);
	}
}
