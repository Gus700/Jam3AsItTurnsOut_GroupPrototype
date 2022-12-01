using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Manager : MonoBehaviour
{
    [Tooltip("If this unit used their move action")]
    public bool CanMove { get; set; }

    [Tooltip("If this unit used their shoot action")]
    public bool CanShoot { get; set; }

    [Tooltip("If this unit still has actions remaining. If no actions remain, this boolean returns false")]
    public bool HasActions { get; set; }

    [Tooltip("Name of this unit")]
    public string Name { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        CanMove = true;
        CanShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!CanMove && !CanShoot)
        {
            HasActions = false;
        }
    }

    public void ResetActions()
    {
        CanMove = true;
        CanShoot = true;
        HasActions = true;
    }
}
