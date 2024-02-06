using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFExperiment.GL
{
    internal class gl
    {
        [DllImport("OPENGL32.DLL", EntryPoint = "glAccum")]
        public static extern void Accum(int op, float value);

        [DllImport("OPENGL32.DLL", EntryPoint = "glAlphaFunc")]
        public static extern void AlphaFunc(int func, float refval);

        [DllImport("OPENGL32.DLL", EntryPoint = "glAreTexturesResident")]
        public static extern bool AreTexturesResident(int n, uint[] Textures, bool[] residences);

        [DllImport("OPENGL32.DLL", EntryPoint = "glArrayElement")]
        public static extern void ArrayElement(int i);

        [DllImport("OPENGL32.DLL", EntryPoint = "glBegin")]
        public static extern void Begin(int mode);

        [DllImport("OPENGL32.DLL", EntryPoint = "glBindTexture")]
        public static extern void BindTexture(int target, uint texture);

        [DllImport("OPENGL32.DLL", EntryPoint = "glBitmap")]
        public static extern void Bitmap(
          int width,
          int height,
          float xorig,
          float yorig,
          float xmove,
          float ymove,
          byte[] bitmap);

        [DllImport("OPENGL32.DLL", EntryPoint = "glBlendFunc")]
        public static extern void BlendFunc(int sfactor, int dfactor);

        [DllImport("OPENGL32.DLL", EntryPoint = "glCallList")]
        public static extern void CallList(uint list);

        [DllImport("OPENGL32.DLL", EntryPoint = "glCallLists")]
        public static extern void CallLists(int n, int type, int[] lists);

        [DllImport("OPENGL32.DLL", EntryPoint = "glCallLists")]
        public static extern void CallLists(int n, int type, string lists);

        [DllImport("OPENGL32.DLL", EntryPoint = "glClear")]
        public static extern void Clear(int mask);

        [DllImport("OPENGL32.DLL", EntryPoint = "glClearAccum")]
        public static extern void ClearAccum(float red, float green, float blue, float alpha);

        [DllImport("OPENGL32.DLL", EntryPoint = "glClearColor")]
        public static extern void ClearColor(float red, float green, float blue, float alpha);

        [DllImport("OPENGL32.DLL", EntryPoint = "glClearDepth")]
        public static extern void ClearDepth(double depth);

        [DllImport("OPENGL32.DLL", EntryPoint = "glClearIndex")]
        public static extern void ClearIndex(float c);

        [DllImport("OPENGL32.DLL", EntryPoint = "glClearStencil")]
        public static extern void ClearStencil(int s);

        [DllImport("OPENGL32.DLL", EntryPoint = "glClipPlane")]
        public static extern void ClipPlane(int plane, double[] equation);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColor3b")]
        public static extern void Color3b(sbyte red, sbyte green, sbyte blue);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColor3bv")]
        public static extern void Color3bv(ref sbyte v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColor3d")]
        public static extern void Color3d(double red, double green, double blue);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColor3dv")]
        public static extern void Color3dv(double[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColor3f")]
        public static extern void Color3f(float red, float green, float blue);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColor3fv")]
        public static extern void Color3fv(float[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColor3i")]
        public static extern void Color3i(int red, int green, int blue);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColor3iv")]
        public static extern void Color3iv(int[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColor3s")]
        public static extern void Color3s(short red, short green, short blue);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColor3sv")]
        public static extern void Color3sv(short[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColor3ub")]
        public static extern void Color3ub(byte red, byte green, byte blue);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColor3ubv")]
        public static extern void Color3ubv(byte[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColor3ui")]
        public static extern void Color3ui(uint red, uint green, uint blue);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColor3uiv")]
        public static extern void Color3uiv(uint[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColor3us")]
        public static extern void Color3us(short red, ushort green, ushort blue);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColor3usv")]
        public static extern void Color3usv(short[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColor4b")]
        public static extern void Color4b(sbyte red, sbyte green, sbyte blue, sbyte alpha);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColor4bv")]
        public static extern void Color4bv(sbyte[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColor4d")]
        public static extern void Color4d(double red, double green, double blue, double alpha);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColor4dv")]
        public static extern void Color4dv(double[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColor4f")]
        public static extern void Color4f(float red, float green, float blue, float alpha);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColor4fv")]
        public static extern void Color4fv(float[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColor4i")]
        public static extern void Color4i(int red, int green, int blue, int alpha);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColor4iv")]
        public static extern void Color4iv(int[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColor4s")]
        public static extern void Color4s(short red, short green, short blue, short alpha);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColor4sv")]
        public static extern void Color4sv(short[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColor4ub")]
        public static extern void Color4ub(byte red, byte green, byte blue, byte alpha);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColor4ubv")]
        public static extern void Color4ubv(byte[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColor4ui")]
        public static extern void Color4ui(uint red, uint green, uint blue, uint alpha);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColor4uiv")]
        public static extern void Color4uiv(uint[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColor4us")]
        public static extern void Color4us(ushort red, ushort green, ushort blue, ushort alpha);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColor4usv")]
        public static extern void Color4usv(ushort[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColorMask")]
        public static extern void ColorMask(bool red, bool green, bool blue, bool alpha);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColorMaterial")]
        public static extern void ColorMaterial(int face, int mode);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColorPointer")]
        public static extern void ColorPointer(int size, int type, int stride, IntPtr pointer);

        [DllImport("OPENGL32.DLL", EntryPoint = "glColorPointer")]
        public static extern void ColorPointer(int size, int type, int stride, int offset);

        [DllImport("OPENGL32.DLL", EntryPoint = "glCopyPixels")]
        public static extern void CopyPixels(int x, int y, int width, int height, int type);

        [DllImport("OPENGL32.DLL", EntryPoint = "glCopyTexImage1D")]
        public static extern void CopyTexImage1D(
          int target,
          int level,
          int internalformat,
          int x,
          int y,
          int width,
          int border);

        [DllImport("OPENGL32.DLL", EntryPoint = "glCopyTexImage2D")]
        public static extern void CopyTexImage2D(
          uint target,
          int level,
          int internalformat,
          int x,
          int y,
          int width,
          int height,
          int border);

        [DllImport("OPENGL32.DLL", EntryPoint = "glCopyTexSubImage1D")]
        public static extern void CopyTexSubImage1D(
          int target,
          int level,
          int xoffset,
          int x,
          int y,
          int width);

        [DllImport("OPENGL32.DLL", EntryPoint = "glCopyTexSubImage2D")]
        public static extern void CopyTexSubImage2D(
          int target,
          int level,
          int xoffset,
          int yoffset,
          int x,
          int y,
          int width,
          int height);

        [DllImport("OPENGL32.DLL", EntryPoint = "glCullFace")]
        public static extern void CullFace(int mode);

        [DllImport("OPENGL32.DLL", EntryPoint = "glDeleteLists")]
        public static extern void DeleteLists(uint list, int range);

        [DllImport("OPENGL32.DLL", EntryPoint = "glDeleteTextures")]
        private static extern void DeleteTextures(
          int _param0,
          uint[] _param1);

    [DllImport("OPENGL32.DLL", EntryPoint = "glDeleteTextures")]
        private static extern void DeleteTextures(
          int _param0,
          ref uint _param1);

    public static void DeleteTexture(uint texture) => gl.DeleteTextures(1, ref texture);

    public static void DeleteTextures(uint[] Textures) => gl.DeleteTextures(Textures.Length, Textures);

    [DllImport("OPENGL32.DLL", EntryPoint = "glDepthFunc")]
        public static extern void DepthFunc(int func);

        [DllImport("OPENGL32.DLL", EntryPoint = "glDepthMask")]
        public static extern void DepthMask(bool flag);

        [DllImport("OPENGL32.DLL", EntryPoint = "glDepthRange")]
        public static extern void DepthRange(double zNear, double zFar);

        [DllImport("OPENGL32.DLL", EntryPoint = "glDisable")]
        public static extern void Disable(int cap);

        [DllImport("OPENGL32.DLL", EntryPoint = "glDisableClientState")]
        public static extern void DisableClientState(int array);

        [DllImport("OPENGL32.DLL", EntryPoint = "glDrawArrays")]
        public static extern void DrawArrays(int mode, int first, int count);

        [DllImport("OPENGL32.DLL", EntryPoint = "glDrawBuffer")]
        public static extern void DrawBuffer(int mode);

        [DllImport("OPENGL32.DLL", EntryPoint = "glDrawElements")]
        public static extern void DrawElements(int mode, int count, int type, int[] indices);

        [DllImport("OPENGL32.DLL", EntryPoint = "glDrawElements")]
        public static extern void DrawElements(int mode, int count, int type, int[,] indices);

        [DllImport("OPENGL32.DLL", EntryPoint = "glDrawElements")]
        public static extern void DrawElements(int mode, int count, int type, IntPtr indices);

        [DllImport("OPENGL32.DLL", EntryPoint = "glDrawElements")]
        public static extern void DrawElements(int mode, int count, int type, int offset);

        [DllImport("OPENGL32.DLL", EntryPoint = "glDrawPixels")]
        public static extern void DrawPixels(
          int width,
          int height,
          int format,
          int type,
          IntPtr pixels);

        [DllImport("OPENGL32.DLL", EntryPoint = "glEdgeFlag")]
        public static extern void EdgeFlag(bool flag);

        [DllImport("OPENGL32.DLL", EntryPoint = "glEdgeFlagPointer")]
        public static extern void EdgeFlagPointer(int stride, IntPtr pointer);

        [DllImport("OPENGL32.DLL", EntryPoint = "glEdgeFlagPointer")]
        public static extern void EdgeFlagPointer(int stride, int offset);

        [DllImport("OPENGL32.DLL", EntryPoint = "glEdgeFlagv")]
        public static extern void EdgeFlagv(bool[] flag);

        [DllImport("OPENGL32.DLL", EntryPoint = "glEnable")]
        public static extern void Enable(int cap);

        [DllImport("OPENGL32.DLL", EntryPoint = "glEnableClientState")]
        public static extern void EnableClientState(int array);

        [DllImport("OPENGL32.DLL", EntryPoint = "glEnd")]
        public static extern void End();

        [DllImport("OPENGL32.DLL", EntryPoint = "glEndList")]
        public static extern void EndList();

        [DllImport("OPENGL32.DLL", EntryPoint = "glEvalCoord1d")]
        public static extern void EvalCoord1d(double u);

        [DllImport("OPENGL32.DLL", EntryPoint = "glEvalCoord1dv")]
        public static extern void EvalCoord1dv(double[] u);

        [DllImport("OPENGL32.DLL", EntryPoint = "glEvalCoord1f")]
        public static extern void EvalCoord1f(float u);

        [DllImport("OPENGL32.DLL", EntryPoint = "glEvalCoord1fv")]
        public static extern void EvalCoord1fv(float[] u);

        [DllImport("OPENGL32.DLL", EntryPoint = "glEvalCoord2d")]
        public static extern void EvalCoord2d(double u, double v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glEvalCoord2dv")]
        public static extern void EvalCoord2dv(double[] u);

        [DllImport("OPENGL32.DLL", EntryPoint = "glEvalCoord2f")]
        public static extern void EvalCoord2f(float u, float v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glEvalCoord2fv")]
        public static extern void EvalCoord2fv(ref float u);

        [DllImport("OPENGL32.DLL", EntryPoint = "glEvalMesh1")]
        public static extern void EvalMesh1(int mode, int i1, int i2);

        [DllImport("OPENGL32.DLL", EntryPoint = "glEvalMesh2")]
        public static extern void EvalMesh2(int mode, int i1, int i2, int j1, int j2);

        [DllImport("OPENGL32.DLL", EntryPoint = "glEvalPoint1")]
        public static extern void EvalPoint1(int i);

        [DllImport("OPENGL32.DLL", EntryPoint = "glEvalPoint2")]
        public static extern void EvalPoint2(int i, int j);

        [DllImport("OPENGL32.DLL", EntryPoint = "glFeedbackBuffer")]
        public static extern void FeedbackBuffer(int size, int type, float[] buffer);

        [DllImport("OPENGL32.DLL", EntryPoint = "glFinish")]
        public static extern void Finish();

        [DllImport("OPENGL32.DLL", EntryPoint = "glFlush")]
        public static extern void Flush();

        [DllImport("OPENGL32.DLL", EntryPoint = "glFogf")]
        public static extern void Fogf(int pname, float param);

        [DllImport("OPENGL32.DLL", EntryPoint = "glFogfv")]
        public static extern void Fogfv(int pname, float[] fogparams);

        [DllImport("OPENGL32.DLL", EntryPoint = "glFogi")]
        public static extern void Fogi(int pname, int param);

        [DllImport("OPENGL32.DLL", EntryPoint = "glFogiv")]
        public static extern void Fogiv(int pname, int[] fogparams);

        [DllImport("OPENGL32.DLL", EntryPoint = "glFrontFace")]
        public static extern void FrontFace(int mode);

        [DllImport("OPENGL32.DLL", EntryPoint = "glFrustum")]
        public static extern void Frustum(
          double left,
          double right,
          double bottom,
          double top,
          double zNear,
          double zFar);

        [DllImport("OPENGL32.DLL", EntryPoint = "glGenLists")]
        public static extern uint GenLists(int range);

        [DllImport("OPENGL32.DLL", EntryPoint = "glGenTextures")]
        public static extern void GenTextures(int n, uint[] Textures);

        [DllImport("OPENGL32.DLL", EntryPoint = "glGenTextures")]
        public static extern void GenTextures(int n, ref uint texture);

        [DllImport("OPENGL32.DLL", EntryPoint = "glGetBooleanv")]
        public static extern void GetBooleanv(int pname, int[] bparams);

        [DllImport("OPENGL32.DLL", EntryPoint = "glGetClipPlane")]
        public static extern void GetClipPlane(int plane, double[] equation);

        [DllImport("OPENGL32.DLL", EntryPoint = "glGetDoublev")]
        public static extern void GetDoublev(int pname, double[] dparams);

        [DllImport("OPENGL32.DLL", EntryPoint = "glGetError")]
        public static extern int GetError();

        [DllImport("OPENGL32.DLL", EntryPoint = "glGetFloatv")]
        public static extern void GetFloatv(int pname, float[] fparams);

        [DllImport("OPENGL32.DLL", EntryPoint = "glGetIntegerv")]
        public static extern void GetIntegerv(int pname, int[] fparams);

        [DllImport("OPENGL32.DLL", EntryPoint = "glGetLightfv")]
        public static extern void GetLightfv(int light, int pname, float[] lparams);

        [DllImport("OPENGL32.DLL", EntryPoint = "glGetLightiv")]
        public static extern void GetLightiv(int light, int pname, int[] iparams);

        [DllImport("OPENGL32.DLL", EntryPoint = "glGetMapdv")]
        public static extern void GetMapdv(int target, int query, double[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glGetMapfv")]
        public static extern void GetMapfv(int target, int query, float[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glGetMapiv")]
        public static extern void GetMapiv(int target, int query, int[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glGetMaterialfv")]
        public static extern void GetMaterialfv(int face, int pname, float[] fparams);

        [DllImport("OPENGL32.DLL", EntryPoint = "glGetMaterialiv")]
        public static extern void GetMaterialiv(int face, int pname, int[] iparams);

        [DllImport("OPENGL32.DLL", EntryPoint = "glGetPixelMapfv")]
        public static extern void GetPixelMapfv(int map, float[] values);

        [DllImport("OPENGL32.DLL", EntryPoint = "glGetPixelMapuiv")]
        public static extern void GetPixelMapuiv(int map, uint[] values);

        [DllImport("OPENGL32.DLL", EntryPoint = "glGetPixelMapusv")]
        public static extern void GetPixelMapusv(int map, ushort[] values);

        [DllImport("OPENGL32.DLL", EntryPoint = "glGetPointerv")]
        public static extern void GetPointerv(int pname, ref int param);

        [DllImport("OPENGL32.DLL", EntryPoint = "glGetPolygonStipple")]
        public static extern void GetPolygonStipple(byte[] mask);

        [DllImport("OPENGL32.DLL", EntryPoint = "glGetString")]
        private static extern IntPtr GetString(int _param0);

    [DllImport("OPENGL32.DLL", EntryPoint = "glGetTexEnvfv")]
        public static extern void GetTexEnvfv(int target, int pname, float[] envparams);

        [DllImport("OPENGL32.DLL", EntryPoint = "glGetTexEnviv")]
        public static extern void GetTexEnviv(int target, int pname, int[] envparams);

        [DllImport("OPENGL32.DLL", EntryPoint = "glGetTexGendv")]
        public static extern void GetTexGendv(int coord, int pname, double[] dparams);

        [DllImport("OPENGL32.DLL", EntryPoint = "glGetTexGenfv")]
        public static extern void GetTexGenfv(int coord, int pname, float[] fparams);

        [DllImport("OPENGL32.DLL", EntryPoint = "glGetTexGeniv")]
        public static extern void GetTexGeniv(int coord, int pname, int[] iparams);

        [DllImport("OPENGL32.DLL", EntryPoint = "glGetTexImage")]
        public static extern void GetTexImage(
          int target,
          int level,
          int format,
          int type,
          IntPtr pixels);

        [DllImport("OPENGL32.DLL", EntryPoint = "glGetTexLevelParameterfv")]
        public static extern void GetTexLevelParameterfv(
          int target,
          int level,
          int pname,
          float[] fparams);

        [DllImport("OPENGL32.DLL", EntryPoint = "glGetTexLevelParameteriv")]
        public static extern void GetTexLevelParameteriv(
          int target,
          int level,
          int pname,
          int[] iparams);

        [DllImport("OPENGL32.DLL", EntryPoint = "glGetTexParameterfv")]
        public static extern void GetTexParameterfv(int target, int pname, float[] fparams);

        [DllImport("OPENGL32.DLL", EntryPoint = "glGetTexParameteriv")]
        public static extern void GetTexParameteriv(int target, int pname, int[] iparams);

        [DllImport("OPENGL32.DLL", EntryPoint = "glHint")]
        public static extern void Hint(int target, int mode);

        [DllImport("OPENGL32.DLL", EntryPoint = "glIndexMask")]
        public static extern void IndexMask(uint mask);

        [DllImport("OPENGL32.DLL", EntryPoint = "glIndexPointer")]
        public static extern void IndexPointer(int type, int stride, int[] pointer);

        [DllImport("OPENGL32.DLL", EntryPoint = "glIndexd")]
        public static extern void Indexd(double c);

        [DllImport("OPENGL32.DLL", EntryPoint = "glIndexdv")]
        public static extern void Indexdv(double[] c);

        [DllImport("OPENGL32.DLL", EntryPoint = "glIndexf")]
        public static extern void Indexf(float c);

        [DllImport("OPENGL32.DLL", EntryPoint = "glIndexfv")]
        public static extern void Indexfv(float[] c);

        [DllImport("OPENGL32.DLL", EntryPoint = "glIndexi")]
        public static extern void Indexi(int c);

        [DllImport("OPENGL32.DLL", EntryPoint = "glIndexiv")]
        public static extern void Indexiv(int[] c);

        [DllImport("OPENGL32.DLL", EntryPoint = "glIndexs")]
        public static extern void Indexs(short c);

        [DllImport("OPENGL32.DLL", EntryPoint = "glIndexsv")]
        public static extern void Indexsv(short[] c);

        [DllImport("OPENGL32.DLL", EntryPoint = "glIndexub")]
        public static extern void Indexub(byte c);

        [DllImport("OPENGL32.DLL", EntryPoint = "glIndexubv")]
        public static extern void Indexubv(byte[] c);

        [DllImport("OPENGL32.DLL", EntryPoint = "glInitNames")]
        public static extern void InitNames();

        [DllImport("OPENGL32.DLL", EntryPoint = "glInterleavedArrays")]
        public static extern void interleavedArrays(int format, int stride, IntPtr pointer);

        [DllImport("OPENGL32.DLL", EntryPoint = "glInterleavedArrays")]
        public static extern void interleavedArrays(int format, int stride, int offset);

        [DllImport("OPENGL32.DLL", EntryPoint = "glIsEnabled")]
        public static extern byte IsEnabled(int cap);

        [DllImport("OPENGL32.DLL", EntryPoint = "glIsList")]
        public static extern byte IsList(uint list);

        [DllImport("OPENGL32.DLL", EntryPoint = "glIsTexture")]
        public static extern byte IsTexture(uint texture);

        [DllImport("OPENGL32.DLL", EntryPoint = "glLightModelf")]
        public static extern void LightModelf(int pname, float param);

        [DllImport("OPENGL32.DLL", EntryPoint = "glLightModelfv")]
        public static extern void LightModelfv(int pname, float[] fparams);

        [DllImport("OPENGL32.DLL", EntryPoint = "glLightModeli")]
        public static extern void LightModeli(int pname, int param);

        [DllImport("OPENGL32.DLL", EntryPoint = "glLightModeliv")]
        public static extern void LightModeliv(int pname, int[] iparams);

        [DllImport("OPENGL32.DLL", EntryPoint = "glLightf")]
        public static extern void Lightf(int light, int pname, float param);

        [DllImport("OPENGL32.DLL", EntryPoint = "glLightfv")]
        public static extern void Lightfv(int light, int pname, float[] fparams);

        [DllImport("OPENGL32.DLL", EntryPoint = "glLighti")]
        public static extern void Lighti(int light, int pname, int param);

        [DllImport("OPENGL32.DLL", EntryPoint = "glLightiv")]
        public static extern void Lightiv(int light, int pname, int[] iparams);

        [DllImport("OPENGL32.DLL", EntryPoint = "glLineStipple")]
        public static extern void LineStipple(int factor, ushort pattern);

        [DllImport("OPENGL32.DLL", EntryPoint = "glLineWidth")]
        public static extern void LineWidth(float width);

        [DllImport("OPENGL32.DLL", EntryPoint = "glListBase")]
        public static extern void ListBase(uint basevalue);

        [DllImport("OPENGL32.DLL", EntryPoint = "glLoadIdentity")]
        public static extern void LoadIdentity();

        [DllImport("OPENGL32.DLL", EntryPoint = "glLoadMatrixd")]
        public static extern void LoadMatrixd(double[] m);

        [DllImport("OPENGL32.DLL", EntryPoint = "glLoadMatrixf")]
        public static extern void LoadMatrixf(float[] m);

        [DllImport("OPENGL32.DLL", EntryPoint = "glLoadName")]
        public static extern void LoadName(uint name);

        [DllImport("OPENGL32.DLL", EntryPoint = "glLogicOp")]
        public static extern void LogicOp(int opcode);

        [DllImport("OPENGL32.DLL", EntryPoint = "glMap1d")]
        public static extern void Map1d(
          int target,
          double u1,
          double u2,
          int stride,
          int order,
          double[] points);

        [DllImport("OPENGL32.DLL", EntryPoint = "glMap1f")]
        public static extern void Map1f(
          int target,
          float u1,
          float u2,
          int stride,
          int order,
          float[] points);

        [DllImport("OPENGL32.DLL", EntryPoint = "glMap2d")]
        public static extern void Map2d(
          int target,
          double u1,
          double u2,
          int ustride,
          int uorder,
          double v1,
          double v2,
          int vstride,
          int vorder,
          double[] points);

        [DllImport("OPENGL32.DLL", EntryPoint = "glMap2f")]
        public static extern void Map2f(
          int target,
          float u1,
          float u2,
          int ustride,
          int uorder,
          float v1,
          float v2,
          int vstride,
          int vorder,
          float[,,] points);

        [DllImport("OPENGL32.DLL", EntryPoint = "glMapGrid1d")]
        public static extern void MapGrid1d(int un, double u1, double u2);

        [DllImport("OPENGL32.DLL", EntryPoint = "glMapGrid1f")]
        public static extern void MapGrid1f(int un, float u1, float u2);

        [DllImport("OPENGL32.DLL", EntryPoint = "glMapGrid2d")]
        public static extern void MapGrid2d(
          int un,
          double u1,
          double u2,
          int vn,
          double v1,
          double v2);

        [DllImport("OPENGL32.DLL", EntryPoint = "glMapGrid2f")]
        public static extern void MapGrid2f(int un, float u1, float u2, int vn, float v1, float v2);

        [DllImport("OPENGL32.DLL", EntryPoint = "glMaterialf")]
        public static extern void Materialf(int face, int pname, float param);

        [DllImport("OPENGL32.DLL", EntryPoint = "glMaterialfv")]
        public static extern void Materialfv(int face, int pname, float[] fparams);

        [DllImport("OPENGL32.DLL", EntryPoint = "glMateriali")]
        public static extern void Materiali(int face, int pname, int param);

        [DllImport("OPENGL32.DLL", EntryPoint = "glMaterialiv")]
        public static extern void Materialiv(int face, int pname, int[] iparams);

        [DllImport("OPENGL32.DLL", EntryPoint = "glMatrixMode")]
        public static extern void MatrixMode(int mode);

        [DllImport("OPENGL32.DLL", EntryPoint = "glMultMatrixd")]
        public static extern void MultMatrixd(double[] m);

        [DllImport("OPENGL32.DLL", EntryPoint = "glMultMatrixf")]
        public static extern void MultMatrixf(float[] m);

        [DllImport("OPENGL32.DLL", EntryPoint = "glNewList")]
        public static extern void NewList(uint list, int mode);

        [DllImport("OPENGL32.DLL", EntryPoint = "glNormal3b")]
        public static extern void Normal3b(sbyte nx, sbyte ny, sbyte nz);

        [DllImport("OPENGL32.DLL", EntryPoint = "glNormal3bv")]
        public static extern void Normal3bv(sbyte[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glNormal3d")]
        public static extern void Normal3d(double nx, double ny, double nz);

        [DllImport("OPENGL32.DLL", EntryPoint = "glNormal3dv")]
        public static extern void Normal3dv(double[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glNormal3f")]
        public static extern void Normal3f(float nx, float ny, float nz);

        [DllImport("OPENGL32.DLL", EntryPoint = "glNormal3fv")]
        public static extern void Normal3fv(float[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glNormal3i")]
        public static extern void Normal3i(int nx, int ny, int nz);

        [DllImport("OPENGL32.DLL", EntryPoint = "glNormal3iv")]
        public static extern void Normal3iv(int[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glNormal3s")]
        public static extern void Normal3s(short nx, short ny, short nz);

        [DllImport("OPENGL32.DLL", EntryPoint = "glNormal3sv")]
        public static extern void Normal3sv(short[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glNormalPointer")]
        public static extern void NormalPointer(int type, int stride, IntPtr pointer);

        [DllImport("OPENGL32.DLL", EntryPoint = "glNormalPointer")]
        public static extern void NormalPointer(int type, int stride, int offset);

        [DllImport("OPENGL32.DLL", EntryPoint = "glOrtho")]
        public static extern void Ortho(
          double left,
          double right,
          double bottom,
          double top,
          double zNear,
          double zFar);

        [DllImport("OPENGL32.DLL", EntryPoint = "glPassThrough")]
        public static extern void PassThrough(float token);

        [DllImport("OPENGL32.DLL", EntryPoint = "glPixelMapfv")]
        public static extern void PixelMapfv(int map, int mapsize, float[] values);

        [DllImport("OPENGL32.DLL", EntryPoint = "glPixelMapuiv")]
        public static extern void PixelMapuiv(int map, int mapsize, uint[] values);

        [DllImport("OPENGL32.DLL", EntryPoint = "glPixelMapusv")]
        public static extern void PixelMapusv(int map, int mapsize, ushort[] values);

        [DllImport("OPENGL32.DLL", EntryPoint = "glPixelStoref")]
        public static extern void PixelStoref(int pname, float param);

        [DllImport("OPENGL32.DLL", EntryPoint = "glPixelStorei")]
        public static extern void PixelStorei(int pname, int param);

        [DllImport("OPENGL32.DLL", EntryPoint = "glPixelTransferf")]
        public static extern void PixelTransferf(int pname, float param);

        [DllImport("OPENGL32.DLL", EntryPoint = "glPixelTransferi")]
        public static extern void PixelTransferi(int pname, int param);

        [DllImport("OPENGL32.DLL", EntryPoint = "glPixelZoom")]
        public static extern void PixelZoom(float xfactor, float yfactor);

        [DllImport("OPENGL32.DLL", EntryPoint = "glPointSize")]
        public static extern void PointSize(float size);

        [DllImport("OPENGL32.DLL", EntryPoint = "glPolygonMode")]
        public static extern void PolygonMode(int face, int mode);

        [DllImport("OPENGL32.DLL", EntryPoint = "glPolygonOffset")]
        public static extern void PolygonOffset(float factor, float units);

        [DllImport("OPENGL32.DLL", EntryPoint = "glPolygonStipple")]
        public static extern void PolygonStipple(byte[] mask);

        [DllImport("OPENGL32.DLL", EntryPoint = "glPopAttrib")]
        public static extern void PopAttrib();

        [DllImport("OPENGL32.DLL", EntryPoint = "glPopClientAttrib")]
        public static extern void PopClientAttrib();

        [DllImport("OPENGL32.DLL", EntryPoint = "glPopMatrix")]
        public static extern void PopMatrix();

        [DllImport("OPENGL32.DLL", EntryPoint = "glPopName")]
        public static extern void PopName();

        [DllImport("OPENGL32.DLL", EntryPoint = "glPrioritizeTextures")]
        public static extern void PrioritizeTextures(int n, uint[] Textures, float[] priorities);

        [DllImport("OPENGL32.DLL", EntryPoint = "glPushAttrib")]
        public static extern void PushAttrib(int mask);

        [DllImport("OPENGL32.DLL", EntryPoint = "glPushClientAttrib")]
        public static extern void PushClientAttrib(int mask);

        [DllImport("OPENGL32.DLL", EntryPoint = "glPushMatrix")]
        public static extern void PushMatrix();

        [DllImport("OPENGL32.DLL", EntryPoint = "glPushName")]
        public static extern void PushName(uint name);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRasterPos2d")]
        public static extern void RasterPos2d(double x, double y);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRasterPos2dv")]
        public static extern void RasterPos2dv(double[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRasterPos2f")]
        public static extern void RasterPos2f(float x, float y);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRasterPos2fv")]
        public static extern void RasterPos2fv(float[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRasterPos2i")]
        public static extern void RasterPos2i(int x, int y);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRasterPos2iv")]
        public static extern void RasterPos2iv(int[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRasterPos2s")]
        public static extern void RasterPos2s(short x, short y);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRasterPos2sv")]
        public static extern void RasterPos2sv(short[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRasterPos3d")]
        public static extern void RasterPos3d(double x, double y, double z);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRasterPos3dv")]
        public static extern void RasterPos3dv(double[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRasterPos3f")]
        public static extern void RasterPos3f(float x, float y, float z);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRasterPos3fv")]
        public static extern void RasterPos3fv(float[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRasterPos3i")]
        public static extern void RasterPos3i(int x, int y, int z);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRasterPos3iv")]
        public static extern void RasterPos3iv(int[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRasterPos3s")]
        public static extern void RasterPos3s(short x, short y, short z);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRasterPos3sv")]
        public static extern void RasterPos3sv(short[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRasterPos4d")]
        public static extern void RasterPos4d(double x, double y, double z, double w);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRasterPos4dv")]
        public static extern void RasterPos4dv(double[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRasterPos4f")]
        public static extern void RasterPos4f(float x, float y, float z, float w);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRasterPos4fv")]
        public static extern void RasterPos4fv(float[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRasterPos4i")]
        public static extern void RasterPos4i(int x, int y, int z, int w);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRasterPos4iv")]
        public static extern void RasterPos4iv(int[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRasterPos4s")]
        public static extern void RasterPos4s(short x, short y, short z, short w);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRasterPos4sv")]
        public static extern void RasterPos4sv(short[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glReadBuffer")]
        public static extern void ReadBuffer(int mode);

        [DllImport("OPENGL32.DLL", EntryPoint = "glReadPixels")]
        public static extern void ReadPixels(
          int x,
          int y,
          int width,
          int height,
          int format,
          int type,
          [In, Out] IntPtr pixels);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRectd")]
        public static extern void Rectd(double x1, double y1, double x2, double y2);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRectdv")]
        public static extern void Rectdv(double[] v1, double[] v2);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRectf")]
        public static extern void Rectf(float x1, float y1, float x2, float y2);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRectfv")]
        public static extern void Rectfv(float[] v1, float[] v2);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRecti")]
        public static extern void Recti(int x1, int y1, int x2, int y2);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRectiv")]
        public static extern void Rectiv(int[] v1, int[] v2);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRects")]
        public static extern void Rects(short x1, short y1, short x2, short y2);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRectsv")]
        public static extern void Rectsv(short[] v1, short[] v2);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRenderMode")]
        public static extern int RenderMode(int mode);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRotated")]
        public static extern void Rotated(double angle, double x, double y, double z);

        [DllImport("OPENGL32.DLL", EntryPoint = "glRotatef")]
        public static extern void Rotatef(float angle, float x, float y, float z);

        [DllImport("OPENGL32.DLL", EntryPoint = "glScaled")]
        public static extern void Scaled(double x, double y, double z);

        [DllImport("OPENGL32.DLL", EntryPoint = "glScalef")]
        public static extern void Scalef(float x, float y, float z);

        [DllImport("OPENGL32.DLL", EntryPoint = "glScissor")]
        public static extern void Scissor(int x, int y, int width, int height);

        [DllImport("OPENGL32.DLL", EntryPoint = "glSelectBuffer")]
        public static extern void SelectBuffer(int size, int[] buffer);

        [DllImport("OPENGL32.DLL", EntryPoint = "glSelectBuffer")]
        public static extern void SelectBuffer(int size, IntPtr buffer);

        [DllImport("OPENGL32.DLL", EntryPoint = "glShadeModel")]
        public static extern void ShadeModel(int mode);

        [DllImport("OPENGL32.DLL", EntryPoint = "glStencilFunc")]
        public static extern void StencilFunc(int func, int refvalue, uint mask);

        [DllImport("OPENGL32.DLL", EntryPoint = "glStencilMask")]
        public static extern void StencilMask(uint mask);

        [DllImport("OPENGL32.DLL", EntryPoint = "glStencilOp")]
        public static extern void StencilOp(int fail, int zfail, int zpass);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoord1d")]
        public static extern void TexCoord1d(double s);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoord1dv")]
        public static extern void TexCoord1dv(double[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoord1f")]
        public static extern void TexCoord1f(float s);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoord1fv")]
        public static extern void TexCoord1fv(float[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoord1i")]
        public static extern void TexCoord1i(int s);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoord1iv")]
        public static extern void TexCoord1iv(int[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoord1s")]
        public static extern void TexCoord1s(short s);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoord1sv")]
        public static extern void TexCoord1sv(short[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoord2d")]
        public static extern void TexCoord2d(double s, double t);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoord2dv")]
        public static extern void TexCoord2dv(double[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoord2f")]
        public static extern void TexCoord2f(float s, float t);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoord2fv")]
        public static extern void TexCoord2fv(float[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoord2i")]
        public static extern void TexCoord2i(int s, int t);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoord2iv")]
        public static extern void TexCoord2iv(int[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoord2s")]
        public static extern void TexCoord2s(short s, short t);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoord2sv")]
        public static extern void TexCoord2sv(short[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoord3d")]
        public static extern void TexCoord3d(double s, double t, double r);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoord3dv")]
        public static extern void TexCoord3dv(double[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoord3f")]
        public static extern void TexCoord3f(float s, float t, float r);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoord3fv")]
        public static extern void TexCoord3fv(float[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoord3i")]
        public static extern void TexCoord3i(int s, int t, int r);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoord3iv")]
        public static extern void TexCoord3iv(int[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoord3s")]
        public static extern void TexCoord3s(short s, short t, short r);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoord3sv")]
        public static extern void TexCoord3sv(short[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoord4d")]
        public static extern void TexCoord4d(double s, double t, double r, double q);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoord4dv")]
        public static extern void TexCoord4dv(double[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoord4f")]
        public static extern void TexCoord4f(float s, float t, float r, float q);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoord4fv")]
        public static extern void TexCoord4fv(float[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoord4i")]
        public static extern void TexCoord4i(int s, int t, int r, int q);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoord4iv")]
        public static extern void TexCoord4iv(int[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoord4s")]
        public static extern void TexCoord4s(short s, short t, short r, short q);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoord4sv")]
        public static extern void TexCoord4sv(short[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoordPointer")]
        public static extern void TexCoordPointer(int size, int type, int stride, IntPtr pointer);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoordPointer")]
        public static extern void TexCoordPointer(int size, int type, int stride, int offset);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexCoordPointer")]
        public static extern void TexCoordPointer(int size, int type, int stride, float[] pointer);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexEnvf")]
        public static extern void TexEnvf(int target, int pname, float param);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexEnvfv")]
        public static extern void TexEnvfv(int target, int pname, float[] fparams);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexEnvi")]
        public static extern void TexEnvi(int target, int pname, int param);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexEnviv")]
        public static extern void TexEnviv(int target, int pname, int[] iparams);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexGend")]
        public static extern void TexGend(int coord, int pname, double param);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexGendv")]
        public static extern void TexGendv(int coord, int pname, double[] dparams);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexGenf")]
        public static extern void TexGenf(int coord, int pname, float param);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexGenfv")]
        public static extern void TexGenfv(int coord, int pname, float[] fparams);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexGeni")]
        public static extern void TexGeni(int coord, int pname, int param);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexGeniv")]
        public static extern void TexGeniv(int coord, int pname, int[] iparams);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexImage1D")]
        public static extern void TexImage1D(
          int target,
          int level,
          int internalformat,
          int width,
          int border,
          int format,
          int type,
          IntPtr pixels);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexImage1D")]
        public static extern void TexImage1D(
          int target,
          int level,
          int internalformat,
          int width,
          int border,
          int format,
          int type,
          byte[] pixels);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexImage2D")]
        public static extern void TexImage2D(
          int target,
          int level,
          int internalformat,
          int width,
          int height,
          int border,
          int format,
          int type,
          IntPtr pixels);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexImage2D")]
        public static extern void TexImage2D(
          int target,
          int level,
          int internalformat,
          int width,
          int height,
          int border,
          int format,
          int type,
          byte[] pixels);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexParameterf")]
        public static extern void TexParameterf(int target, int pname, float param);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexParameterfv")]
        public static extern void TexParameterfv(int target, int pname, float[] fparams);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexParameteri")]
        public static extern void TexParameteri(int target, int pname, int param);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexParameteriv")]
        public static extern void TexParameteriv(int target, int pname, int[] iparams);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexSubImage1D")]
        public static extern void TexSubImage1D(
          int target,
          int level,
          int xoffset,
          int width,
          int format,
          int type,
          byte[] pixels);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexSubImage2D")]
        public static extern void TexSubImage2D(
          int target,
          int level,
          int xoffset,
          int yoffset,
          int width,
          int height,
          int format,
          int type,
          IntPtr pixels);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTexSubImage2D")]
        public static extern void TexSubImage2D(
          int target,
          int level,
          int xoffset,
          int yoffset,
          int width,
          int height,
          int format,
          int type,
          byte[] pixels);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTranslated")]
        public static extern void Translated(double x, double y, double z);

        [DllImport("OPENGL32.DLL", EntryPoint = "glTranslatef")]
        public static extern void Translatef(float x, float y, float z);

        [DllImport("OPENGL32.DLL", EntryPoint = "glVertex2d")]
        public static extern void Vertex2d(double x, double y);

        [DllImport("OPENGL32.DLL", EntryPoint = "glVertex2dv")]
        public static extern void Vertex2dv(double[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glVertex2f")]
        public static extern void Vertex2f(float x, float y);

        [DllImport("OPENGL32.DLL", EntryPoint = "glVertex2fv")]
        public static extern void Vertex2fv(float[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glVertex2i")]
        public static extern void Vertex2i(int x, int y);

        [DllImport("OPENGL32.DLL", EntryPoint = "glVertex2iv")]
        public static extern void Vertex2iv(int[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glVertex2s")]
        public static extern void Vertex2s(short x, short y);

        [DllImport("OPENGL32.DLL", EntryPoint = "glVertex2sv")]
        public static extern void Vertex2sv(short[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glVertex3d")]
        public static extern void Vertex3d(double x, double y, double z);

        [DllImport("OPENGL32.DLL", EntryPoint = "glVertex3dv")]
        public static extern void Vertex3dv(double[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glVertex3f")]
        public static extern void Vertex3f(float x, float y, float z);

        [DllImport("OPENGL32.DLL", EntryPoint = "glVertex3fv")]
        public static extern void Vertex3fv(float[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glVertex3i")]
        public static extern void Vertex3i(int x, int y, int z);

        [DllImport("OPENGL32.DLL", EntryPoint = "glVertex3iv")]
        public static extern void Vertex3iv(int[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glVertex3s")]
        public static extern void Vertex3s(short x, short y, short z);

        [DllImport("OPENGL32.DLL", EntryPoint = "glVertex3sv")]
        public static extern void Vertex3sv(short[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glVertex4d")]
        public static extern void Vertex4d(double x, double y, double z, double w);

        [DllImport("OPENGL32.DLL", EntryPoint = "glVertex4dv")]
        public static extern void Vertex4dv(double[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glVertex4f")]
        public static extern void Vertex4f(float x, float y, float z, float w);

        [DllImport("OPENGL32.DLL", EntryPoint = "glVertex4fv")]
        public static extern void Vertex4fv(float[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glVertex4i")]
        public static extern void Vertex4i(int x, int y, int z, int w);

        [DllImport("OPENGL32.DLL", EntryPoint = "glVertex4iv")]
        public static extern void Vertex4iv(int[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glVertex4s")]
        public static extern void Vertex4s(short x, short y, short z, short w);

        [DllImport("OPENGL32.DLL", EntryPoint = "glVertex4sv")]
        public static extern void Vertex4sv(short[] v);

        [DllImport("OPENGL32.DLL", EntryPoint = "glVertexPointer")]
        public static extern void VertexPointer(int size, int type, int stride, IntPtr pointer);

        [DllImport("OPENGL32.DLL", EntryPoint = "glVertexPointer")]
        public static extern void VertexPointer(int size, int type, int stride, double[,] pointer);

        [DllImport("OPENGL32.DLL", EntryPoint = "glVertexPointer")]
        public static extern void VertexPointer(int size, int type, int stride, float[] pointer);

        [DllImport("OPENGL32.DLL", EntryPoint = "glVertexPointer")]
        public static extern void VertexPointer(int size, int type, int stride, int offset);

        [DllImport("OPENGL32.DLL", EntryPoint = "glViewport")]
        public static extern void Viewport(int x, int y, int width, int height);

    }
}
