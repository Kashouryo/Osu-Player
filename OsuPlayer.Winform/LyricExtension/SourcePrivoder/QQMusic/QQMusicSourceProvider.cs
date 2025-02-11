﻿using System.Collections.Generic;
using System.Linq;
using Milkitic.OsuPlayer.LyricExtension.Model;
using Milkitic.OsuPlayer.LyricExtension.SourcePrivoder.Base;

namespace Milkitic.OsuPlayer.LyricExtension.SourcePrivoder.QQMusic
{
    public class QqMusicSourceProvider
        : SourceProviderBase<Song, QqMusicSearch, QqMusicLyricDownloader, QqMusicLyricParser>
    {
        public override Lyric PickLyric(string artist, string title, int time, List<Song> searchResult,
            bool requestTransLyrics, out Song pickedResult)
        {
            pickedResult = null;
            Lyric result = base.PickLyric(artist, title, time, searchResult, requestTransLyrics, out Song tempPickedResult);
            if (result != null)
            {
                switch (result.LyricSentencs.Count)
                {
                    case 0:
                        // 无任何歌词在里面
                        return null;
                    case 1:
                        var firstSentence = result.LyricSentencs.First();
                        if (firstSentence.StartTime <= 0 && firstSentence.Content.Contains("纯音乐") &&
                            firstSentence.Content.Contains("没有填词"))
                        {
                            // 纯音乐或无歌词
                            return null;
                        }
                        break;
                }
            }

            pickedResult = tempPickedResult;
            return result;
        }
    }
}
