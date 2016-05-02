using System;

namespace Science.Core.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class CommandDependencyAttribute : Attribute
    {
        public CommandDependencyAttribute(string commandPropertyName)
        {
            CommandPropertyName = commandPropertyName;
        }

        public string CommandPropertyName { get; private set; }
    }
}