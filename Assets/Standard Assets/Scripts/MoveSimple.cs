using UnityEngine;
using System.Collections;

public class MoveSimple : MonoBehaviour {

	public float speed = 3.0f;
	public float rotateSpeed = 10.0f;

	private bool isTouchDevice = false;

	// Use this for initialization
	void Start () {
	
	}

	void Awake() {
		if (Application.platform == RuntimePlatform.IPhonePlayer) {
						isTouchDevice = true;
		} else if (Application.platform == RuntimePlatform.Android) {
			isTouchDevice = true;
		}
	}
	
	// Update is called once per frame
	void Update () {

		bool clickDetected = false;
		Vector3 touchPosition;

		// Detect click and calculate touch position
		if (isTouchDevice) {
			clickDetected = (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began);
			touchPosition = Input.GetTouch(0).position;
		} else {
			clickDetected = (Input.GetMouseButtonDown(0));
			touchPosition = Input.mousePosition;
		}
		// Detect clicks
		if ( clickDetected ) {
			// Check if the GameObject is clicked by casting a
			// Ray from the main camera to the touched position
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();
			// Cast a ray of distance 100, and check if this
			// collider is hit
			if ( collider.Raycast(ray, out hit, 100.0f) ) {
				// Log a debug message
				Debug.Log ( "Moving the target" );
				// Move the target forward
				transform.Translate (Vector3.forward * speed);
				// Rotate the target along the y-axis
				transform.Rotate(Vector3.up * rotateSpeed);
			} else {
				// Clear the debug message
				Debug.Log ("");
			}
		}
	}
}