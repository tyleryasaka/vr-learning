using UnityEngine;
using System.Collections;

public class MoveFlashcard : MonoBehaviour {

	public Texture[] cardsFront;
	public Texture[] cardsBack;
	public Renderer rend;
	int index = 0;
	bool lookingAtBack = false;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	bool isPressed = false;
	void Update () {
		if(!isPressed){
			if(!lookingAtBack){
				if(Input.GetAxis("Vertical") > 0){
					index = (index + 1) % cardsFront.Length;
					rend.material.mainTexture = cardsFront[index];
					isPressed = true;
				}
				else if(Input.GetAxis("Vertical") < 0){
					index = (index + cardsFront.Length - 1) % cardsFront.Length;
					rend.material.mainTexture = cardsFront[index];
					isPressed = true;
				}
				else if(Input.GetAxis("Horizontal") < 0){
					rend.material.mainTexture = cardsBack[index];
					lookingAtBack = true;
					isPressed = true;
				}
			}
			else{
				if(Input.GetAxis("Horizontal") == 0){
					rend.material.mainTexture = cardsFront[index];
					lookingAtBack = false;
					isPressed = false;
				}
			}
		}
		else if( Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0 ){
			isPressed = false;
		}
	}
}