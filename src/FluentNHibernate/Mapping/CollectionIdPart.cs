using FluentNHibernate.MappingModel;
using FluentNHibernate.MappingModel.Collections;
using FluentNHibernate.MappingModel.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentNHibernate.Mapping
{
    public class CollectionIdPart
    {
        private readonly AttributeStore attributes = new AttributeStore();
   
        public void Column(string columnName)
        {
            attributes.Set("ColumnName", Layer.UserSupplied, columnName);
        }

        private void SetDefaultGenerator(CollectionIdMapping mapping)
        {
            var generatorMapping = new GeneratorMapping();
            var defaultGenerator = new GeneratorBuilder(generatorMapping, mapping.Type.GetUnderlyingSystemType(), Layer.UserSupplied);

            if (mapping.Type == typeof(Guid))
                defaultGenerator.GuidComb();
            else if (mapping.Type == typeof(int) || mapping.Type == typeof(long))
                defaultGenerator.Identity();
            else
                defaultGenerator.Assigned();

            mapping.Set(x => x.Generator, Layer.Defaults, generatorMapping);
        }
        public void Type<T>()
        {
            attributes.Set("Type", Layer.UserSupplied, new TypeReference(typeof(T)));
        }

        internal CollectionIdMapping CreateMapping()
        {
            CollectionIdMapping mapping = new CollectionIdMapping(attributes);
            SetDefaultGenerator(mapping);
            return mapping;
        }
    }
}
