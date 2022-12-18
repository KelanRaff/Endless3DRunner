using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class ScoreUI : MonoBehaviour
{
   public RowUI rowUI;
   public ScoreManager scoreManager;

   void Start(){
    //scoreManager.AddScore(new Score("John", 88));
    //scoreManager.AddScore(new Score("Kelan", 100));
    //scoreManager.AddScore(new Score("Conor", 67));

    var scores = scoreManager.GetHighScores().ToArray();
    for (int i = 0; i<scores.Length; i++){
        var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
        row.rank.text = (i +1).ToString();
        row.name.text = scores[i].name;
        row.score.text = scores[i].score.ToString();
    }
   }

}
