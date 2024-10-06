using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI scoreUI;

    GameManager gm;
    private void Start() {
        gm = GameManager.Instance;
    }

    private void OnGUI() {
        scoreUI.text = GameManager.Instance.PrettyScore();
    }
}
