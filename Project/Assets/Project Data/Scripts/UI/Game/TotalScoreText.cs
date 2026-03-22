using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.PersistentVariables;
using TMPro;

public class TotalScoreText : MonoBehaviour
{
    [SerializeField]
    ScoreObject scoreObject;

    [SerializeField]
    TextMeshProUGUI display;

    //[SerializeField, TextArea]
    //string displayText = "SCORE: ";
	
	public LocalizedString localisedString;
	public FloatVariable scoreVariable;

    private void OnEnable()
    {
        scoreObject.onScoreChanged += UpdateText;
		
		//localisedString.AddArgument("score", scoreVariable);
    }

    private void OnDisable()
    {
        scoreObject.onScoreChanged -= UpdateText;
    }

    public void UpdateText(float score)
    {
        scoreVariable.Value = score;
        // LocalizedString will update automatically if bound; otherwise force update below
        localisedString.RefreshString();
        display.SetText(localisedString.GetLocalizedString());
    }
}
