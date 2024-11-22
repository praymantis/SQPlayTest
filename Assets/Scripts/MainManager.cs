using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MainManager : MonoBehaviour
{
    public PlayerListUI playersList;
    public Popup waitPopup;

    public static MainManager Instance { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);

        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLoadPlayers()
    {
        if (waitPopup != null)
            waitPopup.Show();
        StartCoroutine(GetRequest("http://unity-test.eba-wifmhmut.eu-central-1.elasticbeanstalk.com/api/players-test"));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError("Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError("HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("Player data: " + webRequest.downloadHandler.text);
                    var jData = webRequest.downloadHandler.text.DeserializeObject<JArray>();
                    List<Player> players = jData.ToObject<List<Player>>();
                    Debug.Log("Player Count: " + players.Count);
                    playersList.LoadPlayers(players);
                    Debug.Log("Success");
                    break;
            }

            if (waitPopup != null)
                waitPopup.Hide();
        }
    }
}
