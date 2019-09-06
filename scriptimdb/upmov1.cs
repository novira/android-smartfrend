using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;

public class upmov1 : MonoBehaviour {
	string key = "aa9ba31a0fc74a076849181a5b323377";
	public Button menu,next;
	public Button overview1,overview2;
	public Text title1, title2;
	public Text genre1, genre2;
	public Text Release1,Release2;
	public Text Rating1, Rating2;
	public Text overviewtxt;
	public GameObject image1,image2;
	public Texture2D tex,tex1;
	public GameObject ini,nanti,cha1,cha2,main,over;
	//public Image imgt1,imgt2,imgt3;
	// Use this for initialization
	void Start () {
		StartCoroutine (getplaymovie1 ());
		menu.onClick.AddListener (() => menubtn());
		next.onClick.AddListener (() => next1());
		overview1.onClick.AddListener (() => StartCoroutine (overview (3)));
		overview2.onClick.AddListener (() => StartCoroutine (overview (4)));
	}

	// Update is called once per frame
	void Update () {

	}
	IEnumerator getplaymovie1() {
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
			var result0 = (JObject)cb[3];
			var result1 = (JObject)cb[4];
			title1.text = result0.GetValue("original_title").ToString();
			title2.text = result1.GetValue("original_title").ToString();

			Release1.text = result0.GetValue("release_date").ToString();
			Release2.text = result1.GetValue("release_date").ToString();

			Rating1.text = result0.GetValue("vote_average").ToString();
			Rating2.text = result1.GetValue("vote_average").ToString();
			string url = "https://image.tmdb.org/t/p/w500/"+result0.GetValue("poster_path").ToString();
			tex = new Texture2D (4, 4, TextureFormat.DXT1, false);
			using(WWW www2 = new WWW (url)){
				yield return www2;
				www2.LoadImageIntoTexture (tex);
				image1.GetComponent<Renderer> ().material.mainTexture = tex;
			}
			string url1 = "https://image.tmdb.org/t/p/w500/"+result1.GetValue("poster_path").ToString();
			tex1 = new Texture2D (4, 4, TextureFormat.DXT1, false);
			using(WWW www2 = new WWW (url1)){
				yield return www2;
				www2.LoadImageIntoTexture (tex1);
				image2.GetComponent<Renderer> ().material.mainTexture = tex1;
			}

			UnityWebRequest www1 = UnityWebRequest.Get("https://api.themoviedb.org/3/genre/movie/list?api_key="+key+"&language=en-US&page=1");
			yield return www1.Send();
			if (www1.isError) {
				//pesan.text ="ip localhost:8085" + www.error;
				Debug.Log ("ip 10.205.6.138:8085" + www1.error);
			} else {
				string hasil1 = www1.downloadHandler.text;
				print ("hasil"+hasil1);
				JObject json1 = JObject.Parse (hasil1);
				Newtonsoft.Json.Linq.JArray cb1 = (Newtonsoft.Json.Linq.JArray)json1 ["genres"];
				for (int i = 0; i < cb1.Count; i++){
					var item1 = (JObject)cb1[i];

					//print (item1.GetValue ("id").ToString () +","+ genres0);
					if (item1.GetValue ("id").ToString () == result0["genre_ids"][0].ToString()) {
						genre1.text = item1.GetValue ("name").ToString ();
					}
					if (item1.GetValue ("id").ToString () == result1["genre_ids"][0].ToString()) {
						genre2.text = item1.GetValue ("name").ToString ();
					}

				}
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
	public void menubtn(){
		ini.SetActive (false);
		nanti.SetActive (true);
	}
	public void next1(){
		cha1.SetActive (false);
		cha2.SetActive (true);
	}
	IEnumerator overview(int angka) {
		over.SetActive (true);
		UnityWebRequest www = UnityWebRequest.Get("https://api.themoviedb.org/3/movie/upcoming?api_key="+key+"&language=en-US&page=1");
		yield return www.Send();
		if (www.isError) {
			//pesan.text ="ip localhost:8085" + www.error;
			Debug.Log ("ip 10.205.6.138:8085" + www.error);
		} else {
			string hasil = www.downloadHandler.text;
			JObject json = JObject.Parse(hasil);
			//Debug.Log(json.GetValue("Status"));
			Newtonsoft.Json.Linq.JArray cb =(Newtonsoft.Json.Linq.JArray)json["results"];
			var result0 = (JObject)cb[angka];
			overviewtxt.text = result0.GetValue("overview").ToString();
			main.SetActive (false);
		}

	}
}
