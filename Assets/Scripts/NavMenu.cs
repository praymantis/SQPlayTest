using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMenu : MonoBehaviour
{
    public GameObject infoObj;
    public GameObject listObj;
    public Popup matchPopup;

    private GameObject currentShown;

    private void Start()
    {
        infoObj.SetActive(true);
        currentShown = infoObj;
    }

    public void OnInfo()
    {
        if (currentShown != infoObj)
            currentShown.SetActive(false);
        infoObj.SetActive(true);
        currentShown = infoObj;
    }

    public void OnPlayers()
    {
        if (currentShown != listObj)
            currentShown.SetActive(false);
        listObj.SetActive(true);
        currentShown = listObj;
        MainManager.Instance.OnLoadPlayers();
    }

    public void OnMatch()
    {
        matchPopup.Show();
    }
}
