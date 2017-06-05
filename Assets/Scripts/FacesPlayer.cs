using UnityEngine;
using System.Collections;

public class FacesPlayer : MonoBehaviour {

	public float rotSpeed = 90f;

	Transform player;

	void Update () {
		if(player == null) {
			// This finds a gameobject with the specified tag
			GameObject go = GameObject.FindWithTag ("Player");

			if(go != null) {
				player = go.transform;
			}
		}

		// If there isn't a gameobject with the specified tag, try again next frame
		if(player == null)
			return;

		
        // If there is a gameobject with the tag, find the direction that player is in
		Vector3 dir = player.position - transform.position;
		dir.Normalize();

        // Too much math. There has to be better way to do this bit
		float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

		Quaternion desiredRot = Quaternion.Euler( 0, 0,zAngle );

		transform.rotation = Quaternion.RotateTowards( transform.rotation, desiredRot, rotSpeed * Time.deltaTime);

	}
}
