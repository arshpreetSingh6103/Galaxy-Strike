using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyBlast;
    [SerializeField] int hitPoints = 3;
    [SerializeField] int scoreValue = 10;

    ScoreBoard ScoreBoard;
    
    private void Start()
    {
        ScoreBoard = FindFirstObjectByType<ScoreBoard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        hitPoints--;
        
        if(hitPoints <= 0)
        {  
            ScoreBoard.hitCount(scoreValue);
            Instantiate(enemyBlast, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    
}
