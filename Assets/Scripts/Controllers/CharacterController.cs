using UnityEngine;
using UnityEngine.AI;

public class CharacterController
{
    public Character character;

    public CharacterController(Character character)
    {
        this.character = character;
    }

    public void GiveTask(Task task)
    {
        character.taskList.Add(task);
    }
}
