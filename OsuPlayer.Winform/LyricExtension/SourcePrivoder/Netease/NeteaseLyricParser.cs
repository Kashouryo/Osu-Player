﻿using System.Collections.Generic;
using System.Text.RegularExpressions;
using Milkitic.OsuPlayer.LyricExtension.Model;
using Milkitic.OsuPlayer.LyricExtension.SourcePrivoder.Base;

namespace Milkitic.OsuPlayer.LyricExtension.SourcePrivoder.Netease
{
    public class NeteaseLyricParser : LyricParserBase
    {
        private static readonly Regex LyricRegex = new Regex(@"\[(\d{2}\d*)\:(\d{2})\.(\d*)?\](.*?)(\r)?\n");

        public override Lyric Parse(string content)
        {
            List<Sentence> sentenceList = new List<Sentence>();

            var match = LyricRegex.Match(content);

            while (match.Success)
            {
                int min = int.Parse(match.Groups[1].Value.ToString()), sec = int.Parse(match.Groups[2].Value.ToString()), msec = int.Parse(match.Groups[3].Value.ToString());

                string cont = match.Groups[4].Value.ToString().Trim();

                int time = min * 60 * 1000 + sec * 1000 + msec;

                sentenceList.Add(new Sentence(cont, time));

                match = match.NextMatch();
            }

            sentenceList.Sort();

            return new Lyric(sentenceList);
        }
    }
}
