using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PlanetCrafterMod
{
    public class CustomConsole : MonoBehaviour
    {
        private int myWindowID;

        private const string LogPrefix = "[PlanetCrafterMod]";
        private const int MaxLogLines = 100;

        private readonly Queue<string> logMessages = new Queue<string>();

        private bool showConsole = true;
        private Rect windowRect = new Rect(100, 100, 450, 300);
        private Vector2 scrollPosition;
        private string inputText = "";

        // Background color for the console
        private Color backgroundColor = new Color(0f, 0f, 0f, 0.8f); // Dark gray with alpha

        public void Start()
        {
            myWindowID = WindowManager.GetNextWindowID();

            //Debug.ClearDeveloperConsole();
            //Debug.developerConsoleEnabled = true;
            //Debug.developerConsoleVisible = true;

            Debug.unityLogger.logEnabled = true;
            Application.logMessageReceived += HandleLog;
            Application.logMessageReceivedThreaded += HandleLog;
        }

        public void OnDestroy()
        {
            Application.logMessageReceived -= HandleLog;
            Application.logMessageReceivedThreaded -= HandleLog;
            Debug.unityLogger.logEnabled = false;
        }

        private void HandleLog(string message, string stackTrace, LogType type)
        {
            string logEntry = FormatLogMessage(message, stackTrace, type);
            logMessages.Enqueue(logEntry);

            if (logMessages.Count > MaxLogLines)
            {
                logMessages.Dequeue();
            }
        }

        private string FormatLogMessage(string message, string stackTrace, LogType type)
        {
            string logTypeStr = "";
            switch (type)
            {
                case LogType.Error:
                case LogType.Exception:
                    logTypeStr = "[ERROR]";
                    break;
                case LogType.Warning:
                    logTypeStr = "[WARNING]";
                    break;
                case LogType.Log:
                default:
                    logTypeStr = "[INFO]";
                    break;
            }
            return $"{logTypeStr} {LogPrefix} {message}\n{stackTrace}";
        }

        public void OnGUI()
        {
            if (showConsole)
            {
                // Draw the console window with draggable and resizable behavior
                windowRect = GUI.Window(myWindowID, windowRect, DrawConsoleWindow, "Console");
            }

            if (GUI.Button(new Rect(10, 10, 100, 30), "Toggle Console"))
            {
                showConsole = !showConsole;
            }
        }

        private void DrawConsoleWindow(int windowID)
        {
            // Set background color
            GUI.backgroundColor = backgroundColor;

            // Allow dragging the window
            GUI.DragWindow(new Rect(0, 0, windowRect.width, 20));

            // Scrollable log area
            scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.ExpandHeight(true));
            GUILayout.Label(string.Join("\n", logMessages));
            GUILayout.EndScrollView();

            // Input field
            GUILayout.BeginHorizontal();
            {
                inputText = GUILayout.TextField(inputText);
                if (GUILayout.Button("Send", GUILayout.Width(50)))
                {
                    if (!string.IsNullOrEmpty(inputText))
                    {
                        Debug.Log(inputText);
                        inputText = "";
                    }
                }
            }
            GUILayout.EndHorizontal();
        }
    }
}
