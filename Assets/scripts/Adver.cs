using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;


public class Adver : MonoBehaviour {

	
    public static void showAdvertiseMent()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo");
        }                  
    }
	

}
