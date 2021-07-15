using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerLogic : MonoBehaviour
{
    public int TotalItemCount;
    public int stage;
    public Text stageCountText;
    public Text playerCountText;

    public int totalstage;

    void Awake()
    {
        stageCountText.text = "/ "+TotalItemCount;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player")
        {
            SceneManager.LoadScene(stage-1);
        }
    }

    public void GetItem(int count)
    {
        playerCountText.text = count.ToString();
    }
}
