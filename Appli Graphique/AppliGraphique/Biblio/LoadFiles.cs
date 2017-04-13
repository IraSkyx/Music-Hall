using System;
using System.Collections.Generic;
using System.IO;

namespace Biblio
{
    public class LoadFiles
    {
        public List<Musique> AllMusic;

        public LoadFiles()
        {
            AllMusic = new List<Musique>();
        }

        public void CopyAllFiles()
        {
            CopyDirectory();
        }

        public void CopyDirectory()
        {
            Directory.CreateDirectory(@"\resources");
            foreach (var file in Directory.GetFiles( @"\..\..\..\resources"))
            {
                File.Copy(file, Path.Combine(@"\resources", Path.GetFileName(file)));
            }
        }

        public void Load()
        {
            using(StreamReader str = new StreamReader("\resources.File.txt"))
            {
                
            }       
        }
    }
}
