using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public string PlayerName;
    public string Gender;
    public Sprite ArgueChild;
    public Sprite WorkChild;
    public Sprite TransChild;
    public bool ControlAllowed = true;
    //Level 1 Information
    public bool Level1Visited = false;
    public int KeyAttempts = 0;
    public bool ChoresCompleted = true;
    public bool LabCompleted = false;
    public bool KeyCollected = false;
    public Vector3 KeyPosition;
    public int SamplesCollected = 0;
    public int PuddlesCleaned = 0;
    public bool Level1TaskDone = false;
    public Dictionary<string, bool> Level1Items = new Dictionary<string, bool>();
    //Level 2 Information
    public bool Obstacle1Done = false;
    public bool CanPushRock = false;
    public bool Obstacle3Done = false;
    public string Obstacle1Choice = "";
    public string Obstacle2Choice = "";
    public string Obstacle3Choice = "";
    public Dictionary<string, bool> Obstacle3Components = new Dictionary<string, bool>();
    //Level 3 Information
    public bool InLevel3 = false;
    public bool Question1Done = false;
    public bool Question2Done = false;
    public bool Question3Done = false;

    public bool CrystalCollected = false;
    public Dictionary<string, string> Avatars = new Dictionary<string, string>();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Level1Items.Add("R", false);
        Level1Items.Add("B", false);
        Level1Items.Add("N", false);
        Level1Items.Add("E", false);
        Obstacle3Components.Add("MaroonWire", false);
        Obstacle3Components.Add("PurpleWire", false);
        Obstacle3Components.Add("BlueWire", false);
        Obstacle3Components.Add("MaroonArea", false);
        Obstacle3Components.Add("PurpleArea", false);
        Obstacle3Components.Add("BlueArea", false);

        Avatars.Add("O1B1", "Joan Clarke");
        Avatars.Add("O1B2", "Alan Turing");
        Avatars.Add("O2B1", "The Male Wrestler");
        Avatars.Add("O2B2", "The Female Wrestler");
        Avatars.Add("O3B1", "The Electrician");
        Avatars.Add("O3B2", "Your Mother");

        KeyPosition = new Vector3(0.0f, 4.5f, 8.0f);
        ControlAllowed = false;
        Destroy(gameObject.GetComponent<Canvas>());
        SceneManager.LoadScene(1);
    }
}
