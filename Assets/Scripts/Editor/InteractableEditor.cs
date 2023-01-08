using UnityEditor;

[CustomEditor(typeof(Interactable), true)]
public class InteractableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Interactable interactable = (Interactable)target;
        base.OnInspectorGUI();

        InteractionEvent component = interactable.GetComponent<InteractionEvent>();
        if (interactable.useEvents && component == null)
        {
            interactable.gameObject.AddComponent<InteractionEvent>();
        }
        else if (!interactable.useEvents && component != null)
        {
            DestroyImmediate(component);
        }
    }
}
