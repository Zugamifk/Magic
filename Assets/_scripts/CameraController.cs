using UnityEngine;
using System.Collections;

public class CameraController : WorldObject {
	
	RaycastHit info;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public override void onCollision(RaycastHit hit) {
		Static.Wizard.Move(hit.point);
	}
}

public partial class Static {
	public CameraController cameraController;
	public static CameraController CameraController {
		get {return Instance.cameraController;}
	}
}