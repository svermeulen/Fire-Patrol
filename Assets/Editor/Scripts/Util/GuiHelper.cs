using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace FirePatrol
{
    public static class GuiHelper
    {
        static Texture2D MakeTex(int width, int height, Color col) {
            Color[] pix = new Color[width * height];
            for (int i = 0; i < pix.Length; i++) {
                pix[i] = col;
            }

            Texture2D result = new Texture2D(width, height);
            result.SetPixels(pix);
            result.Apply();

            return result;
        }

        static GUIStyle _boxStyle;

        static GuiHelper()
        {
            _boxStyle = new GUIStyle(GUI.skin.box);
            _boxStyle.padding = new RectOffset(10, 10, 10, 10);
            _boxStyle.margin = new RectOffset(5, 5, 5, 5);
            _boxStyle.normal.background = MakeTex(2, 2, new Color(0.5f, 0.5f, 0.5f, 1f));
        }

        public static IDisposable AreaBlock(Rect rect)
        {
            return new AreaBlockImpl(rect);
        }

        public static IDisposable HorizontalBlock(params GUILayoutOption[] options)
        {
            return new HorizontalBlockImpl(options);
        }

        public static IDisposable VerticalBlock()
        {
            return new VerticalBlockImpl();
        }

        public static IDisposable VerticalBox(string title)
        {
            return new VerticalBoxImpl(title);
        }

        private class VerticalBoxImpl : IDisposable
        {
            public VerticalBoxImpl(string title)
            {
                GUILayout.Label(title, EditorStyles.boldLabel);
                GUILayout.BeginVertical(GuiHelper._boxStyle);
            }

            public void Dispose()
            {
                GUILayout.EndVertical();
            }
        }

        private class VerticalBlockImpl : IDisposable
        {
            public VerticalBlockImpl()
            {
                GUILayout.BeginVertical();
            }

            public void Dispose()
            {
                GUILayout.EndVertical();
            }
        }

        private class HorizontalBlockImpl : IDisposable
        {
            public HorizontalBlockImpl(GUILayoutOption[] options)
            {
                GUILayout.BeginHorizontal(options);
            }

            public void Dispose()
            {
                GUILayout.EndHorizontal();
            }
        }

        private class AreaBlockImpl : IDisposable
        {
            public AreaBlockImpl(Rect rect)
            {
                GUILayout.BeginArea(rect);
            }

            public void Dispose()
            {
                GUILayout.EndArea();
            }
        }
    }
}
