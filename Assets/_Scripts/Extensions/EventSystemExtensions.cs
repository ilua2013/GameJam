using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets._Scripts.Extensions
{
    static class EventSystemExtensions
    {
        private static LayerMask _layerMask = 32;

        public static T GetFirstUnderPointer<T>(this EventSystem system, PointerEventData eventData) where T : class
        {
            var result = new List<RaycastResult>();
            system.RaycastAll(eventData, result);

            foreach (var raycast in result)
                if (raycast.gameObject.TryGetComponent<T>(out T component))
                    return component;

            return null;
        }

        public static bool IsMouseOverUI(this EventSystem system, PointerEventData eventData)
        {
            var result = new List<RaycastResult>();
            system.RaycastAll(eventData, result);

            for (int i = 1; i < result.Count; i++)
            {
                var layer = result[i].gameObject.layer;

                if (_layerMask != (_layerMask | (1 << layer)))
                {
                    result.RemoveAt(i);
                    i--;
                }
            }

            return result.Count > 0;
        }
    }
}
