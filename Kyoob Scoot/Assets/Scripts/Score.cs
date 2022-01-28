using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Transform player;
    public Text scoreText;
    public float totalDistance = 1000f;

    // Update is called once per frame
    void Update()
    {
        

        if(scoreText.text == "100%")
        {
            scoreText.text = "100%";
        }
        else
        {
            scoreText.text = (player.position.z/totalDistance*100).ToString("0") + "%";
        }
    }
}
