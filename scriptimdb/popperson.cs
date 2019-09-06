using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;

public class popperson : MonoBehaviour {
	string key = "aa9ba31a0fc74a076849181a5b323377";
	public Button menu,next;
	public Text namap1, namap2, namap3;
	public Text Rating1, Rating2, Rating3;
	public Text gender1, gender2, gender3;
	public GameObject image1,image2,image3;
	public Texture2D tex,tex1,tex2;
	public GameObject ini,nanti,cha1,cha2;
	//public Image imgt1,imgt2,imgt3;
	// Use this for initialization
	void Start () {
		StartCoroutine (getplaymovie1 ());
		menu.onClick.AddListener (() => menubtn());
		next.onClick.AddListener (() => next1());
	}

	// Update is called once per frame
	void Update () {

	}
	IEnumerator getplaymovie1() {
		UnityWebRequest www = UnityWebRequest.Get("https://api.themoviedb.org/3/person/popular?api_key="+key+"&language=en-US&page=1");
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
			namap1.text = result0.GetValue("name").ToString();
			namap2.text = result1.GetValue("name").ToString();
			namap3.text = result2.GetValue("name").ToString();
			string genders1, genders2, genders3;
			if (result0.GetValue ("gender").ToString () == "1") {
				genders1 = "Female";
			} else {
				genders1 = "Male";
			}
			if (result1.GetValue ("gender").ToString () == "1") {
				genders2 = "Female";
			} else {
				genders2 = "Male";
			}
			if (result2.GetValue ("gender").ToString () == "1") {
				genders3 = "Female";
			} else {
				genders3 = "Male";
			}
			gender1.text = genders1;
			gender2.text = genders2;
			gender3.text = genders3;

			Rating1.text = result0.GetValue("popularity").ToString();
			Rating2.text = result1.GetValue("popularity").ToString();
			Rating3.text = result2.GetValue("popularity").ToString();
			string url = "https://image.tmdb.org/t/p/w500/"+result0.GetValue("profile_path").ToString();
			tex = new Texture2D (4, 4, TextureFormat.DXT1, false);
			using(WWW www2 = new WWW (url)){
				yield return www2;
				www2.LoadImageIntoTexture (tex);
				image1.GetComponent<Renderer> ().material.mainTexture = tex;
			}
			string url1 = "https://image.tmdb.org/t/p/w500/"+result1.GetValue("profile_path").ToString();
			tex1 = new Texture2D (4, 4, TextureFormat.DXT1, false);
			using(WWW www2 = new WWW (url1)){
				yield return www2;
				www2.LoadImageIntoTexture (tex1);
				image2.GetComponent<Renderer> ().material.mainTexture = tex1;
			}
			string url2 = "https://image.tmdb.org/t/p/w500/"+result2.GetValue("profile_path").ToString();
			tex2 = new Texture2D (4, 4, TextureFormat.DXT1, false);
			using(WWW www2 = new WWW (url2)){
				yield return www2;
				www2.LoadImageIntoTexture (tex2);
				image3.GetComponent<Renderer> ().material.mainTexture = tex2;
			}
			//img1.sprite = Sprite.Create (www2.texture,new Rect(0,0,300,300),new Vector2(0,0));
			//	img1.sprite = imgt1;

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
	public void menubtn(){
		ini.SetActive (false);
		nanti.SetActive (true);
	}
	public void next1(){
		cha1.SetActive (false);
		cha2.SetActive (true);
	}
}
