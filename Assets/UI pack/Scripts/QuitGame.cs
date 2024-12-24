using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(QuitGameButton);
    }

    public void QuitGameButton()
    {
        MainMenu.QuitGame();
    }
}
