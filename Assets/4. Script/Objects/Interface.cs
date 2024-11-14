using System.Numerics;

// 인터페이스는 따로 정리하면 좋다고 하더군요
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