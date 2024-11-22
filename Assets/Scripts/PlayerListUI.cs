using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerListUI : MonoBehaviour
{
    public RectTransform content;
    public HorizontalLayoutGroup layout;
    public ScrollRect scrollRect;
    public PlayerUI playerTemplate;

    private List<PlayerUI> currentPlayers = new List<PlayerUI>();

    public void ClearPlayerList(int index = 0)
    {
        var childCount = 0 + content.childCount;
        for (int i = childCount - 1; i >= index; i--)
            Destroy(content.GetChild(i).gameObject);
        if (currentPlayers.Count > 0 && index < currentPlayers.Count)
            currentPlayers.RemoveRange(index, currentPlayers.Count - index);
    }

    public void LoadPlayers(List<Player> players)
    {
        var playerTempWidth = (playerTemplate.transform as RectTransform).rect.width;
        var width = 0.0f;
        var index = 0;
        for (var i = 0; i < currentPlayers.Count; i++)
        {
            if (i < players.Count)
            {
                currentPlayers[i].SetPlayer(players[i]);
                width += playerTempWidth + layout.spacing;
                index++;
            }
            else
            { break; }
        }
        ClearPlayerList(index);

        for (var i = index; i < players.Count; i++)
        {
            var player = Instantiate(playerTemplate, content);
            player.SetPlayer(players[i]);
            currentPlayers.Add(player);
            player.gameObject.SetActive(true);
            width += playerTempWidth + layout.spacing;
        }
        width -= layout.spacing;
        content.sizeDelta = new Vector2(width, content.sizeDelta.y);
    }
}
