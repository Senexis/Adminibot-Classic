using System;

namespace th.AdminibotLegacy
{
    
    [AttributeUsage(AttributeTargets.All, Inherited = false)]
    public sealed class CommandUserLevel : Attribute
    {
        public readonly Types.CommandLevel Level;

        // This is a positional argument
        public CommandUserLevel(Types.CommandLevel level)
        {
            Level = level;
        }
    }

    [AttributeUsage(AttributeTargets.All, Inherited = false)]
    public sealed class CommandIsDefault : Attribute
    {
        public readonly bool IsDefault;

        // This is a positional argument
        public CommandIsDefault(bool isDefault)
        {
            IsDefault = isDefault;
        }
    }

    [AttributeUsage(AttributeTargets.All, Inherited = false)]
    public sealed class CommandDescription : Attribute
    {
        public readonly string Description;

        // This is a positional argument
        public CommandDescription(string description)
        {
            Description = description;
        }
    }

    [AttributeUsage(AttributeTargets.All, Inherited = false)]
    public sealed class CommandUsage : Attribute
    {
        public readonly string Usage;

        // This is a positional argument
        public CommandUsage(string usage)
        {
            Usage = usage;
        }
    }
}
