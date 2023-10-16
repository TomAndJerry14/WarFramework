using Slate;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace War
{
    public static class CutsceneExtension
    {
        public static Dictionary<string, IResult> GetResult(this Cutscene cutscene)
        {
            Dictionary<string, IResult> results = new Dictionary<string, IResult>();
            foreach (var group in cutscene.groups)
            {
                var _group = group as ActorGroup;
                if (_group && _group.isActive)
                {
                    foreach (var track in _group.tracks)
                    {
                        var _track = track as SlateSkillTrack;
                        if (_track && _track.isActive)
                        {
                            foreach (var clip in _track.clips)
                            {
                                var _clip = clip as SlateSkillClip;
                                if (_clip && _clip.isActive)
                                {
                                    var result = _clip.GetResult();
                                    if (result is HitResult)
                                        results.Add("hitResult", result);
                                    else if (result is ReceiveInputResult)
                                        results.Add("receiveInputResult", result);
                                }
                            }
                        }
                    }
                }
            }
            return results;
        }
    }
}