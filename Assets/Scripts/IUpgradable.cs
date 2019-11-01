public interface IUpgradable
{
    int Level { get; set; }
    void Upgrade();
}