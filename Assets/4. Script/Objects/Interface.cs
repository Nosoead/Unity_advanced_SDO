using System.Numerics;

// �������̽��� ���� �����ϸ� ���ٰ� �ϴ�����
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