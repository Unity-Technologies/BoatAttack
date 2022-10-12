using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BoatAttack.UI
{
    public class PlayerListEntry : MonoBehaviour
    {
        public TextMeshProUGUI playername;
        public Image face;
        private Material outline;
        public Color playerFace;
        public Color otherFace;
        public PlayerMapMarker pmm;
        
        private BoatData _data;
        private float yPosition = 0f;
        private float yPosVel;

        public void Setup(BoatData player, bool owner = false)
        {
            _data = player;
            playername.text = player.playerName;
            face.color = owner ? playerFace : otherFace;
            face.material.color = owner ? Color.white : Color.black;
            pmm.Setup(player);
        }

        private void LateUpdate()
        {
            yPosition = Mathf.SmoothDamp(yPosition, -_data.Boat.Place * 80f, ref yPosVel, 0.2f);
            
            ((RectTransform)transform).anchoredPosition = Vector2.up * yPosition;
        }
    }
}