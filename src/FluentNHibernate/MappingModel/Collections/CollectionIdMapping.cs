using FluentNHibernate.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using FluentNHibernate.Utils;
using FluentNHibernate.MappingModel.Identity;

namespace FluentNHibernate.MappingModel.Collections
{
    public class CollectionIdMapping : MappingBase
    {

        private readonly AttributeStore attributes;


        public CollectionIdMapping(AttributeStore attributes)
        {
            this.attributes = attributes;
        }


        public string ColumnName
        {
            get { return attributes.GetOrDefault<string>("ColumnName"); }
        }

        public TypeReference Type
        {
            get { return attributes.GetOrDefault<TypeReference>("Type"); }
        }

        public override void AcceptVisitor(IMappingModelVisitor visitor)
        {
            visitor.ProcessCollectionId(this);
            
            if (Generator != null)
                visitor.Visit(Generator);
        }

        public override bool IsSpecified(string attribute)
        {
            return attributes.IsSpecified(attribute);
        }

        protected override void Set(string attribute, int layer, object value)
        {
            attributes.Set(attribute, layer, value);
        }

        public void Set<T>(Expression<Func<CollectionIdMapping, T>> expression, int layer, T value)
        {
            Set(expression.ToMember().Name, layer, value);
        }

        public GeneratorMapping Generator
        {
            get { return attributes.GetOrDefault<GeneratorMapping>("Generator"); }
        }

    }
}
