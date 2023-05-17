using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositioningManager : MonoBehaviour
{
    [SerializeField] GameObject[] objToTake;
    [SerializeField] LayerMask mask;

    Coroutine buttonPress;

    public void ButtonPress(int i)
    {
        if (buttonPress != null)
        {
            StopCoroutine(buttonPress);
            buttonPress = null;
        }
        buttonPress = StartCoroutine(ObjPlace(objToTake[i]));
    }

    IEnumerator ObjPlace(GameObject obj)
    {
        bool isClicked = false;
        while (!isClicked)
        {
            yield return null;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100f, mask))
                {
                    isClicked = true;
                    ColumnManager selectedColumn = hit.transform.GetComponent<ColumnManager>();
                    Vector3 pos = selectedColumn.positionateTurret();
                    GameObject objToAdd = Instantiate(obj, pos, Quaternion.identity);
                    selectedColumn.AddTurret(objToAdd);
                }
            }
        }
    }
}
