using UnityEngine;
using System.Collections;

public class RotationFixforNote : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.down * 1.6f * Time.deltaTime);
	}
}
