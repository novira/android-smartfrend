using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;
public class poppeople {

	[Test]
	public IEnumerator popmovie() {
		string key = "aa9ba31a0fc74a076849181a5b323377";
		UnityWebRequest www = UnityWebRequest.Get("https://api.themoviedb.org/3/person/popular?api_key="+key+"&language=en-US&page=1");
		yield return www.Send();
		Assert.IsTrue (www.isDone);
	}
}
