﻿using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.filtering
{
    public class DefaultCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
    {
        Func<ItemToFilter, PropertyType> accessor;

        public DefaultCriteriaFactory(Func<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value)
        {
            return new AnonymousCriteria<ItemToFilter>(item => accessor(item).Equals(value));
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] values)
        {
            return new AnonymousCriteria<ItemToFilter>(item => { return new List<PropertyType>(values).Contains(accessor(item)); });
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType value)
        {
            return new NotCriteria<ItemToFilter>(equal_to(value));
        }
    }
}