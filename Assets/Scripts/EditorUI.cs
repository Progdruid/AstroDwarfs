using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditorUI : MonoBehaviour
{
    public Dropdown StructureSelect;
    public Editor Editor;

    private void Start()
    {
        List<Dropdown.OptionData> Options = new List<Dropdown.OptionData>();
        foreach (StructureType str in IndexTable.GameStructures)
            Options.Add(new Dropdown.OptionData(str.Name, str.sprite));

        StructureSelect.AddOptions(Options);
    }

    public void OnSelectedStructureChange (int ID)
    {
        Editor.SetSelected(ID);
    }

    public void OnSaveButton ()
    {
        Editor.Save();
    }

    private void Update()
    {
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left");
            Editor.CreateStructure((int)mousepos.x, (int)mousepos.y);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right");
            Editor.DeleteStructure((int)mousepos.x, (int)mousepos.y);
        }
    }
}
