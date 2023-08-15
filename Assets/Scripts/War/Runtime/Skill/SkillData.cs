using Sirenix.OdinInspector;
using System;
namespace War
{
    [Serializable]
    public class SkillData
    {
        public int id = -1;
        public string name;

        public AreaData data_area;

        public float damage;

        /// <summary>
        /// ÃæÏòµĞÈË
        /// </summary>
        public bool face_to_enemy;
    }
}