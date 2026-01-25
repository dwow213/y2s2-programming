using NodeCanvas.Framework;
using NodeCanvas.StateMachines;
using TMPro;
using UnityEngine;

public class ScoreUpdater : MonoBehaviour
{
    public FSMOwner hare;
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
        //get scores from the blackboards
        int hareScore = hare.blackboard.GetVariableValue<int>("score");
        int turtleScore = turtle.GetVariableValue<int>("score");
        print($"Hare score: {hareScore}");

        hareScoreText.text = $"Hare Score: {hareScore}";
        turtleScoreText.text = $"Turtle Score: {turtleScore}";
    }
}
