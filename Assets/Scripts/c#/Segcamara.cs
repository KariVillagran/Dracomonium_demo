using UnityEngine;
using System.Collections;

public class Segcamara : MonoBehaviour {

	
	public Transform target;
	public float distance = 20.0f;
	public float zoomSpd = 2.0f;
	
	public float xSpeed = 240.0f;
	public float ySpeed = 123.0f;
	
	public int yMinLimit = -723;
	public int yMaxLimit = 877;
	
	private float x = 22.0f;
	private float y = 33.0f;
	
	public void Start () {
		
		x = 22f;
		y = 33f;
		
		// Make the rigid body not change rotation
		if (rigidbody)
			rigidbody.freezeRotation = true;
	}
	
	public void LateUpdate () {
		if (target) {
			x -= Input.GetAxis("Horizontal") * xSpeed * 0.02f;
			y += Input.GetAxis("Vertical") * ySpeed * 0.02f;
			
			
			distance -= Input.GetAxis("Fire1") *zoomSpd* 0.02f;
			distance += Input.GetAxis("Fire2") *zoomSpd* 0.02f;
			
			Vector3 position =  new Vector3(0.0f, 0.0f, -distance) + target.position;
			Debug.Log(position.y);
			if (position.y < 1.5 && position.y > -1.5  ) {
				transform.position = position;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
