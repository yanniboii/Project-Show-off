using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] TMP_Text m_Text;
    int score1 = 0;
    int score2 = 0;
    // Start is called before the first frame update
    void Start()
    {
        m_Text.text = score1 + " - " + score2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(bool side)
    {
        if(side)
        {
            score1++;
            m_Text.text = score1 + " - " + score2;
        }
        else
        {
            score2++;
            m_Text.text = score1 + " - " + score2;
        }
    }
}
