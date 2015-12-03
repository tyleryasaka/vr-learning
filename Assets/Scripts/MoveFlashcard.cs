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
	void Update () {
		if(!lookingAtBack){
			if(Input.GetKeyDown ("left")){
				index = (index + 1) % cardsFront.Length;
				rend.material.mainTexture = cardsFront[index];
			}
			else if(Input.GetKeyDown ("right")){
				index = (index + cardsFront.Length - 1) % cardsFront.Length;
				rend.material.mainTexture = cardsFront[index];
			}
			else if(Input.GetKeyDown ("up")){
				rend.material.mainTexture = cardsBack[index];
				lookingAtBack = true;
			}
		}
		else{
			if(Input.GetKeyUp ("up")){
				rend.material.mainTexture = cardsFront[index];
				lookingAtBack = false;
			}
		}
	}
}

/*
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;

    private Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
    }
}
*/
