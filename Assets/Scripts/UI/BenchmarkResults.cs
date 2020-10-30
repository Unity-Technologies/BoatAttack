using System.Collections.Generic;
using System.Linq;
using BoatAttack.Benchmark;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BenchmarkResults : MonoBehaviour
{
    public Sprite uiPanel;
    
    // Raw Data
    private List<PerfResults> benchFiles;
    
    // File/Result
    public TMP_Dropdown fileDropdown;
    public TMP_Dropdown resultDropdown;

    // Info
    public RectTransform[] infoPanel;
    
    // data
    public RectTransform dataPanel;
    
    public void PrepResultsPage()
    {
        // load files
        benchFiles = Benchmark.LoadAllBenchmarkStats();
        
        fileDropdown.onValueChanged.AddListener(PopulateResultDropdown);
        resultDropdown.onValueChanged.AddListener(PopulateResults);
        
        PopulateFileDropdown();
    }

    private void PopulateFileDropdown()
    {
        fileDropdown.options = benchFiles.Select(results => new TMP_Dropdown.OptionData {text = results.fileName}).ToList();
        PopulateResultDropdown(fileDropdown.value);
    }

    private void PopulateResultDropdown(int file)
    {
        resultDropdown.value = 0;
        resultDropdown.options = benchFiles[file].perfStats.Select(results => new TMP_Dropdown.OptionData {text = results.info.BenchmarkName}).ToList();
        PopulateResults(resultDropdown.value);
    }

    private void PopulateResults(int index)
    {
        Cleanup();
        
        var result = benchFiles?[fileDropdown.value]?.perfStats?[index];
        
        PopulateInfoPanel(result);
        PopulateDataPanel(result);
    }

    private void PopulateInfoPanel(PerfBasic result = null)
    {
        var props = typeof(TestInfo).GetFields();

        for (var i = 0; i < props.Length; i++)
        {
            var prop = props[i];

            var info = result != null ? prop.GetValue(result.info) : "---";
            var text = $"<b>{prop.Name}</b>\n<i>   {info}</i>";
            CreateTextObject(text, infoPanel[i % 2 == 0 ? 0 : 1], prop.Name);
        }
    }

    private void PopulateDataPanel(PerfBasic result)
    {
        var avg = result.RunData.Select(run => run.AvgMs).ToArray();
        var min = result.RunData.Select(run => run.MinFrame).ToArray();
        var max = result.RunData.Select(run => run.MaxFrame).ToArray();

        var table = CreateTable(result.RunData.Length + 1, 4, dataPanel, 10);

        table[0][0].text = "FrameTime";
        table[0][1].text = "Avg";
        table[0][2].text = "Min";
        table[0][3].text = "Max";
        
        for (var run = 1; run < table.Length; run++)
        {
            table[run][0].text = $"Run {run}";
            table[run][1].text = $"{avg[run-1]:F2}ms";
            table[run][2].text = $"{min[run-1].ms:F2}ms";
            table[run][3].text = $"{max[run-1].ms:F2}ms";
        }
    }

    private void Cleanup()
    {
        foreach (var child in infoPanel)
        {
            Utility.SafeDestroyChildren(child);
        }
        Utility.SafeDestroyChildren(dataPanel);
    }

    private TextMeshProUGUI CreateTextObject(string text, Transform parent = null, string name = "text-object")
    {
        var entry = new GameObject(name);
        entry.transform.SetParent(parent, false);
        // text
        var gui = entry.AddComponent<TextMeshProUGUI>();
        gui.fontSize = 14.0f;
        gui.text = text;
        gui.enableWordWrapping = false;
        gui.overflowMode = TextOverflowModes.Ellipsis;
        gui.lineSpacing = 6.0f;
        gui.raycastTarget = false;
        return gui;
    }

    private TextMeshProUGUI[][] CreateTable(int x, int y, Transform container, int padding = 5)
    {
        //// Setup row objects (for styling) ////
        var tableRowsGo = new GameObject("Rows", typeof(VerticalLayoutGroup));
        Utility.ParentAndFillRectTransform(tableRowsGo.transform, container);
        // row layout
        var rowControl = tableRowsGo.GetComponent<VerticalLayoutGroup>();
        rowControl.padding = new RectOffset(padding, padding, padding, padding);
        //// Create text objects ////
        for (var a = 0; a < y; a++)
        {
            var row = new GameObject($"row{a}", typeof(RectTransform));
            row.transform.SetParent(tableRowsGo.transform, false);
            AddTableBar(row, a == 0);
        }

        //// Setup text array ////
        var table = new TextMeshProUGUI[x][];
        for (var index = 0; index < table.Length; index++)
        {
            table[index] = new TextMeshProUGUI[y];
        }
        
        //// Setup Main table ////
        var tableGo = new GameObject("Table", typeof(HorizontalLayoutGroup));
        Utility.ParentAndFillRectTransform(tableGo.transform, container);
        // column layout
        var columnControl = tableGo.GetComponent<HorizontalLayoutGroup>();
        columnControl.padding = new RectOffset(padding, padding, padding, padding);
        
        //// Create text objects ////
        for (var i = 0; i < x; i++)
        {
            var column = new GameObject($"column{i}");
            column.transform.SetParent(tableGo.transform, false);
            column.AddComponent<VerticalLayoutGroup>();
            for (var j = 0; j < y; j++)
            {
                table[i][j] = CreateTextObject($"c{i}-r{j}", column.transform, $"row{j}");
                table[i][j].alignment = TextAlignmentOptions.Center;
            }
            if(i == 0)
                AddTableBar(column);
        }

        return table;
    }

    private void AddTableBar(GameObject go, bool visible = true)
    {
        var img = go.AddComponent<Image>();
        if (visible)
        {
            img.color = new Color(0f, 0.1f, 0.2f, 0.25f);
        }
        else
        {
            img.color = new Color(0, 0, 0, 0);
        }
        img.type = Image.Type.Sliced;
        img.sprite = uiPanel;
        img.raycastTarget = false;
    }
}
