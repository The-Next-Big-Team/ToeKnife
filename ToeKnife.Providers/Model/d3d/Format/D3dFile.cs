using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Windows.Forms;
using ToeKnife.Common.Extensions;
using ToeKnife.DataStructures;
using ToeKnife.FileSystem;
using ToeKnife.Packages;

namespace ToeKnife.Providers.Model.d3d.Format
{
    public class D3dFile
    {
        public D3dFile(IEnumerable<Stream> streams)
        {
            var readers = streams.Select(x => new BinaryReader(x, Encoding.ASCII)).ToList();
            if (streams.Count()==1 || streams.Count()==2)
            {
                try
                {
                    Read(readers);
                }
                finally
                {
                    readers.ForEach(x => x.Dispose());
                }
            }
        }

        public static bool CanRead(IFile file)
        {
            if (!file.Exists || file.Extension != "d3d") return false;
            

            try
            {
                var s = file.Open();
                var sr = new StreamReader(s, Encoding.UTF8);
                var version = sr.ReadLine();
                return version == "100";
            }
            catch
            {
                return false;
            }
        }


        public static D3dFile FromFile(IFile file)
        {
            var dir = file.Parent;
            var fname = file.NameWithoutExtension;

            var streams = new List<Stream>();

            try
            {
                streams.Add(file.Open());

                var texturefile = dir.GetFile(fname + ".png");
                if (texturefile?.Exists == true)
                {
                    streams.Add(texturefile.Open());
                } // add error texture here
                
                return new D3dFile(streams);
            }
            finally
            {
                foreach (var s in streams) s.Dispose();
            }
        }

        private void Read(IEnumerable<BinaryReader> readers)
        {
            var main = new List<BinaryReader>();
            var sequenceGroups = new Dictionary<string, BinaryReader>();

            var d3d_file = readers.ElementAt(0);
            var png_texture = readers.ElementAt(1);

            var sr = new StreamReader(d3d_file.BaseStream, Encoding.UTF8);

            var version = sr.ReadLine();
            var vertexes = Int32.Parse(sr.ReadLine());

            int unprocessedVerts = 0;
            int[] vertexIndices;
            double[][] texCoords;

            for (var i = 0; i < vertexes; i++)
            {
                var line = sr.ReadLine();
                var parts = line.Split(new string[] { "     " }, StringSplitOptions.None);

                if (parts.Length!=11)
                {
                    MessageBox.Show("Improper tokens on line in D3D Model");
                }
                var directive = Int32.Parse(parts[0]);
                var arg = new[] { Double.Parse(parts[1]), Double.Parse(parts[2]), Double.Parse(parts[3]), Double.Parse(parts[4]),
                    Double.Parse(parts[5]), Double.Parse(parts[6]), Double.Parse(parts[7]), Double.Parse(parts[8]), Double.Parse(parts[9]), Double.Parse(parts[10]) };
                //this smells bad

                bool createVertex = false;
                double[] origin = { 0, 0, 0 };
                double[] normal = { 0, 0, 0 };
                double[] uv = { 0, 0 };

                switch(directive)
                {
                    case 0:
                        break;
                }



            }

        }

    }
}
