using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GerenciarUI : MonoBehaviour
{

    public Text cronometroText;

    public Text scoreLocalText;
    

    // Start is called before the first frame update
   public void SincronizarScore(float newScore)
   {
        scoreLocalText.text = newScore.ToString();
   }
}
