using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Cursor = UnityEngine.UIElements.Cursor;

public class GameOver_pres : MonoBehaviour
{
    private void Awake()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        root.Q<Button>("restart").clicked += () => SceneManager.LoadScene("SampleScene");
        root.Q<Button>("mainmenu").clicked += () => SceneManager.LoadScene("Main Menu");
    }
}
