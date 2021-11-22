using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class KeywordRecog : MonoBehaviour
{
    private KeywordRecognizer kr;
    public string[] keywords;
    public Color amarillo;
    public Color verde;
    public Color rojo;
    public Color azul;
    public Color blanco;
    MeshRenderer myRenderer;
    // Start is called before the first frame update
    void Start()
    {
        keywords = new string[5];
        keywords[0] = "amarillo";
        keywords[1] = "rojo";
        keywords[2] = "verde";
        keywords[3] = "azul";
        keywords[4] = "blanco";
        kr = new KeywordRecognizer(keywords);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q)) {
            kr.OnPhraseRecognized += OnKeywordsRecognized;
            kr.Start();
        }
        if (Input.GetKey(KeyCode.Space)) {
            kr.Stop();
        }
        if (Input.GetKey(KeyCode.E)) {
            kr.Dispose();
            kr.OnPhraseRecognized -= OnKeywordsRecognized;
        }
    }

    void OnKeywordsRecognized(PhraseRecognizedEventArgs args) {
        if (args.text == keywords[0]) {
            myRenderer = GetComponent<MeshRenderer>();
            myRenderer.material.color = amarillo;
        }
        if (args.text == keywords[1]) {
            myRenderer = GetComponent<MeshRenderer>();
            myRenderer.material.color = rojo;
        }
        if (args.text == keywords[2]) {
            myRenderer = GetComponent<MeshRenderer>();
            myRenderer.material.color = verde;
        }
        if (args.text == keywords[3]) {
            myRenderer = GetComponent<MeshRenderer>();
            myRenderer.material.color = azul;
        }
        if (args.text == keywords[4]) {
            myRenderer = GetComponent<MeshRenderer>();
            myRenderer.material.color = blanco;
        }
    }
}
