using MailRoom.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MailRoom.ParserLib
{
   

    public class Cache : IEnumerable<Row>
    {

        private readonly HashSet<Row> _cache;
        private readonly object _mutex = new object();

        public Cache()
        {
            _cache = new HashSet<Row>();
        }   

        IEnumerator<Row> IEnumerable<Row>.GetEnumerator()
        {
            // throw new NotImplementedException();
            return _cache.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            // throw new NotImplementedException();
            return _cache.GetEnumerator();
        }

        // adding a row to cache... 
        public void Add(Row row)
        {
            lock(_mutex)
            {
                _cache.Add(row);
            }
        }

        /// <summary>
        /// Check if a given row exists in cache.
        /// </summary>
        /// <param name="row">The row to check.</param>
        public bool Exists(Row row)
        {
            var exists = _cache.Contains(row);
            return exists;
        }
    }
}
