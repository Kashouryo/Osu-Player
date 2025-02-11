﻿using System;
using Milkitic.OsuPlayer.LyricExtension.Model;
using Milkitic.OsuPlayer.LyricExtension.SourcePrivoder.Base;

namespace Milkitic.OsuPlayer.LyricExtension
{
    class LyricProvider
    {
        public ProvideTypeEnum ProvideType { get; set; }

        private readonly SourceProviderBase _sourceProvider;

        public LyricProvider(SourceProviderBase provider, ProvideTypeEnum provideType)
        {
            _sourceProvider = provider;
            ProvideType = provideType;
        }

        public Lyric GetLyric(string artist, string title, int duration)
        {
            Lyric lyric;
            switch (ProvideType)
            {
                case ProvideTypeEnum.PreferBoth:
                    var transLyrics = InnerGetLyric(artist, title, duration, true);
                    var rawLyrics = InnerGetLyric(artist, title, duration, false);
                    Console.WriteLine(@"翻译歌词: {0}, 原歌词: {1}.", transLyrics != null, rawLyrics != null);
                    lyric = rawLyrics + transLyrics;
                    break;
                default:
                    lyric = InnerGetLyric(artist, title,  duration, false);
                    if (ProvideType == ProvideTypeEnum.PreferTranslated)
                    {
                        var tmp = InnerGetLyric(artist, title, duration, true);
                        if (tmp != null)
                            lyric = tmp;
                    }
                    break;
            }

            return lyric;
        }

        private Lyric InnerGetLyric(string artist, string title, int duration, bool useTranslated, bool useCache = false)
        {
            if (useCache && TryGetCache(title, artist, duration, useTranslated, out Lyric cached))
            {
                return cached;
            }

            Lyric lyric = _sourceProvider?.ProvideLyric(artist, title, duration, useTranslated);
            if (useCache) WriteCache(title, artist, duration, lyric);
            return lyric;
        }

        private static void WriteCache(string title, string artist, int duration, Lyric lyric)
        {
            throw new NotImplementedException();
        }

        private static bool TryGetCache(string title, string artist, int duration, bool useTranslated, out Lyric lyric)
        {
            throw new NotImplementedException();
        }

        public enum ProvideTypeEnum
        {
            Original, PreferTranslated, PreferBoth
        }
    }
}
