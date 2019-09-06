using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;
public class upcoming {

	[Test]
	public IEnumerator up() {
		string key = "aa9ba31a0fc74a076849181a5b323377";
		UnityWebRequest www = UnityWebRequest.Get("https://api.themoviedb.org/3/movie/upcoming?api_key="+key+"&language=en-US&page=1");
		yield return www.Send();
		Assert.IsTrue (www.isDone);
	}
}
