using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using UnityEngine;

public class ColumnManager : MonoBehaviour
{
    List<GameObject> turrets = new List<GameObject>();

    public void AddTurret(GameObject t)
    {
        turrets.Add(t);
    }

    public Vector3 positionateTurret()
    {
        if (turrets.Count > 0)
        {
            return new Vector3(turrets[turrets.Count - 1].transform.position.x,
                turrets[turrets.Count - 1].transform.position.y + 1,
                turrets[turrets.Count - 1].transform.position.z);
        }
        else
        {
            return new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        }
    }
}
