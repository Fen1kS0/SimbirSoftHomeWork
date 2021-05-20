﻿using System;
using System.Collections.Generic;
using Library.Core.Entities;

namespace Library.Core.General
{
    public class AuthorNameComparer : IComparer<Author>
    {
        public int Compare(Author x, Author y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (ReferenceEquals(null, y)) return 1;
            if (ReferenceEquals(null, x)) return -1;
            
            var firstNameComparison = string.Compare(x.FirstName, y.FirstName, StringComparison.Ordinal);
            if (firstNameComparison != 0) 
                return firstNameComparison;
            
            var lastNameComparison = string.Compare(x.LastName, y.LastName, StringComparison.Ordinal);
            if (lastNameComparison != 0) 
                return lastNameComparison;
            
            return string.Compare(x.MiddleName, y.MiddleName, StringComparison.Ordinal);
        }
    }
}