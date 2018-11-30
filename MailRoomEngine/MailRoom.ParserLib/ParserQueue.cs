using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MailRoom.ParserLib
{
    public interface  IProcessor
    {
        Row Row { get; }
        void Execute();
        bool? IsCompleted { get;}
         
        
    }
   

   
    
    public class ParserQueue
    {
        private readonly IList<IProcessor> _executing = new List<IProcessor>();
        private readonly IList<IProcessor> _waiting = new List<IProcessor>();
        private readonly object _mutex = new object();

        public const int MaxConcurrency = 500;
        // Holder for on retrieval of the row
        public event Action<Row> OnRowParsed;
        // Raise after all rows parsed
        public event Action OnParsingCompleted;

        public ParserQueue()
        {
            
        }


        // enqueue of a row 
        public void Enqueue(IProcessor processor)
        {
            lock (_mutex)
            {
                // no matching queue item, so add it 
                if (_waiting.All(qitem => qitem.Row.Key != processor.Row.Key))
                {
                    _waiting.Add(processor);
                }
            }

        }

        // call after completed parsing a row
        private void RemoveFetcher(IProcessor processor)
        {
            lock (_mutex)
            {
                // remove from executing   
                _executing.Remove(processor);
                // should have already been removed??
              // TODO: _waiting.Remove(processor);
            }  
        }

        private bool StopProcessing()
        {
            // only when no waiting and executing 
            return !_waiting.Any() && !_executing.Any();
        }
        public void Process()
        {
            ThreadStart enqueuerThreadMethod = () =>
            {
                var rand = new Random();
                while (true)
                {
                    lock (_mutex)
                    {
                        // there is a waiting line and less than concurrency threshold
                        if (_waiting.Any() && _executing.Count() < MaxConcurrency)
                        {
                            var parser = _waiting[rand.Next(_waiting.Count)];
                            if (_executing.Any(item => item.Row.Key == parser.Row.Key))
                            {
                                // if its executing already, remove from waiting 
                                _waiting.Remove(parser);
                            }
                            else
                            {
                                // remove from waiting 
                                _waiting.Remove(parser);
                                // add to executing 
                                _executing.Add(parser);

                                // Call parser functionality 
                                parser.Execute();

                                
                            }

                        }
                    }
                }
            };

            ThreadStart parserCompletionCheckMethod = () =>
            {
                while (true)
                {
                    lock (_mutex)
                    {
                        // if completed of any 
                        if (_executing.Any(x => x.IsCompleted.HasValue && x.IsCompleted.Value == true))
                        {
                            var parser = _executing.First(x => x.IsCompleted.HasValue && x.IsCompleted.Value == true);
                            RemoveFetcher(parser);

                            if (parser.Row != null)
                            {
                                // This is handled by Completion Check method
                                if(OnRowParsed != null)
                                    OnRowParsed(parser.Row);

                                if (StopProcessing() && OnParsingCompleted != null)
                                {
                                    OnParsingCompleted();
                                    break;
                                }
                            }
                        }
                    }
                }
            };

            // Initiating the threads 
            new Thread(enqueuerThreadMethod).Start();
            new Thread(parserCompletionCheckMethod).Start();
        }

    }
}
