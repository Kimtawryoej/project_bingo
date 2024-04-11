using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [SerializeField] private Button start;
    private void Awake()
    {
        start.onClick.AddListener(() => SceneManager.LoadScene(1));
    }
}
