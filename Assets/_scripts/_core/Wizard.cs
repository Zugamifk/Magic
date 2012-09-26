using UnityEngine;
using System.Collections;

public class Wizard : WorldObject {
	
	Vector3 destinationUnit;
	float destinationDistance;
	public float speed = 30.0f;
	
	enum states {
		IDLE,
		MOVING
	};
	states state;
	
	// Use this for initialization
	void Start () {
		state = states.IDLE;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (state==states.MOVING) {
			float dis = Mathf.Min(speed*Time.fixedDeltaTime, destinationDistance);
			Vector3 step = new Vector3(
					destinationUnit.x*dis,
					0,
					destinationUnit.z*dis
				);
			transform.Translate(step);
			destinationDistance -= dis;
		}
	}
	
	public void Move(Vector3 to) {
		Vector3 click = new Vector3(to.x - transform.position.x, transform.position.y, to.z - transform.position.z);
		destinationUnit = click.normalized;
		destinationDistance = click.magnitude;
		state = states.MOVING;
	}
	
}

public partial class Static {
	public Wizard wizard;
	public static Wizard Wizard {
		get {return Instance.wizard;}
	}
}