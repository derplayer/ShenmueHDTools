using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using ShenmueDKSharp.Files.Models;
using ShenmueDKSharp.Files.Images;

namespace ShenmueHDTools.GUI.Controls.View3D
{
    public partial class View3D : GLControl
    {
        private int m_drawMode = 0;
        private bool m_wireframe;

        private Vector3 m_modelCenter;
        private ModelNode m_modelNode;
        private Camera m_camera;
        private Timer m_timer;

        private bool m_isNode;
        private bool m_handleDestoryed;
        private bool m_loaded;
        private int m_program;
        private int m_vertexArray;
        private int m_buffer;
        private int m_texture;
        private Dictionary<string, int> m_uniformLocations = new Dictionary<string, int>();

        private uint[] m_textures;
        private List<float[]> m_verticesFloat = new List<float[]>();
        private List<Matrix4> m_verticesMatrices = new List<Matrix4>();
        private List<Texture> m_verticesTextures = new List<Texture>();
        private List<Color4> m_verticesColors = new List<Color4>();
        private List<TextureWrapMode> m_verticesWrapModes = new List<TextureWrapMode>();
        private List<bool> m_verticesTransparent = new List<bool>();
        private List<bool> m_verticesUnlit = new List<bool>();
        private PrimitiveType m_primitiveType = PrimitiveType.Triangles;

        public enum RenderMode
        {
            Shaded,
            Flat,
            Normal,
            UV,
            Color
        }

        public View3D()
        {
            InitializeComponent();

            m_timer = new Timer();
            m_timer.Interval = 20;
            m_timer.Tick += m_timer_Tick;
            m_camera = new Camera(this);

            HandleDestroyed += View3D_HandleDestroyed;
        }

        private void View3D_HandleDestroyed(object sender, EventArgs e)
        {
            m_timer.Stop();
            m_handleDestoryed = true;
        }

        public void SetZBuffer(float zNear, float zFar)
        {
            m_camera.ZNear = zNear;
            m_camera.ZFar = zFar;
            m_camera.UpdateProjection();
        }

        public void SetWireframe(bool value)
        {
            m_wireframe = value;
        }

        public void SetRenderMode(RenderMode mode)
        {
            m_drawMode = (int)mode;
        }

        public void SetModelNode(ModelNode node, PrimitiveType primType)
        {
            m_isNode = true;
            m_modelNode = node;
            m_primitiveType = primType;
            UpdateBuffer();
        }

        public void SetModel(BaseModel model, PrimitiveType primType)
        {
            m_isNode = false;
            m_modelNode = model.RootNode;
            m_primitiveType = primType;

            UpdateBuffer();
            m_camera.SetTarget(m_modelCenter + Vector3.UnitX * 1.1f, m_modelCenter);
        }

        private void m_timer_Tick(object sender, EventArgs e)
        {
            if (m_handleDestoryed) return;
            if (IsIdle)
            {
                m_camera.Update();
                Render();
            }
        }

        private void ToOpenTK(ref Matrix4 dst, ShenmueDKSharp.Matrix4 src)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    dst[i, j] = src[i, j];
                }
            }
        }

        private Vector3 ToOpenTK(ShenmueDKSharp.Vector3 vec)
        {
            return new Vector3(vec.X, vec.Y, vec.Z);
        }

        private Color4 ToOpenTK(ShenmueDKSharp.Graphics.Color4 col)
        {
            return new Color4(col.R, col.G, col.B, col.A);
        }

        protected override void OnLoad(EventArgs args)
        {
            base.OnLoad(args);

            if (DesignMode) return;

            m_loaded = true;
            m_program = CompileShaders();
            m_vertexArray = GL.GenVertexArray();
            m_buffer = GL.GenBuffer();
            m_texture = GL.GenTexture();

            //Can't use Texture array because not all textures are the same size
            //So we create an big ass array
            m_textures = new uint[50];
            GL.GenTextures(50, m_textures);

            GL.BindVertexArray(m_vertexArray);
            GL.BindBuffer(BufferTarget.ArrayBuffer, m_buffer);

            m_uniformLocations.Add("u_model", GL.GetUniformLocation(m_program, "u_model"));
            m_uniformLocations.Add("u_view", GL.GetUniformLocation(m_program, "u_view"));
            m_uniformLocations.Add("u_projection", GL.GetUniformLocation(m_program, "u_projection"));
            m_uniformLocations.Add("u_texture", GL.GetUniformLocation(m_program, "u_texture"));
            m_uniformLocations.Add("u_stripColor", GL.GetUniformLocation(m_program, "u_stripColor"));
            m_uniformLocations.Add("u_lightPos", GL.GetUniformLocation(m_program, "u_lightPos"));
            m_uniformLocations.Add("u_lightColor", GL.GetUniformLocation(m_program, "u_lightColor"));
            m_uniformLocations.Add("u_drawMode", GL.GetUniformLocation(m_program, "u_drawMode"));

            int stride = 12 * sizeof(float);

            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, stride, 0);

            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, stride, 3 * sizeof(float));

            GL.EnableVertexAttribArray(2);
            GL.VertexAttribPointer(2, 2, VertexAttribPointerType.Float, false, stride, 6 * sizeof(float));

            GL.EnableVertexAttribArray(3);
            GL.VertexAttribPointer(3, 4, VertexAttribPointerType.Float, false, stride, 8 * sizeof(float));

            m_camera.UpdateProjection();

            m_timer.Start();
        }

        private int CompileShaders()
        {
            var vertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShader, Properties.Resources.vertexShader);
            GL.CompileShader(vertexShader);
            var info = GL.GetShaderInfoLog(vertexShader);
            if (!string.IsNullOrWhiteSpace(info))
                Console.WriteLine($"GL.CompileShader [{ShaderType.VertexShader}] had info log: {info}");

            var fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentShader, Properties.Resources.fragmentShader);
            GL.CompileShader(fragmentShader);
            info = GL.GetShaderInfoLog(fragmentShader);
            if (!string.IsNullOrWhiteSpace(info))
                Console.WriteLine($"GL.CompileShader [{ShaderType.FragmentShader}] had info log: {info}");

            var program = GL.CreateProgram();
            GL.AttachShader(program, vertexShader);
            GL.AttachShader(program, fragmentShader);
            GL.LinkProgram(program);

            GL.DetachShader(program, vertexShader);
            GL.DetachShader(program, fragmentShader);
            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentShader);

            return program;
        }

        private void UpdateBuffer(bool resetTree = true)
        {
            m_verticesFloat.Clear();
            m_verticesMatrices.Clear();
            m_verticesTextures.Clear();
            m_verticesColors.Clear();
            m_verticesTransparent.Clear();
            m_verticesWrapModes.Clear();
            m_verticesUnlit.Clear();
    
            if (m_modelNode == null) return;

            Vector3 center = Vector3.Zero;
            float radius = 0;

            List<ModelNode> nodes = null;
            if (m_isNode)
            {
                nodes = m_modelNode.GetAllNodes(false);
            }
            else
            {
                nodes = m_modelNode.GetAllNodes();
            }

            foreach (ModelNode node in nodes)
            {
                Matrix4 modelMatrix = new Matrix4();
                ToOpenTK(ref modelMatrix, node.GetTransformMatrix());

                if (node.HasMesh)
                {
                    if (node.Radius > radius) radius = node.Radius;
                    Vector3 c = ToOpenTK(node.Center);
                    c = Vector3.TransformPosition(c, modelMatrix);
                    center = Vector3.Lerp(center, c, 0.5f);
                }

                if (node.Faces.Count == 0) continue;
                foreach (MeshFace entry in node.Faces)
                {
                    m_verticesFloat.Add(entry.GetFloatArray(node, Vertex.VertexFormat.VertexNormalUVColor));
                    m_verticesMatrices.Add(modelMatrix);
                    m_verticesTextures.Add(entry.Material.Texture);
                    m_verticesColors.Add(Color4.White); //ToOpenTK(entry.StripColor)
                    m_verticesTransparent.Add(entry.Transparent);
                    m_verticesWrapModes.Add((TextureWrapMode)entry.Wrap);
                    m_verticesUnlit.Add(entry.Unlit);
                }

            }
            m_modelCenter = center;
            CreateTextures();
        }

        private void CreateTextures()
        {
            if (m_textures != null)
            {
                GL.DeleteTextures(m_textures.Length, m_textures);
            }
            m_textures = new uint[m_verticesTextures.Count];
            GL.GenTextures(m_verticesTextures.Count, m_textures);

            for (int i = 0; i < m_verticesFloat.Count; i++)
            {
                if (m_verticesTextures[i] != null)
                {
                    BaseImage tex = m_verticesTextures[i].Image;
                    GL.ActiveTexture(TextureUnit.Texture0);
                    GL.PixelStore(PixelStoreParameter.UnpackAlignment, 1);
                    GL.BindTexture(TextureTarget.Texture2D, m_textures[i]);
                    GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

                    int wrapMode = (int)m_verticesWrapModes[i];
                    int filterMode = (int)TextureMinFilter.Linear;
                    GL.TexParameterI(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, ref filterMode);
                    GL.TexParameterI(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, ref filterMode);
                    GL.TexParameterI(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, ref wrapMode);
                    GL.TexParameterI(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, ref wrapMode);

                    GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, (int)tex.Width, (int)tex.Height,
                                                           0, PixelFormat.Rgba, PixelType.Float, tex.GetPixels());
                }
            }
        }

        public void Render()
        {
            if (DesignMode) return;
            if (!m_loaded) return;

            Color4 backColor;
            backColor.A = 1.0f;
            backColor.R = 0.1f;
            backColor.G = 0.1f;
            backColor.B = 0.1f;
            GL.ClearColor(backColor);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.UseProgram(m_program);

            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Blend);
            //GL.Enable(EnableCap.ProgramPointSize);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            int loc_model = m_uniformLocations["u_model"];
            int loc_view = m_uniformLocations["u_view"];
            int loc_projection = m_uniformLocations["u_projection"];
            int loc_texture = m_uniformLocations["u_texture"];
            int loc_stripColor = m_uniformLocations["u_stripColor"];
            int loc_lightPos = m_uniformLocations["u_lightPos"];
            int loc_lightColor = m_uniformLocations["u_lightColor"];
            int loc_drawMode = m_uniformLocations["u_drawMode"];

            Matrix4 view = m_camera.View;
            Matrix4 projection = m_camera.Projection;

            GL.UniformMatrix4(loc_view, false, ref view);
            GL.UniformMatrix4(loc_projection, false, ref projection);

            GL.Uniform3(loc_lightColor, 1.0f, 1.0f, 1.0f);
            //GL.Uniform3(loc_lightPos, 230.0f, 320.0f, 180.0f);
            GL.Uniform3(loc_lightPos, m_camera.Position);

            //GL.Enable(EnableCap.CullFace);
            //GL.CullFace(CullFaceMode.Back);

            if (m_wireframe)
            {
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            }
            else
            {
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            }

            if (m_verticesFloat != null && m_verticesFloat.Count > 0)
            {
                GL.BindVertexArray(m_vertexArray);
                GL.BindBuffer(BufferTarget.ArrayBuffer, m_buffer);

                //OPAQUE PASS
                GL.DepthMask(true);
                int opaqueCounter = 0;
                for (int i = 0; i < m_verticesFloat.Count; i++)
                {
                    if (m_verticesTextures[i] != null)
                    {
                        if (m_verticesTransparent[i]) continue;
                        //if (_verticesTextures[i].Image.HasTransparency) continue;
                    }

                    opaqueCounter++;

                    GL.ActiveTexture(TextureUnit.Texture0);
                    GL.BindTexture(TextureTarget.Texture2D, m_textures[i]);
                    GL.Uniform1(loc_texture, 0);
                    GL.Uniform4(loc_stripColor, m_verticesColors[i]);

                    if (m_verticesUnlit[i])
                    {
                        GL.Uniform1(loc_drawMode, 1);
                        GL.DepthMask(false);
                        GL.BlendFunc(BlendingFactor.One, BlendingFactor.One);
                    }
                    else
                    {
                        GL.Uniform1(loc_drawMode, m_drawMode);
                        GL.DepthMask(true);
                        GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
                    }

                    int wrapMode = (int)m_verticesWrapModes[i];
                    GL.TexParameterI(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, ref wrapMode);
                    GL.TexParameterI(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, ref wrapMode);

                    float[] vertices = m_verticesFloat[i];
                    GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * vertices.Length, vertices, BufferUsageHint.StaticDraw);

                    Matrix4 model = m_verticesMatrices[i];
                    GL.UniformMatrix4(loc_model, false, ref model);

                    GL.DrawArrays(m_primitiveType, 0, vertices.Length / 12);
                }

                //TRANSPARENT PASS
                //GL.DepthMask(false);
                for (int i = 0; i < m_verticesFloat.Count; i++)
                {
                    if (m_verticesTextures[i] == null) continue;
                    if (m_verticesTransparent[i]) continue;
                    //if (!_verticesTextures[i].Image.HasTransparency) continue;

                    GL.ActiveTexture(TextureUnit.Texture0);
                    GL.BindTexture(TextureTarget.Texture2D, m_textures[i]);
                    GL.Uniform1(loc_texture, 0);
                    GL.Uniform4(loc_stripColor, m_verticesColors[i]);

                    if (m_verticesUnlit[i])
                    {
                        GL.Uniform1(loc_drawMode, 1);
                        GL.DepthMask(false);
                        GL.BlendFunc(BlendingFactor.One, BlendingFactor.One);
                    }
                    else
                    {
                        GL.Uniform1(loc_drawMode, m_drawMode);
                        GL.DepthMask(true);
                        GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
                    }

                    int wrapMode = (int)m_verticesWrapModes[i];
                    GL.TexParameterI(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, ref wrapMode);
                    GL.TexParameterI(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, ref wrapMode);

                    float[] vertices = m_verticesFloat[i];
                    GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * vertices.Length, vertices, BufferUsageHint.StaticDraw);

                    Matrix4 model = m_verticesMatrices[i];
                    GL.UniformMatrix4(loc_model, false, ref model);

                    GL.DrawArrays(m_primitiveType, 0, vertices.Length / 12);
                }

                GL.DepthMask(true);
            }

            SwapBuffers();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (!m_loaded) return;
            GL.Viewport(0, 0, Width, Height);
            if (m_camera != null) m_camera.UpdateProjection();
        }
    }
}
