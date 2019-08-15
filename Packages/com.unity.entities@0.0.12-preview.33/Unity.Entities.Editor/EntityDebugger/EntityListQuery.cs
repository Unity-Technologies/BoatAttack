
namespace Unity.Entities.Editor
{
    
    internal class EntityListQuery
    {

        public EntityQuery Group { get; }

        public EntityQueryDesc QueryDesc { get; }

        public EntityListQuery(EntityQuery group)
        {
            this.Group = group;
        }

        public EntityListQuery(EntityQueryDesc queryDesc)
        {
            this.QueryDesc = queryDesc;
        }
    }

}

