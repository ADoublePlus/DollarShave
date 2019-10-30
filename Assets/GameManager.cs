using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    GameObject Beard;

    public GameObject[] beards;

   public int bearsShaven;

    public Text loseText;
    public Text winText;

    float timer = 10f;

    public AudioSource audit;

    

    // public Text scoreText;


    enum BeardTypes
    {
        Short,
        Medium,
        Long,
        Viking
    };

    enum CutRequests
    {
        Clean,
        Short,
        Stubble
    };


    // Start is called before the first frame update
    void Start()
    {
        Beard = GetComponent<GameObject>();
        audit = GetComponent<AudioSource>();

        BeardDecision();

        bearsShaven = 0;

        this.audit.Play();
        //scoreText.text = "Score: " + bearsShaven.ToString();

        loseText.GetComponent<Text>().enabled = false;
        winText.GetComponent<Text>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray.origin, ray.direction, out hit))
        {
           //if (Input.GetKeyDown(KeyCode.Mouse1))
            //{
                if (hit.collider.tag == "Beard")
                {
                    Debug.Log("GETTTT FOOOOKKKKED");
                    Destroy(hit.collider.gameObject);
                    
                    
                }
            //}
        }

        timer -= Time.deltaTime;

        WinOrLose();
    }

    void BeardRequest()
    {
        BeardTypes bt = default;

        BeardDecision();

        CutRequests cr;
        
        cr = (CutRequests)Random.Range(0, System.Enum.GetValues(typeof(CutRequests)).Length);

        
        if (bt == BeardTypes.Short && cr == CutRequests.Short)
        {
            cr = (CutRequests)Random.Range(0, System.Enum.GetValues(typeof(CutRequests)).Length);
        }
        else
        {
            if (cr == CutRequests.Clean)
            {
                // Add point
                
                bearsShaven++;
                
                BeardDecision();
            }

            if (cr == CutRequests.Short)
            {
                // Destroy old object and replace with a short 


                // Add one point when gameobject is destroyed


                bearsShaven++;
                BeardDecision();
            }

            if (cr == CutRequests.Stubble)
            {
                // Replace with old

                // Add point

                bearsShaven++;
                BeardDecision();
            }
        }

        
    }


    void ClientChoice()
    {


        Beard = GetComponentInParent<GameObject>();

        
    }

    void BeardDecision()
    {

        BeardTypes bt;
        bt = (BeardTypes)Random.Range(0, System.Enum.GetValues(typeof(BeardTypes)).Length);

        

        switch (bt)
        {
            case BeardTypes.Short:

                for (int i = 0; i < beards.Length; i++)
                {
                    Beard = beards[i];

                    if (Beard.gameObject.tag == "Short")
                    {
                        Beard.gameObject.SetActive(true);

                        Debug.Log("It fookin worked you nump");
                    }
                }
                break;

            case BeardTypes.Medium:
                for (int i = 0; i < beards.Length; i++)
                {
                    Beard = beards[i];

                    if (Beard.gameObject.tag == "Medium")
                    {
                        Beard.gameObject.SetActive(true);
                        Debug.Log("Maybe it needs a bit more lovin");
                    }
                }
                break;

            case BeardTypes.Long:
                for (int i = 0; i < beards.Length; i++)
                {
                    Beard = beards[i];

                    if (Beard.gameObject.tag == "Long")
                    {
                        Beard.gameObject.SetActive(true);
                        Debug.Log("DeeeeeeEEEEEEEEEeeeeeEEeeeeEEEEts");
                    }
                }
                break;

            case BeardTypes.Viking:
                for (int i = 0; i < beards.Length; i++)
                {
                    Beard = beards[i];

                    if (Beard.gameObject.tag == "Viking")
                    {
                        Beard.gameObject.SetActive(true);
                        Debug.Log("Moist Scrumpets");
                    }
                }
                break;

            default:
                break;
        }

    }

    void WinOrLose()
    {
        /*bool hasWon;
        bool hasLost;

        
        if (bearsShaven == 5)
        {
            hasWon = true;
            Debug.Log("DABBBB THAT COOKIE");
        }
        */

        if (timer <= 0)
        {
            timer = Time.timeScale = 0;
            this.audit.Stop();
            loseText.GetComponent<Text>().enabled = true;
            Debug.Log("YOU FOOKIN FAILED YOU ABSOLUTE NUMP");
        }

        if (timer > 0 && timer <= 10)
        {
            if (GameObject.FindGameObjectsWithTag("Beard").Length == 0)
            {
                Time.timeScale = 0;
                this.audit.Stop();
                winText.GetComponent<Text>().enabled = true;
                Debug.Log("Jingle Jangle Splush");
            }
        }
    }
}
