#if UNITY_2022_2_OR_NEWER
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

[CustomEditor(typeof(SRPTestSceneAsset))]
public class SRPTestSceneAssetEditor : Editor
{
    VisualElement m_Root;
    VisualElement m_SceneContainer;
    VisualElement m_WarningElement;

    private List<ListView> m_ListViews = new List<ListView>();

    SerializedProperty m_TestDatas;

    private void OnEnable()
    {
        m_TestDatas = serializedObject.FindProperty("testDatas");
    }

    void UpdateUI()
    {
        m_SceneContainer.Clear();
        serializedObject.Update();
        m_TestDatas = serializedObject.FindProperty("testDatas");
        for (int i = 0; i < m_TestDatas.arraySize; i++)
        {
            var property = m_TestDatas.GetArrayElementAtIndex(i);
            CreateSceneData(property, i);
        }

        List<string> disabledScenes = new List<string>();
        var scenes = EditorBuildSettings.scenes;
        foreach (EditorBuildSettingsScene scene in scenes)
        {
            if (!scene.enabled)
            {
                disabledScenes.Add(Path.GetFileNameWithoutExtension(scene.path));
            }
        }

        m_WarningElement = new VisualElement();
        // What about scenes that are not added? 
        Label warningText = new Label("Disabled Scenes in Editor Build Settings");
        m_WarningElement.Add(warningText);
        foreach (string disabledScene in disabledScenes)
        {
            Label sceneName = new Label(disabledScene);
            m_WarningElement.Add(sceneName);
        }
    }

    public sealed override VisualElement CreateInspectorGUI()
    {
        m_Root = new VisualElement();
        m_SceneContainer = new VisualElement();
        UpdateUI();

        // Buttons to add and remove to / from bottom of list
        var buttonContainer = new VisualElement {style = {flexShrink = 1, alignSelf = Align.FlexEnd, flexDirection = FlexDirection.Row}};

        var addButton = new Button(OnAddSceneClicked)
        {
            text = "Add Scene Data"
        };

        m_Root.Add(m_SceneContainer);

        buttonContainer.Add(addButton);
        m_Root.Add(buttonContainer);

        m_Root.Bind(serializedObject);
        
        m_Root.Add(m_WarningElement);
        return m_Root;
    }

    void OnAddSceneClicked()
    {
        m_TestDatas.InsertArrayElementAtIndex(m_TestDatas.arraySize);
        var property =  m_TestDatas.GetArrayElementAtIndex(m_TestDatas.arraySize - 1);
        CreateSceneData(property, m_TestDatas.arraySize-1);
        serializedObject.ApplyModifiedProperties();
    }

    void CreateSceneData(SerializedProperty property, int index)
    {
        var ve = CreateSceneGUIProperty(property, index) as BindableElement;
        m_SceneContainer.Add(ve);
    }

    VisualElement CreateObjectField()
    {
        var padding = 2;
        return new ObjectField {objectType = typeof(RenderPipelineAsset), style = { paddingBottom = padding, paddingLeft = padding, paddingRight = padding, paddingTop = padding}};
    }

    VisualElement CreateSceneGUIProperty(SerializedProperty property, int index)
    {
        var foldout = new Foldout {text = "Scene", name = index.ToString()};
        var headerContainer = new VisualElement{style = {flexShrink = 1, alignSelf = Align.FlexEnd, flexDirection = FlexDirection.Row}};

        // ObjectField for scene which also works as a foldout
        var sceneField = new ObjectField {objectType = typeof(SceneAsset), bindingPath = $"{nameof(SRPTestSceneAsset.TestData.scene)}"};
        sceneField.AddToClassList("unity-base-field__input");
        sceneField.RegisterCallback<MouseDownEvent>(evt => evt.StopPropagation());
        sceneField.RegisterCallback<MouseUpEvent>(evt => evt.StopPropagation());

        sceneField.RegisterCallback<ChangeEvent<Object>>((evt) =>
        {
            var scenes = EditorBuildSettings.scenes;
            string assetPath = AssetDatabase.GetAssetPath(evt.newValue);
            bool sceneAlreadyAdded = false;
            
            foreach (EditorBuildSettingsScene settingsScene in scenes)
            {
                if (settingsScene.path == assetPath)
                {
                    sceneAlreadyAdded = true;
                    break;
                }
            }

            if (!sceneAlreadyAdded)
            {
                var editorBuildSettingsScene = new EditorBuildSettingsScene(assetPath, true);
                var editorBuildSettingsScenes = scenes.Append(editorBuildSettingsScene);
                EditorBuildSettings.scenes = editorBuildSettingsScenes.ToArray();
            }
            
            property.FindPropertyRelative("path").stringValue = assetPath;
            serializedObject.ApplyModifiedProperties();
        });
        
        var removeButton = new Button(() =>
        {
            m_TestDatas.DeleteArrayElementAtIndex(index);
            serializedObject.ApplyModifiedProperties();
            UpdateUI();
        })
        {
            style= {marginLeft = 5, paddingLeft = 5},
            tooltip = "Delete Entry"
        };
        
        removeButton.Add(new Image
        {
            image =  EditorGUIUtility.Load("TreeEditor.Trash") as Texture2D,
            pickingMode = PickingMode.Ignore
        });

        // Toggle for enabling the scene
        var toggle = new Toggle {value = true, bindingPath = $"{nameof(SRPTestSceneAsset.TestData.enabled)}"};

        headerContainer.Add(toggle);
        headerContainer.Add(sceneField);
        headerContainer.Add(removeButton);

        // The Visual Elements that will hold all the SRP Assets
        var listView = new ListView{name = "srp-list",
                                    showBorder = true,
                                    showFoldoutHeader = true,
                                    showAddRemoveFooter = true,
                                    headerTitle = "SRP Assets",
                                    horizontalScrollingEnabled = false,
                                    showAlternatingRowBackgrounds = AlternatingRowBackground.All,
                                    bindingPath = $"{nameof(SRPTestSceneAsset.TestData.srpAssets)}",
                                    reorderable = false,
                                    };
        m_ListViews.Add(listView);
        listView.makeItem = CreateObjectField;
        foldout.Add(listView);
        foldout.hierarchy[0].Add(headerContainer);

        foldout.BindProperty(property);
        
        return foldout;
    }
}
#endif
