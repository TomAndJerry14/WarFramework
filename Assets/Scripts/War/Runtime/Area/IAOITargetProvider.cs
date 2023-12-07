using UnityEngine;

namespace War
{
    public interface IAOITargetProvider
    {
        public Fighter[] GetAOITarger(Vector2 pos);
    }
}