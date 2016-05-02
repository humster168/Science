using System;
using System.Reflection;

namespace Science.Core.CustomAttributes
{
    public class StartupClassAttribute : Attribute
    {
        protected string ShowName { get; set; }

        public StartupClassAttribute()
        {
            ShowName = MethodBase.GetCurrentMethod()?.DeclaringType?.Name;
            if(ShowName == null)
                throw new InvalidCastException("ShowName could not be void");
        }

        public StartupClassAttribute(string showName)
        {
            ShowName = showName;
        }
    }
}