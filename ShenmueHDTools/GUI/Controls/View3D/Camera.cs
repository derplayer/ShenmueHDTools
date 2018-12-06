using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShenmueHDTools.GUI.Controls.View3D
{
    public class Camera
    {
        public event EventHandler<Vector3> CameraPositionChanged;

        public float ZNear = 0.5f;
        public float ZFar = 1000.0f;

        protected GLControl m_game;

        protected Vector3 m_position = new Vector3(0, 0, 30);
        protected Vector3 m_up = Vector3.UnitY;
        protected Vector3 m_direction;

        protected const float m_pitchLimit = 1.4f;

        protected const float m_speed = 0.5f;
        protected float m_speedModifier = 1.0f;
        protected const float m_mouseSpeedX = 0.0045f;
        protected const float m_mouseSpeedY = 0.0025f;

        protected KeyEventArgs m_keyboard;
        protected MouseEventArgs m_mouse;
        protected MouseEventArgs m_prevMouse;
        protected Point m_prevMouseP;
        protected int m_prevScroll;

        private bool m_leftDown = false;
        private Dictionary<Keys, bool> m_keyStates = new Dictionary<Keys, bool>();

        /// <summary>
        /// Creates the instance of the camera.
        /// </summary>
        public Camera(GLControl game)
        {
            m_game = game;

            foreach (Keys key in Enum.GetValues(typeof(Keys)))
            {
                if (!m_keyStates.Keys.Contains(key))
                    m_keyStates.Add(key, false);
            }

            m_game.KeyDown += On_KeyDown;
            m_game.KeyUp += On_KeyUp;

            m_game.MouseWheel += On_MouseWheel;
            m_game.MouseDown += On_MouseDown;
            m_game.MouseUp += On_MouseUp;
            m_game.MouseMove += On_MouseMove;

            // Create the direction vector and normalize it since it will be used for movement
            m_direction = Vector3.Zero - m_position;
            m_direction.Normalize();

            // Create default camera matrices
            UpdateProjection();
            View = CreateLookAt();
        }

        private void M_game_KeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void On_KeyUp(object sender, KeyEventArgs e)
        {
            m_keyStates[e.KeyCode] = false;
        }

        private void On_KeyDown(object sender, KeyEventArgs e)
        {
            m_keyStates[e.KeyCode] = true;
        }

        private void On_MouseWheel(object sender, MouseEventArgs e)
        {
            m_position += m_direction * ((float)e.Delta * 0.001f);
        }

        private void On_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                m_leftDown = false;
                m_prevMouseP = e.Location;
            }
        }

        private void On_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                m_leftDown = true;
                m_prevMouseP = e.Location;
            }
        }

        private void On_MouseMove(object sender, MouseEventArgs e)
        {
            Point pos = e.Location;
            if (m_leftDown)
            {
                // Calculate yaw to look around with a mouse
                m_direction = Vector3.Transform(m_direction, Matrix3.CreateFromAxisAngle(m_up, -m_mouseSpeedX * (pos.X - m_prevMouseP.X)));

                // Pitch is limited to m_pitchLimit
                float angle = m_mouseSpeedY * (pos.Y - m_prevMouseP.Y);
                if ((Pitch < m_pitchLimit || angle > 0) && (Pitch > -m_pitchLimit || angle < 0))
                {
                    m_direction = Vector3.Transform(m_direction, Matrix3.CreateFromAxisAngle(Vector3.Cross(m_up, m_direction), angle));
                }
            }
            m_prevMouseP = pos;
        }

        public void SetTarget(Vector3 position, Vector3 target)
        {
            m_position = position;
            m_direction = target - m_position;
            m_direction.Normalize();
            View = CreateLookAt();
        }

        public void UpdateProjection()
        {
            Projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, m_game.Width / (float)m_game.Height, ZNear, ZFar);
        }

        /// <summary>
        /// Handle the camera movement using user input.
        /// </summary>
        protected virtual void ProcessInput()
        {
            if (m_keyStates[Keys.ShiftKey])
            {
                m_speedModifier = 10.0f;
            }
            else if (m_keyStates[Keys.ControlKey])
            {
                m_speedModifier = 0.1f;
            }
            else
            {
                m_speedModifier = 1.0f;
            }

            // Move camera with WASD keys
            if (m_keyStates[Keys.W])
                // Move forward and backwards by adding m_position and m_direction vectors
                m_position += m_direction * m_speed * m_speedModifier;

            if (m_keyStates[Keys.S])
                m_position -= m_direction * m_speed * m_speedModifier;

            if (m_keyStates[Keys.A])
                // Strafe by adding a cross product of m_up and m_direction vectors
                m_position += Vector3.Cross(m_up, m_direction) * m_speed * m_speedModifier;

            if (m_keyStates[Keys.D])
                m_position -= Vector3.Cross(m_up, m_direction) * m_speed * m_speedModifier;

            if (m_keyStates[Keys.Space])
                m_position += m_up * m_speed * m_speedModifier;

            if (m_keyStates[Keys.X])
                m_position -= m_up * m_speed * m_speedModifier;
        }

        public void Update()
        {
            //if (!m_game.Focused) return;
            ProcessInput();
            View = CreateLookAt();
        }

        public void Update(KeyEventArgs args)
        {
            if (!m_game.Focused)
            {
                m_keyboard = args;
                return;
            }

            ProcessInput();
            View = CreateLookAt();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        public void Update(MouseEventArgs args)
        {
            if (!m_game.Focused)
            {
                m_prevMouse = m_mouse;
                m_mouse = args;
                return;
            }

            // Handle camera movement
            ProcessInput();
            View = CreateLookAt();
        }


        /// <summary>
        /// Create a view (modelview) matrix using camera vectors.
        /// </summary>
        protected Matrix4 CreateLookAt()
        {
            return Matrix4.LookAt(m_position, m_position + m_direction, m_up);
        }


        /// <summary>
        /// Position vector.
        /// </summary>
        public Vector3 Position
        {
            get { return m_position; }
            set
            {
                m_position = value;
                CreateLookAt();
            }
        }

        /// <summary>
        /// Yaw of the camera in radians.
        /// </summary>
        public double Yaw
        {
            get { return Math.PI - Math.Atan2(m_direction.X, m_direction.Z); }
        }

        /// <summary>
        /// Pitch of the camera in radians.
        /// </summary>
        public double Pitch
        {
            get { return Math.Asin(m_direction.Y); }
        }

        /// <summary>
        /// View (modelview) matrix accessor.
        /// </summary>
        public Matrix4 View { get; protected set; }

        /// <summary>
        /// Projection matrix accessor.
        /// </summary>
        public Matrix4 Projection { get; protected set; }

    }
}
