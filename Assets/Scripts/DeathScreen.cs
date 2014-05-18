using UnityEngine;
using System.Collections;

public class DeathScreen : MonoBehaviour {
    void OnGUI()
    {
        GUIStyle centeredStyle = GUI.skin.GetStyle("Label");
        centeredStyle.normal.textColor = Color.black;
        centeredStyle.alignment = TextAnchor.UpperCenter;
        GUILayout.BeginArea(new Rect(Screen.width / 2 - Screen.width * 0.4f / 2,
            Screen.height / 2, Screen.width * 0.4f, Screen.height));
        {
            GUILayout.BeginVertical(); // also can put width in here
            {
                GUILayout.Label("You suck, Restart?", centeredStyle);
                if (GUILayout.Button("Yes"))
                {
                    Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
                    player.respawn();
                    Destroy(gameObject);
                }
                if (GUILayout.Button("No"))
                {
                    Application.Quit();
                    // Also quit the editor
                    UnityEditor.EditorApplication.isPlaying = false;
                }

            }
            GUILayout.EndVertical();
        }
        GUILayout.EndArea();
    }
}
