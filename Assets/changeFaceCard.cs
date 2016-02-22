using UnityEngine;
using System.Collections;

public class changeFaceCard : MonoBehaviour {
	public GameObject n;

	// Use this for initialization
	void Start () {
		n = GameObject.FindGameObjectWithTag("Flashcard");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void changeCardFace()
	{
		n.GetComponent<MoveFlashcard> ().changeCards ();
	}
}
