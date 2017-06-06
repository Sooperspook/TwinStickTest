using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform myTarget;
	
	// Go back to the tutorial and write down why this is done.
	void Update () {
		if(myTarget != null) {
			Vector3 targPos = myTarget.position;
			targPos.z = transform.position.z;

			transform.position = targPos;
		}
	}
}
