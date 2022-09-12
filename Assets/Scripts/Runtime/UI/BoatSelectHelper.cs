using System;
using System.Collections;
using System.Collections.Generic;
using BoatAttack;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class BoatSelectHelper : MonoBehaviour
{
    public BoatSelectItem _selectedItem = BoatSelectItem.BoatType;
    private int _currentBoat;
    public int _colorA = 0;
    private Color[] _colors;
    public int _colorB = 0;
    private GameObject _currentBoatMesh;

    [Header("Boat Panel")]
    public TextMeshProUGUI title;
    public TextMeshProUGUI titleB;
    public Transform boatModelPivot;
    public GenericRotation rotationScript;
    
    [Header("Color Picker")]
    public RectTransform colorsA;
    public RectTransform colorsB;
    public GameObject colorSwatchPrefab;
    private List<ColorSwatch> _swatches = new List<ColorSwatch>();

    [Header("Stats")]
    public TextMeshProUGUI statPower;
    public TextMeshProUGUI statEngine;
    public TextMeshProUGUI statWeight;
    public TextMeshProUGUI statCylinder;

    public void Init()
    {
        if (Application.isPlaying)
        {
            // load boat meshes for menu
            foreach (var so in AppSettings.Instance.boats)
            {
                if(so._data.boatMesh.Asset == null)
                    so._data.boatMesh.LoadAssetAsync<GameObject>();
            }
        }
    }

    private void Start()
    {
        UpdateBoat(0);
        PopulateColorSwatches();
    }

    private void Update()
    {
        if (Gamepad.current != null && Gamepad.current.rightStick.x.IsPressed())
        {
            rotationScript.rotationVector.y += Gamepad.current.rightStick.x.ReadValue() * 10f;
        }
        else
        {
            rotationScript.rotationVector.y += 1f;
        }

        rotationScript.rotationVector.y = Mathf.Clamp(rotationScript.rotationVector.y, -100f, 100f);

        if (!_colorA.Equals(ColorSwatch.activeIndexA))
        {
            _colorA = ColorSwatch.activeIndexA;
            UpdateBoatColors();
        }
        if (!_colorB.Equals(ColorSwatch.activeIndexB))
        {
            _colorB = ColorSwatch.activeIndexB;
            UpdateBoatColors();
        }
    }

    private void PopulateColorSwatches()
    {
        for (var index = 0; index < ConstantData.GetPalette.Length; index++)
        {
            var color = ConstantData.GetPalette[index];
            _swatches.Add(CreateSwatch(color, 0, index));
            _swatches.Add(CreateSwatch(color, 1, index));
        }
        Invoke(nameof(UpdateLayout), Time.deltaTime);
    }

    private void UpdateLayout()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)colorsA.parent);
    }

    private ColorSwatch CreateSwatch(Color color, int group, int index)
    {
        var obj = Instantiate(colorSwatchPrefab, group == 0 ? colorsA : colorsB);

        if (!obj.TryGetComponent(out ColorSwatch swatch)) return null;
        
        swatch.SetColorSwatch(color, index, group);
        return swatch;
    }
    
    public void Navigate(BaseEventData data)
    {
        var axisData = data as AxisEventData;

        switch (axisData!.moveDir)
        {
            case MoveDirection.Left:
                Prev();
                break;
            case MoveDirection.Right:
                Next();
                break;
            case MoveDirection.Up:
                PrevItem();
                break;
            case MoveDirection.Down:
                NextItem();
                break;
        }
    }

    public void Next()
    {
        switch (_selectedItem)
        {
            case BoatSelectItem.BoatType:
                NextBoat();
                break;
            case BoatSelectItem.ColorA:
                SetColor(1, ref _colorA, 0);
                break;
            case BoatSelectItem.ColorB:
                SetColor(1, ref _colorB, 1);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    public void Prev()
    {
        switch (_selectedItem)
        {
            case BoatSelectItem.BoatType:
                PrevBoat();
                break;
            case BoatSelectItem.ColorA:
                SetColor(-1, ref _colorA, 0);
                break;
            case BoatSelectItem.ColorB:
                SetColor(-1, ref _colorB, 1);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void NextItem()
    {
        _selectedItem = GetSelectedItem(1);
    }
    
    private void PrevItem()
    {
        _selectedItem = GetSelectedItem(-1);
    }

    private BoatSelectItem GetSelectedItem(int index)
    {
            var i = (int)Mathf.Repeat((int)_selectedItem + index, Enum.GetNames(typeof(BoatSelectItem)).Length);
            return (BoatSelectItem)i;
    }
    
    private void NextBoat()
    {
        _currentBoat = (int)Mathf.Repeat(_currentBoat + 1, AppSettings.Instance.boats.Length);
        UpdateBoat();
    }
    
    private void PrevBoat()
    {
        _currentBoat = (int)Mathf.Repeat(_currentBoat - 1, AppSettings.Instance.boats.Length);
        UpdateBoat();
    }

    private void UpdateBoat()
    {
        UpdateBoat(_currentBoat);
    }
    
    private void UpdateBoat(int index)
    {
        var data = AppSettings.Instance.boats[index]._data;
        
        // boat name display
        title.text = titleB.text = data.name;
        
        // boat mesh
        if(_currentBoatMesh)
            Destroy(_currentBoatMesh);
        _currentBoatMesh = Instantiate(data.boatMesh.Asset, boatModelPivot) as GameObject;
        
        // stats
        statPower.text = $"{data.stats.power}bhp";
        statEngine.text = $"{data.stats.engine}cc";
        statWeight.text = $"{data.stats.weight}kg";
        statCylinder.text = $"{data.stats.cylinders}";
        
        // update colors
        UpdateBoatColors();
    }

    public void SetBoat(BoatData data)
    {
        RaceManager.SetHull(0, data);
    }
    
    private void SetColor(int offset, ref int color, int group)
    {
        color = (int)Mathf.Repeat(color + offset, ConstantData.GetPalette.Length);
        switch (group)
        {
            case 0:
                ColorSwatch.activeIndexA = color;
                UpdatePrimaryColor(color);
                break;
            case 1:
                ColorSwatch.activeIndexB = color;
                UpdateTrimColor(color);
                break;
        }
    }

    private void UpdatePrimaryColor(int index) => UpdateBoatColor(index, true);

    private void UpdateTrimColor(int index) => UpdateBoatColor(index, false);

    private void UpdateBoatColors()
    {
        UpdateBoatColor(_colorA, true);
        UpdateBoatColor(_colorB, false);
    }
    
    private void UpdateBoatColor(int index, bool primary)
    {
        // update racedata
        if (primary)
        {
            RaceManager.RaceData.boats[0].Livery.primaryColor = ConstantData.GetPaletteColor(index);
        }
        else
        {
            RaceManager.RaceData.boats[0].Livery.trimColor = ConstantData.GetPaletteColor(index);
        }
            
        // update menu boats
        var renderers = boatModelPivot.GetComponentsInChildren<MeshRenderer>(true);
        foreach (var rend in renderers)
        {
            rend.material.SetColor(primary ? "_Color1" : "_Color2", ConstantData.GetPaletteColor(index));
        }
    }

    public enum BoatSelectItem
    {
        BoatType,
        ColorA,
        ColorB,
    }
}
