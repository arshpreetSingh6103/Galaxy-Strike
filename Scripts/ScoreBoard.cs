using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    
    int score = 0;

    public void hitCount(int amount)
    {
        score +=amount;
        scoreText.text = score.ToString();
    }


}
