using UnityEngine;
using System.Collections;

public class MoveFlashcard : MonoBehaviour {

	public Texture[] cardsFront;
	public Texture[] cardsBack;
	public Renderer rend;
	int index = 0;
	bool lookingAtBack = false;
	Animator anim;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		anim = GetComponent<Animator> ();
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
					//rend.material.mainTexture = cardsBack[index];
					anim.SetBool ("IsFlipping", true);
					lookingAtBack = true;
					isPressed = true;
				}
			}
			else{
				if(Input.GetAxis("Horizontal") == 0){
					//rend.material.mainTexture = cardsFront[index];
					anim.SetBool ("IsFlipping", false);
					lookingAtBack = false;
					isPressed = false;
				}
			}
		}
		else if( Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0 ){
			isPressed = false;
		}
	}

	void MakeTextureChange() {
		if (anim.GetBool ("IsFlipping") == true) {
			rend.material.mainTexture = cardsBack [index];
		} else {
			rend.material.mainTexture = cardsFront[index];
		}
	}
}