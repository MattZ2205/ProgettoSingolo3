using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PositioningManager : MonoBehaviour
{
    [SerializeField] GameObject[] objToTake;
    [SerializeField] LayerMask mask;
    [SerializeField] float initialTime;
    [SerializeField] TMP_Text[] texts;

    bool isTextsSets = true;
    float cooldown = 0;
    string[] initialTexts;
    Coroutine buttonPress;
    Button buttonPressed;

    private void Start()
    {
        initialTexts = new string[texts.Length];
        for (int i = 0; i < initialTexts.Length; i++)
        {
            initialTexts[i] = texts[i].text;
        }
    }

    private void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown > 0)
        {
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i].text = Mathf.Round(cooldown).ToString();
            }
        }
        else if (!isTextsSets)
        {
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i].text = initialTexts[i];
            }
            ChangeButtonStatus(true);
            isTextsSets = true;
        }
    }

    public void ColorButtonPress(Button bP)
    {
        buttonPressed = bP;
    }

    public void ButtonPress(int i)
    {
        ChangeButtonStatus(false);
        buttonPressed.GetComponent<Image>().color = Color.yellow;

        if (buttonPress != null)
        {
            StopCoroutine(buttonPress);
            buttonPress = null;
        }
        if (cooldown < 0)
        {
            if (i < 3) buttonPress = StartCoroutine(ObjPlace(objToTake[i]));
            else buttonPress = StartCoroutine(ObjPlace(objToTake[i], i));
        }
    }

    IEnumerator ObjPlace(GameObject obj, int i = -1)
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
                    if (i == -1) selectedColumn.AddTurret(objToAdd);
                    else selectedColumn.AddPowerUp(objToAdd, i);
                }
            }
        }
        buttonPressed.GetComponent<Image>().color = Color.white;
        cooldown = initialTime;
        isTextsSets = false;
    }

    void ChangeButtonStatus(bool status)
    {
        foreach (Button b in Selectable.allSelectablesArray)
        {
            b.interactable = status;
        }
    }
}
