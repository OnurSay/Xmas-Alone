/*
Notes.cs - wirted by ThunderWire Games * Script for Show Notes
*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Notes : MonoBehaviour {

public GameObject UI;
public GameObject NotesUIImage;
public GameObject FPSScript;
public Sprite NotesTexture;

private bool showNote;
private bool backNote;

	void Start(){
		showNote = false;
		Cursor.visible = (false);
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	void FixedUpdate () {
		Image NoteImage = NotesUIImage.GetComponent<Image>();
		CrosshairGUI Crosshair = Camera.main.GetComponent<CrosshairGUI>();
		FirstPersonController FPSComp = FPSScript.GetComponent<FirstPersonController>();
		
		if(showNote){
			NoteImage.enabled = true;
			Crosshair.enabled = false;
			UI.SetActive(true);
			this.GetComponent<Renderer>().enabled = false;
		    this.GetComponent<Collider>().enabled = false;
			FPSComp.enabled = false;
		}
		
		if(backNote){
			NoteImage.enabled = false;
			Crosshair.enabled = true;
			UI.SetActive(false);
			Crosshair.m_DefaultReticle = true;
			Crosshair.m_UseReticle = false;
			FPSComp.enabled = true;
			Remove();
		}
	}

	public void ShowNotes () {
		Image NoteImage = NotesUIImage.GetComponent<Image>();
		NoteImage.sprite = NotesTexture;
		showNote = true;
		backNote = false;
		Cursor.visible = (true);
		Cursor.lockState = CursorLockMode.None;
	}
	
	public void BackNotes () {
		showNote = false;
		backNote = true;
		Cursor.visible = (false);
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	void Remove () {
		Destroy(this);
	}
}