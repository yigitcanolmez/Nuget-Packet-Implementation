namespace SOD.Core
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class HasPermissionAttribute : Attribute
    {
        public HasPermissionAttribute()
        {

        }
    }
}