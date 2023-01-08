using UnityEditor;

[CustomEditor(typeof(Interactable), true)]
public class InteractableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Interactable interactable = (Interactable)target;
        InteractionEvent component = interactable.GetComponent<InteractionEvent>();

        if (target.GetType() == typeof(EventOnlyInteractable))
        {
            // Make Inspector GUI b/c we don't call `base.OnInspectorGUI();`
            interactable.promptMessage = EditorGUILayout.TextField("Prompt Message", interactable.promptMessage);
            EditorGUILayout.HelpBox("EventOnlyInteractable can ONLY use UnityEvents.", MessageType.Info);

            if (component == null)
            {
                interactable.useEvents = true;
                interactable.gameObject.AddComponent<InteractionEvent>();
            }
        }
        else
        {
            base.OnInspectorGUI();

            if (interactable.useEvents)
            {
                if (component == null)
                    interactable.gameObject.AddComponent<InteractionEvent>();
            }
            else
            {
                if (component != null)
                    DestroyImmediate(component);
            }
        }
    }
}
