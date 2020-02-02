using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public TextMesh MachineText;
    public int BugCount;

    // Start is called before the first frame update
    void Start()
    {
        MachineText.text = "Error:\n" + BugCount + " Bugs";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BugKilled()
    {
        if (BugCount > 0)
        {
            BugCount--;
        }
        if (BugCount > 0)
        {
            MachineText.text = "Error:\n" + BugCount + " Bugs";
        }
        else
        {
            MachineText.text = "Fixed!";
        }
    }
}
