using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.EventSystems;

namespace Assets._Scripts.Extensions
{
    static class EventSystemExtensions
    {
        public static T GetFirstUnderPointer<T>(this EventSystem system, PointerEventData eventData) where T : class
        {
            var result = new List<RaycastResult>();
            system.RaycastAll(eventData, result);

            foreach (var raycast in result)
                if (raycast.gameObject.TryGetComponent<T>(out T component))
                    return component;

            return null;
        }
    }
}
