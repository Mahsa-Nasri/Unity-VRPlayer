using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

/* This project is a 360 degree movie player that can be built as an application for any mobile device. 
 * Due to costumer's need on right click or space bar on keyboard we move to the next clip and 
 * left click or leftAlt on keyboard are defined for playing previous clip. 
 */
public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public GameObject LoadingPanel;
    public GameObject MenuImage;
    public GameObject MenuPanel;
    public GameObject StartButmn;
    public int counter= 0;
    public int down = 0;
    private IEnumerator coroutine;
    public bool status = false;
    public Material SkyBoxMenuMat;
   


    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        // Here we avtivate the first menu and attached UI elements.
        LoadingPanel.SetActive(false);
        MenuImage.SetActive(true);
        MenuPanel.SetActive(true);
        StartButmn.SetActive(true);
      
    }


    void Start()
    {
      
        LoadingPanel.SetActive(true); 

        StartCoroutine(ExampleCoroutine());

        RenderSettings.skybox = SkyBoxMenuMat;
       
    }
    // below function is called when we press the start button in order to play the first clip.
    public void StartBut()
    {
        counter = 0;
        LoadingPanel.SetActive(false);
        MenuImage.SetActive(false);
        MenuPanel.SetActive(false);
        StartButmn.SetActive(false);
        status = true;

        Debug.Log("start");
        VideoController.instance.PlayVideo(counter);
       counter++;

    }

    // below function is called whenever user wants to exit the game.
    public void ExitGame()
    {
        status = true;
        counter = 0;
        LoadingPanel.SetActive(false);
        MenuImage.SetActive(false);
        MenuPanel.SetActive(false);
        StartButmn.SetActive(false);
        Application.Quit();
        Debug.Log("exit");
       
    }

    // In Update function, we constantly check the inputs and decide which one have to operate.

    void Update()
    {
        if ( Input.GetButtonDown("Cancel"))
        {
            Debug.Log("pressed esc");
            Application.Quit();
        }

       
            if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Jump") )
        {
            
            if (counter== 4)
            {
                counter = down;
               
                VideoController.instance.PlayVideo(counter);
                counter = 0;
            }
         
            LoadingPanel.SetActive(false);
            MenuImage.SetActive(false);
            MenuPanel.SetActive(false);
            StartButmn.SetActive(false);
            Debug.Log("Pressed primary button.");
        
            VideoController.instance.PlayVideo(counter);
            down = counter;
            counter++;
         
        }

        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.LeftAlt) )
        {
            if(down== 4)
            {
                down--;
              
                VideoController.instance.PlayVideo(down);

            }
            down--;

            LoadingPanel.SetActive(false);
            MenuImage.SetActive(false);
            MenuPanel.SetActive(false);
            StartButmn.SetActive(false);
            Debug.Log("Pressed secondary button.");
            VideoController.instance.PlayVideo(down);
            
        }
     
    }






}
