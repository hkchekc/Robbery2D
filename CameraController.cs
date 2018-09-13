using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public float maxFov = 15f;
	public float minFov = 90f;
	public float sensitivity = 10f;
	public static Vector3 offset;
	public static float cameraSpeed = -1.5f;


	void Start () 
	{
		offset = transform.position - player.transform.position;
	}
	

	void LateUpdate () 
	{
		transform.position = player.transform.position + offset;
		float fov = Camera.main.fieldOfView;
		#if UNITY_EDITOR || UNITY_STANDALONE
		fov += Input.GetAxis ("Mouse Scrollwheel") * sensitivity;

		#elif 
		#endif
		fov = Mathf.Clamp (fov, minFov, maxFov);
		Camera.main.fieldOfView = fov;
	}

}
