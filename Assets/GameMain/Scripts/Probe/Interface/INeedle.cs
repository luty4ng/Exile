public interface INeedle
{
    INeedleMaster Master { get; set; }
    void OnUpdate();
}