using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class restart_game : MonoBehaviour
{   
    Button btn;
    public string sceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(restartGame);
    }

    void restartGame()
    {   
        FindObjectOfType<SceneLoader>().LoadScene(sceneToLoad);
    }
}
