using NodeCanvas.Framework;
using TMPro;
using UnityEngine;

public class ScoreUpdater : MonoBehaviour
{
    public Blackboard hare;
    public Blackboard turtle;

    public TextMeshProUGUI hareScoreText;
    public TextMeshProUGUI turtleScoreText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int hareScore = hare.GetVariableValue<int>("score");
        int turtleScore = turtle.GetVariableValue<int>("score");

        hareScoreText.text = $"Hare Score: {hareScore}";
        turtleScoreText.text = $"Turtle Score: {turtleScore}";
    }
}
