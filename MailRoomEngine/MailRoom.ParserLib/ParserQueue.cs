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
        public class ClaimCMS1500Processor : IProcessor
    {
        public bool? IsExecutionCompleted = false;
        StagingClaimCms1500 row;
        EngineConfiguration engConfig;
        public ClaimCMS1500Processor(StagingClaimCms1500 stagingClaimCms1500, EngineConfiguration engineConfig)
        {
            row = stagingClaimCms1500;
            engConfig = engineConfig;
        }
        public bool? IsCompleted
        {
            get
            {
                return IsExecutionCompleted;
            }

        }

        public Row Row
        {
            get
            {
                return (Row)row;
            }

        }
        public void Execute()
        {
            try
            { 
            //TODO: write string extensions.. 
            //StringBuilder errors = new StringBuilder();
            //Business Rules 
            
                // IF engine threshold is 90 
                if (row.ConfidenceLevel < engConfig.ConfidenceLevelThreshold)
                {
                    this.row.Errors.Add(new Error { Field = "ConfidenceLevel", Message = "Confidence Level is lower than threshold " + engConfig.ConfidenceLevelThreshold });
                }

            // 1	 PAYER TYPE		Required	8	Var Char 	Only one word. GHP indicates group health plan, FBL indicates FECA BLKLUNG 
            if (string.IsNullOrWhiteSpace(row._1PayerType))
            {
                   this.Row.Errors.Add(new Error { Field = "1_PayerType", Message = "PayerType is required " });
                       //errors.Append("PayerType is required, ");
                   }
            else if (row._1PayerType.Length > 8 )
            {

                    this.Row.Errors.Add(new Error { Field = "1_PayerType", Message = "PayerType should not exceed 8 chars" });
                    //errors.Append("PayerType should not exceed 8 chars, ");
                }

            // 1a	Insured I.D number		Required	29	Var Char 	No rules are applicable 
            if (string.IsNullOrWhiteSpace(row._1aPatientInsuredId))
            {
                    this.Row.Errors.Add(new Error { Field = "_1aPatientInsuredId", Message = "_1aPatientInsuredId is required " });
                    // errors.Append("InsuredId is required, ");
                }
            else if (row._1PayerType.Length > 29)
            {
                    this.Row.Errors.Add(new Error { Field = "_1aPatientInsuredId", Message = "InsuredId should not exceed 29 chars" });
                    //errors.Append("InsuredId should not exceed 29 chars, ");
                }

            
                // At the end 
                row.ParserErrorCsv = String.Join(",", this.Row.Errors.Select(x => x.ToString()).ToArray());
          
            // execution state reached end...
            IsExecutionCompleted = true;
            }
            catch(Exception e)
            {
                IsExecutionCompleted = null;
                throw new Exception("Error in Executing, look inner exception for details", e);
            }
        }

        //public override Row Row { get; set; }
    }

    public class EngineConfiguration
    {
        public int ConfidenceLevelThreshold { get; set; }
    }

    public interface IProcessor<T>
    {
    }

    public class Error  
    {
        public string Field { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return Field + ":" + Message;
        }
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
