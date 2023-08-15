using UnityEditor;
using UnityEngine;
using War;

[CreateAssetMenu(menuName ="Skill/Create skill data")]
public class SkillSerializedObject : ScriptableObject
{
    public SkillData skillData;
}