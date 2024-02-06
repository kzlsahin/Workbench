using SharpGL.VertexBuffers;
using SharpGL;
using SharpGL.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SharpGL.RenderContextProviders;

namespace WPFExperiment.GLDrawers
{
    internal class BufferDrawer : IGLDrawer
    {
        uint vertexBufferId;
        int ActualWidth;
        int ActualHeight;
        public BufferDrawer(int width, int height)
        {
            ActualHeight = height;
            ActualWidth = width;
        }
        public void Draw(object sender, OpenGLRoutedEventArgs args)
        {
            OpenGL gl = args.OpenGL;

            // Set up the viewport and projection matrix
            gl.Viewport(0, 0, ActualWidth, ActualHeight);
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            gl.Perspective(45.0f, (double)ActualWidth / ActualHeight, 0.1f, 100.0f);
            gl.LookAt(0, 0, 5, 0, 0, 0, 0, 1, 0);

            // Set up the modelview matrix
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.LoadIdentity();

            // Bind the vertex buffer and enable vertex attributes
            gl.BindBuffer(OpenGL.GL_ARRAY_BUFFER, vertexBufferId);
            gl.EnableClientState(OpenGL.GL_VERTEX_ARRAY);

            // Specify the vertex pointer (3 floats for each vertex)
            gl.VertexPointer(3, OpenGL.GL_FLOAT, Marshal.SizeOf(typeof(Vertex)), IntPtr.Zero);

            // Draw the vertices
            gl.DrawArrays(OpenGL.GL_TRIANGLES, 0, vertices.Length);

            // Disable vertex attributes and unbind the vertex buffer
            gl.DisableClientState(OpenGL.GL_VERTEX_ARRAY);
            gl.BindBuffer(OpenGL.GL_ARRAY_BUFFER, 0);
        }

        public void Initialize(object sender, OpenGLRoutedEventArgs args)
        {
            OpenGL gl = args.OpenGL;
            uint[] bufferIDs = new uint[1];
            // Create and bind the vertex buffer
            gl.GenBuffers(1, bufferIDs);
            if (bufferIDs?.Length > 0)
            {
                vertexBufferId = bufferIDs[0];
            }
            

            gl.BindBuffer(OpenGL.GL_ARRAY_BUFFER, vertexBufferId);

            GCHandle handle = GCHandle.Alloc(vertices, GCHandleType.Pinned);
            IntPtr vertexPtr = handle.AddrOfPinnedObject();

            // Copy the vertex array data to the vertex buffer
            gl.BufferData(OpenGL.GL_ARRAY_BUFFER, vertices.Length * Marshal.SizeOf(typeof(Vertex)), vertexPtr, OpenGL.GL_STATIC_DRAW);

            handle.Free();
        }

        public void OnWindowResized(object sender, OpenGLRoutedEventArgs args)
        {
            // Get the OpenGL instance.
            OpenGL gl = args.OpenGL;

            ActualWidth = gl.RenderContextProvider.Width;
            ActualHeight = gl.RenderContextProvider.Height;
            // Load and clear the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();

            // Perform a perspective transformation
            gl.Perspective(45.0f, (float)gl.RenderContextProvider.Width /
                (float)gl.RenderContextProvider.Height,
                0.1f, 100.0f);

            // Load the modelview.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }
        Vertex[] vertices = new Vertex[]
            {
                new Vertex(-1.0f, -1.0f, 0.0f),
                new Vertex(1.0f, -1.0f, 0.0f),
                new Vertex(0.0f, 1.0f, 0.0f)
            // Add more vertices as needed
            };
    }
}
