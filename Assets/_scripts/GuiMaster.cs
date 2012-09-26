using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GuiMaster : MonoBehaviour{
	
	List<GUIObject> main;
	// Use this for initialization
	void Start () {
		main = new List<GUIObject>();
		main.Add(buildMainToolbar());
		main.Add(buildSpellbar());
	}
	
	// Update is called once per frame
	void OnGUI() {
		foreach(GUIObject o in main) {
			o.DrawElement();
		}
	}
	
	public GUIObject buildMainToolbar() {
		GUIObject res = new GUIObject("ToolBar", new Rect(Screen.width/2-150, 0, 300, 60), "SDAF");
		
		res.AddChild(new GUIObject(
			"MagickWindow",
			new Rect(30, 80, Screen.width-60, Screen.height-160),
			"SPELLS"));
		
		return res;
	}
	public GUIObject buildSpellbar() {
		GUIObject res = new GUIObject("SpellBar", new Rect(Screen.width/2-300, Screen.height-60, 600, 60), "dslkhsghj");
		return res;
	}
}

public class GUIObject {
	public string name;
	public Rect rect;
	public string text;
	public delegate void DrawLambda(GUIObject g);
	public event DrawLambda draw;
	public List<GUIObject> children;
	public GUIObject(){name = ""; rect = new Rect(0, 0, 0, 0); text = ""; children = new List<GUIObject>();}
	public GUIObject(string n, Rect r, string t, DrawLambda l = null) {
		name = n; rect = r; text = t; draw = l; children = new List<GUIObject>();
	}
	public void DrawElement() {
		if (draw == null) {
			GUI.Box(rect, text)	;
			DrawAllChildren();
		} else {
			draw(this);	
		}
	}
	public void DrawAllChildren() {
		GUI.BeginGroup(rect);
		foreach (GUIObject child in children) {
		//	GUI.BeginGroup(child.rect);
			child.draw(child);
		//	GUI.EndGroup();
		}
		GUI.EndGroup();
	}
	public List<GUIObject> GetChildren() {return children;}
	public void SetChildren(List<GUIObject> list) {children = list;}
	public void AddChild(GUIObject child) {children.Add(child);}
	public void SetDrawAction(DrawLambda d) {draw = d;}
}

public partial class Static {
	public GuiMaster guiMaster;
	public static GuiMaster GuiMaster {
		get {return Instance.guiMaster;}
	}
}