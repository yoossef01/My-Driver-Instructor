using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class green : MonoBehaviour
{
   public Material red;
   public Material Orange;
   public Material vert;
   Color  noir;
   Color  Green;
   Color rouge;
   Color orang;
   Color verte;
   
    // Start is called before the first frame update
    public void changercouleur(){StartCoroutine(Waitt());
        
              ColorUtility.TryParseHtmlString("#FF0000", out rouge);
       ColorUtility.TryParseHtmlString("#FF6900", out orang);
      ColorUtility.TryParseHtmlString("#444040", out verte);
   StartCoroutine(Wait());}

    // Update is called once per frame
    IEnumerator Wait()
    {    //set the bool to stop moving
       
         
        yield return new WaitForSeconds(6); 
        red.color=rouge;
        Orange.color=orang;
        vert.color=verte;
} 
IEnumerator Waitt()
    {    //set the bool to stop moving
       
         
        yield return new WaitForSeconds(1); 
        ColorUtility.TryParseHtmlString("#444040", out noir);
    ColorUtility.TryParseHtmlString("#00FF21", out Green);
        red.color=noir;
        Orange.color=noir;
        vert.color=Green;
}
}
