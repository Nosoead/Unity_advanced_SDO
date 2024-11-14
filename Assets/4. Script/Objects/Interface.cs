using System.Numerics;

public interface IInteractable
{
    void Interact(BigInteger value);
}

public interface ISkillUsable
{
    void UseSkill();
}

public interface ISkillToggleable
{
    void Activate();
    void Deactivate();
}