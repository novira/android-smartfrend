using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;

public class menu : MonoBehaviour {
	string key = "aa9ba31a0fc74a076849181a5b323377";
	public GameObject p1,p2,p3,p4,p5;
	public GameObject u1,u2,u3;
	public Texture2D tex,tex1,tex2,tex3,tex4;
	public Texture2D texu,texu1,texu2,texu3,texu4;
	public Button detpn,detu,poppeo,tm;
	public GameObject pn,um,popp,trm,ini;

	// Use this for initialization
	void Start () {
		StartCoroutine (getplaymovie1 ());
		StartCoroutine (upmov ());
		detpn.onClick.AddListener (() => detailspn());
		detu.onClick.AddListener (() => detailsum());
		poppeo.onClick.AddListener (() => peo());
		tm.onClick.AddListener (() => trmn());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator getplaymovie1() {
		UnityWebRequest www = UnityWebRequest.Get("https://api.themoviedb.org/3/movie/now_playing?api_key="+key+"&language=en-US&page=1");
		yield return www.Send();
		if(www.isError) {
			//pesan.text ="ip localhost:8085" + www.error;
			Debug.Log("ip 10.205.6.138:8085" + www.error);
		}
		else {
			string hasil = www.downloadHandler.text;
			JObject json = JObject.Parse(hasil);
			//Debug.Log(json.GetValue("Status"));
			Newtonsoft.Json.Linq.JArray cb =(Newtonsoft.Json.Linq.JArray)json["results"];
			var result0 = (JObject)cb[0];
			var result1 = (JObject)cb[1];
			var result2 = (JObject)cb[2];
			var result3 = (JObject)cb[3];
			var result4 = (JObject)cb[4];

			string url = "https://image.tmdb.org/t/p/w500/"+result0.GetValue("poster_path").ToString();
			tex = new Texture2D (4, 4, TextureFormat.DXT1, false);
			using(WWW www2 = new WWW (url)){
				yield return www2;
				www2.LoadImageIntoTexture (tex);
				p1.GetComponent<Renderer> ().material.mainTexture = tex;
			}
			string url1 = "https://image.tmdb.org/t/p/w500/"+result1.GetValue("poster_path").ToString();
			tex1 = new Texture2D (4, 4, TextureFormat.DXT1, false);
			using(WWW www2 = new WWW (url1)){
				yield return www2;
				www2.LoadImageIntoTexture (tex1);
				p2.GetComponent<Renderer> ().material.mainTexture = tex1;
			}
			string url2 = "https://image.tmdb.org/t/p/w500/"+result2.GetValue("poster_path").ToString();
			tex2 = new Texture2D (4, 4, TextureFormat.DXT1, false);
			using(WWW www2 = new WWW (url2)){
				yield return www2;
				www2.LoadImageIntoTexture (tex2);
				p3.GetComponent<Renderer> ().material.mainTexture = tex2;
			}
			string url3 = "https://image.tmdb.org/t/p/w500/"+result3.GetValue("poster_path").ToString();
			tex3 = new Texture2D (4, 4, TextureFormat.DXT1, false);
			using(WWW www2 = new WWW (url3)){
				yield return www2;
				www2.LoadImageIntoTexture (tex3);
				p4.GetComponent<Renderer> ().material.mainTexture = tex3;
			}
			string url4 = "https://image.tmdb.org/t/p/w500/"+result4.GetValue("poster_path").ToString();
			tex4 = new Texture2D (4, 4, TextureFormat.DXT1, false);
			using(WWW www2 = new WWW (url4)){
				yield return www2;
				www2.LoadImageIntoTexture (tex4);
				p5.GetComponent<Renderer> ().material.mainTexture = tex4;
			}
			//genre1.text = id1;
			/*for (int i = 0; i < cb.Count; i++)
			//{
				//var item = (JObject)cb[i];
				//print(item);
				//do something with item
			//}*/
			//string results = json.GetValue("results").ToString();
			//namaakunpenerima.text = json.GetValue("nama_pemilik").ToString();
		}
	}
	IEnumerator upmov() {
		UnityWebRequest www = UnityWebRequest.Get("https://api.themoviedb.org/3/movie/upcoming?api_key="+key+"&language=en-US&page=1");
		yield return www.Send();
		if(www.isError) {
			//pesan.text ="ip localhost:8085" + www.error;
			Debug.Log("ip 10.205.6.138:8085" + www.error);
		}
		else {
			string hasil = www.downloadHandler.text;
			JObject json = JObject.Parse(hasil);
			//Debug.Log(json.GetValue("Status"));
			Newtonsoft.Json.Linq.JArray cb =(Newtonsoft.Json.Linq.JArray)json["results"];
			var result0 = (JObject)cb[0];
			var result1 = (JObject)cb[1];
			var result2 = (JObject)cb[2];

			string url = "https://image.tmdb.org/t/p/w500/"+result0.GetValue("poster_path").ToString();
			texu = new Texture2D (4, 4, TextureFormat.DXT1, false);
			using(WWW www2 = new WWW (url)){
				yield return www2;
				www2.LoadImageIntoTexture (texu);
				u1.GetComponent<Renderer> ().material.mainTexture = texu;
			}
			string url1 = "https://image.tmdb.org/t/p/w500/"+result1.GetValue("poster_path").ToString();
			texu1 = new Texture2D (4, 4, TextureFormat.DXT1, false);
			using(WWW www2 = new WWW (url1)){
				yield return www2;
				www2.LoadImageIntoTexture (texu1);
				u2.GetComponent<Renderer> ().material.mainTexture = texu1;
			}
			string url2 = "https://image.tmdb.org/t/p/w500/"+result2.GetValue("poster_path").ToString();
			texu2 = new Texture2D (4, 4, TextureFormat.DXT1, false);
			using(WWW www2 = new WWW (url2)){
				yield return www2;
				www2.LoadImageIntoTexture (texu2);
				u3.GetComponent<Renderer> ().material.mainTexture = texu2;
			}
	}
}
	public void detailspn(){
		ini.SetActive (false);
		pn.SetActive (true);
	}
	public void detailsum(){
		ini.SetActive (false);
		um.SetActive (true);
	}
	public void peo(){
		ini.SetActive (false);
		popp.SetActive (true);
	}
	public void trmn(){
		ini.SetActive (false);
		trm.SetActive (true);
	}
}
