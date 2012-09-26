using UnityEngine;
using System.Collections;

public class Log {
	
	private int mins, secs;
	private string message;
	private Log succ;
	
	public Log() {
		mins = secs = 0;
		message = "--";
	}
	
	public Log(int m, int s, string mess) {
		mins = m;
		secs = s;
		mess = message;
		succ = null;
	}
	
	private void Append(Log l) {
		succ = l;	
	}
	
	public Log NewEvent(int m, int s, string mess) {
	    Log res = new Log(m, s, mess);
		res.Append(this);
		return res;
	}
	
	public Tuple<int, int, string> GetEvent() {
		return new Tuple<int, int, string>(mins, secs, message);
	}
	
	public string GetEventAsString() {
		return mins + ":" + secs + " -- " + message;	
	}
	
	public string GetTime() {
		return mins + ":" + secs;
	}
	
	public string GetMessage() {
		return message;	
	}
	
	public IEnumerator GetAll() {
		yield return this;
		if (succ == null)
			yield break;
			yield return succ.GetAll();
	}
}

public partial class Static {
	public Log log;
	public static Log Log{
		get{
			return instance.log;
		}
	}
}