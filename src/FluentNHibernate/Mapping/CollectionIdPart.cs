using FluentNHibernate.MappingModel;
using FluentNHibernate.MappingModel.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentNHibernate.Mapping
{
    public class CollectionIdPart
    {
        private readonly CollectionIdMapping mapping = new CollectionIdMapping( new AttributeStore());

        public void Column(string columnName)
        {
            mapping.Set(x => x.ColumnName, Layer.UserSupplied, columnName);
        }

        internal CollectionIdMapping Mapping
        {
            get
            {
                return mapping;
            }
        }
    }
}
