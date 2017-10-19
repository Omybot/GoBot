using System;

namespace GoBot.Actions
{
    public interface ITimeableAction : IAction
    {
        TimeSpan Duration { get; }
    }
}
