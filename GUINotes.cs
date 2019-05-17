/*
GUINotes.cs - wirted by ThunderWire Games * Script for Interact Notes
*/

using UnityEngine;
using System.Collections;
using UnityEngine.PostProcessing;

public class GUINotes : MonoBehaviour {

public float PickupRange = 3f;

private bool pressedButton = false;
private bool backNotes = false;

private Ray playerAim;
private Camera playerCam;
private GameObject NoteObject;

	void FixedUpdate () {
		if(Input.GetButtonDown("Fire1") && !pressedButton){
			pressedButton = true;
		}
	}
	
	void Update () {
		playerCam = Camera.main;
		Ray playerAim = playerCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		RaycastHit hit;

		if (Physics.Raycast (playerAim, out hit, PickupRange)){
			if (hit.collider.tag == "Interact"){
				NoteObject = hit.collider.gameObject;
				if(pressedButton){
					NoteObject.GetComponent<Notes>().ShowNotes();
					this.GetComponent<PostProcessingBehaviour>().enabled = true;
					backNotes = false;
					pressedButton = false;
				}
			}
		}
		if(backNotes){
			NoteObject.GetComponent<Notes>().BackNotes();
            this.GetComponent<PostProcessingBehaviour>().enabled = false;
            backNotes = false;
			pressedButton = false;
		}
    }
	
	public void Back() {
		backNotes = true;
	}
}