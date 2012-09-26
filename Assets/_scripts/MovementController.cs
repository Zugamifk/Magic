using UnityEngine;
using System.Collections;

public class MovementController : WorldObject {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override void onCollision(RaycastHit hit) {
		
	}
}

public partial class Static {
	public MovementController movementcontrol;
	public static MovementController MovemesController {
		get {return Instance.movementcontrol;}
	}
}