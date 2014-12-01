

#pragma strict
using UnityEngine;
using System.Collections;

public class moveCamera: MonoBehaviour{
	float ScrollSpeed = 1.0f;
	bool LockHorizontalScroll = false;
	bool LockVerticalScroll = false;

	float PinchZoomSpeed = 0.3f;
	bool LockPinchZoom = false;

	float ZoomInMax = 2.0f;
	float ZoomOutMax  = 5.0f;

	private Camera _camera;
	private Vector3 CameraPos;
	private float PinchDistance;
	private float PreviousPinchDistance;

	void Start()
	{
		_camera = this.camera;
	}

	void Update()
	{
		if (_camera.active == true)
		{
			if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
			{
				CameraPos = _camera.transform.position;
			
				if (!LockHorizontalScroll)
					CameraPos.x -= Input.GetTouch(0).deltaPosition.x * Time.deltaTime * ScrollSpeed;
				
				if (!LockVerticalScroll)
					CameraPos.y -= Input.GetTouch(0).deltaPosition.y * Time.deltaTime * ScrollSpeed;
			
				_camera.transform.position = CameraPos;
			}
			else if (!LockPinchZoom)
			{
				if (Input.touchCount == 2 &&
			  	  (Input.GetTouch(0).phase == TouchPhase.Began ||
				 Input.GetTouch(1).phase == TouchPhase.Began))
				{
					PreviousPinchDistance = Vector2.Distance (Input.GetTouch(0).position,
					                                          Input.GetTouch(1).position);
				} else if (Input.touchCount == 2 &&
			    	       (Input.GetTouch(0).phase == TouchPhase.Moved ||
				 Input.GetTouch(1).phase == TouchPhase.Moved) )
				{
					PinchDistance = Vector2.Distance (Input.GetTouch(0).position,
					                                  Input.GetTouch(1).position);
					_camera.orthographicSize += (PreviousPinchDistance - PinchDistance) *
						(Time.deltaTime * PinchZoomSpeed);
				
					if (_camera.orthographicSize < ZoomInMax)
						_camera.orthographicSize = ZoomInMax;
					else if (_camera.orthographicSize > ZoomOutMax)
						_camera.orthographicSize = ZoomOutMax;
				
					PreviousPinchDistance = PinchDistance;
				}
			}
		}
	}
}


