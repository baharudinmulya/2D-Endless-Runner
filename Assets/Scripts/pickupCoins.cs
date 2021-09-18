using System.Collections;
using UnityEngine;

public class pickupCoins : MonoBehaviour
{
    public int scoreToGive;
    private ScoreController theScoreManager;


    // Start is called before the first frame update
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name=="Main Character")
        {
            //Debug.Log("lewat");
            theScoreManager.AddScore(scoreToGive);
            gameObject.SetActive(false);
        }
    }
}
