using UnityEditor;

[InitializeOnLoad]
public static class ForceIMGUIInspector
{
    static ForceIMGUIInspector()
    {
        Editor.finishedDefaultHeaderGUI += (editor) =>
        {
            if (editor != null)
                editor.DrawDefaultInspector();  // ép IMGUI inspector
        };
    }
}
