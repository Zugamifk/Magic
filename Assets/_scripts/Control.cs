using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

public partial class Static {
	public Control control;
	public static Control Control {
		get {return Instance.control;}
	}
}