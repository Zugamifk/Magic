using UnityEngine;
using System.Collections.Generic;

public class Fizzixer : MonoBehaviour {
	
	private Queue<Tuple<WorldObject, Ray>> rays;
	
	// Use this for initialization
	void Start () {
		rays = new Queue<Tuple<WorldObject, Ray>>();
	}
	
	// Update is called once per frame
	void Update () {
		CalcRays();
	}
	
	public void AddRay(Tuple<WorldObject, Ray> ray) {
		rays.Enqueue(ray);	
	}
	
	public void CalcRays(int n = 1) {
		int c = rays.Count;
		if (c == 0) return;
		if (n > c) n = c;
		while(n-->0) {
			Tuple<WorldObject, Ray> o = rays.Dequeue();
			RaycastHit hit;
			if (Physics.Raycast(o.Item2, out hit)) {
				o.Item1.onCollision(hit);
			}
		}
	}
}

public partial class Static {
	public Fizzixer fizzixer;
	public static Fizzixer Fizzixer {
		get {return Instance.fizzixer;}
	}
}	