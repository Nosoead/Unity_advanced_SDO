public interface IInteractable
{
    void Interact();
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