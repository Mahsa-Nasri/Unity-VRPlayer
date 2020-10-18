using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

/* This is the VideoController script to play the various clips */
// making sure that there is a VideoPlayer Component

[RequireComponent(typeof(VideoPlayer))]

public class VideoController : MonoBehaviour
{
    public Material SkyBoxVideoMat;
  
    public static VideoController instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
       
    }

    // array, discarding the clips you assigned in the Inspector.
   
    public VideoClip[] vids = new VideoClip[10];
    private VideoPlayer vp;

 
    public void PlayVideo(int id)
    {
        RenderSettings.skybox = SkyBoxVideoMat;
        // Check the ID
        
        if (id < 0 )
        {
            Debug.LogErrorFormat(
               "Cannot play video #{0}. The array contains {1} video(s)",
                                   id, vids.Length);
            return;
        }

        if(id >= vids.Length)
        {
            Debug.Log("Playing again");
            id = 0;
           GameManager.instance.counter = 0;

        }

        // If we get here, we know the ID is safe.
        // So we assign the (id+1)th entry of the vids array as our clip.

        vp.clip = vids[id];
        vp.Play();
        
    }

    void Start()
    {
        vp = gameObject.GetComponent<VideoPlayer>();
    }

    
    
}


