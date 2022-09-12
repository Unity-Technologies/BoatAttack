using System.Collections;
using System.Collections.Generic;
using BoatAttack;
using UnityEditor;
using UnityEngine;

namespace BoatAttack
{
    [CustomEditor(typeof(RaceManager))]
    public class RaceManagerEditor : Editor
    {
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUILayout.LabelField("Current Data", EditorStyles.boldLabel);
            
            RaceManager.Race data = RaceManager.RaceData;

            //var manager = target as RaceManager;
            //data = manager.demoRaceData;
            
            if (data == null)
            {
                EditorGUILayout.HelpBox("Race Data invalid or null.", MessageType.Warning);
                return;
            }

            EditorGUILayout.LabelField("Game Type:", data.game.ToString());
            EditorGUILayout.LabelField("Race Type:", data.type.ToString());


            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            var index = 0;
            foreach (var boatData in data.boats)
            {
                EditorGUILayout.LabelField($"Boat {boatData.GetHashCode()}", $"Type {boatData.name}");

                // boat type
                var human = boatData.Human ? "Player" : "AI";
                EditorGUILayout.LabelField("Player", $"{boatData.playerName} ({human})");
                
                // colors
                EditorGUILayout.LabelField("Colors", EditorStyles.boldLabel);
                EditorGUILayout.ColorField(boatData.Livery.primaryColor);
                EditorGUILayout.ColorField(boatData.Livery.trimColor);
                index++;
            }
            EditorGUILayout.EndVertical();
        }
    }
}