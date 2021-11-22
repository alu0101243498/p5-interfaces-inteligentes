using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class DictationRecog : MonoBehaviour
{
    [SerializeField]
    private Text m_Hypotheses;

    [SerializeField]
    private Text m_Recognitions;

	DictationRecognizer dictationRecognizer;
 
    public Color amarillo;
    public Color violeta;
    public Color negro;
    public Color azul;
    public Color naranja;
    MeshRenderer myRenderer;

	// Use this for initialization
	void Start () {
		dictationRecognizer = new DictationRecognizer();
 
		dictationRecognizer.DictationResult += onDictationResult;
		dictationRecognizer.DictationHypothesis += onDictationHypothesis;
		dictationRecognizer.DictationComplete += onDictationComplete;
		dictationRecognizer.DictationError += onDictationError;
 
		//dictationRecognizer.Start();
	}
 
	void onDictationResult(string text, ConfidenceLevel confidence)
	{
		// write your logic here
		//Debug.LogFormat("Dictation result: " + text);
        if (text == "amarillo") {
            myRenderer = GetComponent<MeshRenderer>();
            myRenderer.material.color = amarillo;
        }
        if (text == "violeta") {
            myRenderer = GetComponent<MeshRenderer>();
            myRenderer.material.color = violeta;
        }
        if (text == "negro") {
            myRenderer = GetComponent<MeshRenderer>();
            myRenderer.material.color = negro;
        }
        if (text == "naranja") {
            myRenderer = GetComponent<MeshRenderer>();
            myRenderer.material.color = naranja;
        }
        if (text == "azul") {
            myRenderer = GetComponent<MeshRenderer>();
            myRenderer.material.color = azul;
        }
	}
 
	void onDictationHypothesis(string text)
	{
		Debug.LogFormat("Dictation hypothesis: {0}", text);
	}
 
	void onDictationComplete(DictationCompletionCause cause)
	{
		if (cause != DictationCompletionCause.Complete)
			Debug.LogErrorFormat ("Dictation completed unsuccessfully: {0}.", cause);
	}
 
	void onDictationError(string error, int hresult)
	{
		Debug.LogErrorFormat("Dictation error: {0}; HResult = {1}.", error, hresult);
	}

    void Update() {
        if (Input.GetKey(KeyCode.X)) {
            dictationRecognizer.Start();
        }
        if (Input.GetKey(KeyCode.Z)) {
            dictationRecognizer.Stop();
        }
        if (Input.GetKey(KeyCode.D)) {
            dictationRecognizer.Dispose();
        }
    }
}