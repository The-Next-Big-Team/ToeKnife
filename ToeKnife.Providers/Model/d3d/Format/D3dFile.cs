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
                int primitiveType = 0;
                int group = -1;

                switch (directive)
                {
                    case 0: // d3d_model_primitive_begin
                        if (primitiveType != 0)
                        {
                            MessageBox.Show("Prim start without end in D3D Model");
                        }

                        primitiveType = (int)arg[0];

                        switch (primitiveType)
                        {
                            case 1: // pr_pointlist
                                break;

                            case 2: // pr_linelist
                            case 3: // pr_linestrip
                                MessageBox.Show("Line primitive type is not supported for D3D model.");
                                break;
                            case 4: // pr_trianglelist
                                break;

                            case 5: // pr_trianglestrip
                                MessageBox.Show("Triangle strip primitive type is not supported for D3D model.");
                                break;

                            case 6: // pr_trianglefan
                                MessageBox.Show("Triangle fan primitive type is not supported for D3D model.");
                                break;
                            default:
                                MessageBox.Show("Unsupported primitive type in D3D model.");
                                break;
                        }
                        break;

                    case 1: // d3d_model_primitive_end
                        primitiveType = 0;
                        break;

                    case 2: // d3d_model_vertex
                        createVertex = true;
                        origin[0] = arg[0];
                        origin[1] = arg[1];
                        origin[2] = arg[2];
                        break;

                    case 3: // d3d_model_vertex_colour
                        createVertex = true;
                        origin[0] = arg[0];
                        origin[1] = arg[1];
                        origin[2] = arg[2];
                        // color = arg[3]
                        // alpha = arg[4]
                        break;

                    case 4: // d3d_model_vertex_texture
                        createVertex = true;
                        origin[0] = arg[0];
                        origin[1] = arg[1];
                        origin[2] = arg[2];
                        uv[0] = arg[3];
                        uv[1] = arg[4];
                        break;

                    case 5: // d3d_model_vertex_texture_colour
                        createVertex = true;
                        origin[0] = arg[0];
                        origin[1] = arg[1];
                        origin[2] = arg[2];
                        uv[0] = arg[3];
                        uv[1] = arg[4];
                        // color = arg[5]
                        // alpha = arg[6]
                        break;

                    case 6: // d3d_model_vertex_normal
                        createVertex = true;
                        origin[0] = arg[0];
                        origin[1] = arg[1];
                        origin[2] = arg[2];
                        normal[0] = arg[3];
                        normal[1] = arg[4];
                        normal[2] = arg[5];
                        break;

                    case 7: // d3d_model_vertex_normal_colour
                        createVertex = true;
                        origin[0] = arg[0];
                        origin[1] = arg[1];
                        origin[2] = arg[2];
                        normal[0] = arg[3];
                        normal[1] = arg[4];
                        normal[2] = arg[5];
                        // color = arg[6]
                        // alpha = arg[7]
                        break;

                    case 8: // d3d_model_vertex_normal_texture
                        createVertex = true;
                        origin[0] = arg[0];
                        origin[1] = arg[1];
                        origin[2] = arg[2];
                        normal[0] = arg[3];
                        normal[1] = arg[4];
                        normal[2] = arg[5];
                        uv[0] = arg[6];
                        uv[1] = arg[7];
                        break;

                    case 9: // d3d_model_vertex_normal_texture_colour (most common.. only?)
                        createVertex = true;
                        origin[0] = arg[0];
                        origin[1] = arg[1];
                        origin[2] = arg[2];
                        normal[0] = arg[3];
                        normal[1] = arg[4];
                        normal[2] = arg[5];
                        uv[0] = arg[6];
                        uv[1] = arg[7];
                        // color = arg[8]
                        // alpha = arg[9]
                        break;

                    default:
                        MessageBox.Show("Unknown D3D directive");
                        break;
                }

                if (createVertex)
                {
                    if (primitiveType == 0)
                    {
                        //MessageBox.Show("Vertex outside of primitive begin/end in D3D model.");
                        break;
                    }
                    /*
                    // Invert Y axis.
                    origin[1] = -origin[1];
                    normal[1] = -normal[1];

                    loadMatrix.apply3x(origin);
                    loadMatrix.apply3(normal);

                    int newVert = -1;

                    // Reuse vertex if it already exists.
                    unsigned vcount = modelVertices.size();
                    for (unsigned v = 0; v < vcount; v++)
                    {
                        if (floatCompareVector(origin, modelVertices[v]->m_coord, 3)
                          && floatCompareVector(normal, &normalList[v][0], 3))
                        {
                            newVert = v;
                            break;
                        }
                    }

                    if (newVert == -1)
                    {
                        newVert = model->addVertex(origin[0], origin[1], origin[2]);
                        normalList.resize(newVert + 1);
                        normalList[newVert][0] = normal[0];
                        normalList[newVert][1] = normal[1];
                        normalList[newVert][2] = normal[2];
                    }

                    if (primitiveType == 4)
                    {
                        vertexIndices[unprocessedVerts] = newVert;
                        texCoords[unprocessedVerts][0] = uv[0];
                        texCoords[unprocessedVerts][1] = uv[1];
                        unprocessedVerts++;

                        if (unprocessedVerts == 3)
                        {
                            unprocessedVerts = 0;
                            int newTri = model->addTriangle(vertexIndices[2], vertexIndices[1], vertexIndices[0]);

                            model->setTextureCoords(newTri, 0, texCoords[2][0], 1.0 - texCoords[2][1]);
                            model->setTextureCoords(newTri, 1, texCoords[1][0], 1.0 - texCoords[1][1]);
                            model->setTextureCoords(newTri, 2, texCoords[0][0], 1.0 - texCoords[0][1]);

                            if (group == -1)
                            {
                                group = model->addGroup("Group");
                            }
                            model->addTriangleToGroup(group, newTri);
                        }
                    }
                    */
                }



            }

        }

    }
}
