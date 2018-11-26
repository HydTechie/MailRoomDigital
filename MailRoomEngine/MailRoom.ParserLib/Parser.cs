using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MailRoom.ParserLib
{
    //public class Parser
    //{
    //    // list of processed records 
    //    private readonly Cache _cache;

    //    private readonly ParserQueue _currentQueue;

    //    // entire process completed 
    //    //public event Action OnCompleted;

    //    //public event Action<Row> OnRowParsed;

    //    public Parser(Cache cache)
    //    {
    //        _cache = cache;

    //        _currentQueue = new ParserQueue(RowRetrieved);
    //    }

    //    private void RowRetrieved(Row row)
    //    {
    //        _cache.Add(row);

    //    }
    //    // start method kicks of processing the queue
    //    public void Start(Row[] rows)
    //    {
    //        foreach(Row row in rows)
    //        { 
    //            //TODO: decision to decide which parser this row should go with!
    //            if (row.Type == 1) // ClaimType1 or ClaimType2 
    //                _currentQueue.Enqueue(new Claims1Processor(row));
    //            if (row.Type == 2) // ClaimType1 or ClaimType2 
    //                _currentQueue.Enqueue(new Claims2Processor(row));
    //        }
    //        // read the queue and process
    //        _currentQueue.Process();

    //    }

    //}

    // Database Row Model?
    // Should it have a base so that, it can have many variations?
    [NotMapped]
    public class Row
    {
        [NotMapped]
        public virtual int Key { get; }


        // Verified / Validated or Error
        // 1-Verified, 2 - Validated, Error = -1
        [NotMapped]
        public int ExecStatus { get; set; }

        [NotMapped]
        public List<Error> Errors = new List<Error>();

    }

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
