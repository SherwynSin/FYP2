﻿using UnityEngine;
using System.Collections;

public class TouchCamera : MonoBehaviour {

	void Start () {

		}
	void Update () {
		if (Input.GetMouseButton (0)) {// && !monsterSel) {
			Vector3 currPos = transform.position;
			Vector3 currMouseX = new Vector3 (Input.GetAxis ("Mouse X"), 0, Input.GetAxis ("Mouse X"));
			Vector3 currMouseY = new Vector3 (Input.GetAxis ("Mouse Y"), 0, -Input.GetAxis ("Mouse Y"));
			//Debug.Log(Input.GetAxis ("Mouse Y"));
			transform.position = currPos + currMouseX - currMouseY;
		}
		transform.position += new Vector3 (0 , Input.GetAxis ("Mouse ScrollWheel") , 0);
		//TO DO TOUCH VERSION
	}

}
