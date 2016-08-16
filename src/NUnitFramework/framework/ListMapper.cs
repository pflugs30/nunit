// ***********************************************************************
// Copyright (c) 2008 Charlie Poole
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ***********************************************************************

using System;
using System.Collections;
using System.Collections.Generic;

using NUnit.Compatibility;

namespace NUnit.Framework
{
    using System.Reflection;

    /// <summary>
    /// ListMapper is used to transform a collection used as an actual argument
    /// producing another collection to be used in the assertion.
    /// </summary>
    public class ListMapper
    {
        /// <summary>
        /// The original collection
        /// </summary>
        private readonly ICollection original;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListMapper"/> class. 
        /// Construct a ListMapper based on a collection
        /// </summary>
        /// <param name="original">
        /// The collection to be transformed
        /// </param>
        public ListMapper(ICollection original)
        {
            this.original = original;
        }

        /// <summary>
        /// Produces a collection containing all the _values of a property
        /// </summary>
        /// <param name="name">The collection of property _values</param>
        /// <returns>The collection</returns>
        public ICollection Property(string name)
        {
            var propList = new List<object>();
            foreach (var item in this.original)
            {
                var property = item.GetType().GetProperty(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                if (property == null)
                {
                    throw new ArgumentException(string.Format("{0} does not have a {1} property", item, name));
                }

                propList.Add(property.GetValue(item, null));
            }

            return propList;
        }
    }
}
