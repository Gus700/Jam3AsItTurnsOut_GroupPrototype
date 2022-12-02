using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitIndicator : MonoBehaviour
{
    [Tooltip("How high should the indicator rest above the active unit")]
    [SerializeField] float yOffset;

    public void TargetActiveUnit(Vector3 position)
    {
        Vector3 target = position;
        target.y += yOffset;
        transform.position = target;
    }
}
