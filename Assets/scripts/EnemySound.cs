using UnityEngine;

public class EnemySound : MonoBehaviour {

    private GameObject player;
    private AudioSource aud;
    private Vector3 playerPos;
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player") as GameObject;
        aud = GetComponent<AudioSource>();
     }
    void Update()
    {
        if ((Mathf.Abs(player.transform.position.z - transform.position.z) <15))
        {
            if (!aud.isPlaying)
            {
                aud.Play();
            }
        }
        else
        {
            if(aud.isPlaying)
            {
                aud.Stop();
                    
            }
        }
       
    }
}
