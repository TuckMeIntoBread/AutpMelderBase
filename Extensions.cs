﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ff14bot.Enums;
using LlamaLibrary.JsonObjects;

namespace AutoMelder
{
    public static class Extensions
    {
        public static IEnumerable<Control> GetAllControls(this Control root)
        {
            var stack = new Stack<Control>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                Control next = stack.Pop();
                foreach (Control child in next.Controls)
                {
                    stack.Push(child);
                }

                yield return next;
            }
        }

        public static EquipmentSlot GetSlotByType(string type)
        {
            switch (type)
            {
                case "mainhand":
                    return EquipmentSlot.MainHand;
                case "offhand":
                    return EquipmentSlot.OffHand;
                case "head":
                    return EquipmentSlot.Head;
                case "chest":
                    return EquipmentSlot.Body;
                case "hands":
                    return EquipmentSlot.Hands;
                case "legs":
                    return EquipmentSlot.Legs;
                case "feet":
                    return EquipmentSlot.Feet;
                case "ears":
                    return EquipmentSlot.Earring;
                case "neck":
                    return EquipmentSlot.Necklace;
                case "wrist":
                    return EquipmentSlot.Bracelet;
                case "ringLeft":
                    return EquipmentSlot.Ring1;
                case "ringRight":
                    return EquipmentSlot.Ring2;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), $"Unknown EquipmentSlot Type: {type}");
            }
        }

        public static string ToRomanString(this MateriaItem materiaItem)
        {
            return $"{materiaItem.ItemName} {ToRomanNumeral.ArabicToRoman(materiaItem.Tier)} +{materiaItem.Value}";
        }
    }
}