using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yarn.Unity
{
    public class CustomColorView : Yarn.Unity.DialogueViewBase
    {
        [Serializable]
        public class CharacterColorData
        {
            public string characterName;
            public Color displayColor = Color.black;
        }

        [SerializeField] Color defaultColor = Color.black;

        [SerializeField] CharacterColorData[] colorData;

        [SerializeField] List<TMPro.TextMeshProUGUI> lineTexts = new List<TMPro.TextMeshProUGUI>();

        public override void RunLine(LocalizedLine dialogueLine, Action onDialogueLineFinished)
        {
            var characterName = dialogueLine.CharacterName;

            if (!GameObject.Find("DialogueRunner").GetComponent<Variables>().GetAtmos())
            {
                defaultColor = Color.red;
            }

            Color colorToUse = defaultColor;

            

            if (string.IsNullOrEmpty(characterName) == false)
            {
                foreach (var color in colorData)
                {
                    if (color.characterName.Equals(characterName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        colorToUse = color.displayColor;
                        break;
                    }
                }
            }

            foreach (var text in lineTexts)
            {
                text.color = colorToUse;
            }

            onDialogueLineFinished();
        }
    }
}
