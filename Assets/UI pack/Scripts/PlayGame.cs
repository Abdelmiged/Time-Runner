using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    Button btn;
    public void Start()
    {
        btn = this.gameObject.GetComponent<Button>();
        btn.onClick.AddListener(PlayGameButton);
    }

    public void PlayGameButton()
    {
        MainMenu.PlayGame();
    }
}
