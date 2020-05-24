using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title: MonoBehaviour {

    private Text objText;

    // Start is called before the first frame update
    void Start() {
        objText = GetComponent<Text>();
        objText.text = "";
    }

    // Update is called once per frame
    void Update() {
        
    }
}
