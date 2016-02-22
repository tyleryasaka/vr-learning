using UnityEngine;
using System.Collections;

public class MoveFlashcard : MonoBehaviour {

	public Texture[] cardsFront;
	public Texture[] cardsBack;
	public Texture[] sampleFront;
	public Texture[] sampleBack;
    public Animator anim;
	public Animator transition;
	public Renderer rend;
	int index = 0;
	bool lookingAtBack = false;
	bool tutorialMode = true;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
        anim = GetComponent<Animator>();
		transition = GameObject.Find ("TransitionCard").GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	bool isPressed = false;
	void Update () {
		// tutorial
		if (Input.GetAxis ("Horizontal") > 0 && tutorialMode == true) {
			tutorialMode = false;
			index = 0;
			rend.material.mainTexture = cardsFront [index];
		}

		if(!isPressed){
			if(!lookingAtBack){
				if(Input.GetAxis("Vertical") > 0){
					// fade texture
					transition.SetTrigger("OnCardChange");
					if (tutorialMode) {
						index = (index + 1) % sampleFront.Length;
						//rend.material.mainTexture = sampleFront[index];
					} else {
						index = (index + 1) % cardsFront.Length;
						//rend.material.mainTexture = cardsFront[index];
					}
					isPressed = true;
				}
				else if(Input.GetAxis("Vertical") < 0){
					// fade texture
					transition.SetTrigger("OnCardChange");
					if (tutorialMode) {
						index = (index + sampleFront.Length - 1) % sampleFront.Length;
						//rend.material.mainTexture = sampleFront[index];
					} else {
						index = (index + cardsFront.Length - 1) % cardsFront.Length;
						//rend.material.mainTexture = cardsFront[index];
					}
					isPressed = true;
				}
				else if(Input.GetAxis("Horizontal") < 0){
                    //rend.material.mainTexture = cardsBack[index];
                    anim.SetTrigger("KeyPressed");
					lookingAtBack = true;
					isPressed = true;
				}
			}
			else{
				if(Input.GetAxis("Horizontal") == 0){
                    //rend.material.mainTexture = cardsFront[index];
                    anim.SetTrigger("KeyPressed");
					lookingAtBack = false;
					isPressed = false;
				}
			}
		}
		else if( Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0 ){
			isPressed = false;
		}
	}

	// change to the card's back texture
    void changeTextures()
    {
        if (lookingAtBack == false)
        {
			if (tutorialMode)
				rend.material.mainTexture = sampleFront [index];
            else rend.material.mainTexture = cardsFront[index];
        }
        else
        {
			if (tutorialMode)
				rend.material.mainTexture = sampleBack [index];
            else rend.material.mainTexture = cardsBack[index];
        }
    }

	// change the texture on the face of the card
	public void changeCards()
	{
		if (tutorialMode) {
			rend.material.mainTexture = sampleFront [index];
		} else {
			rend.material.mainTexture = cardsFront [index];
		}
	}
}