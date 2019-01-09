using System;
using System.Collections.Generic;
using System.Text;

namespace MailRoom.Model
{
    
    public interface IProcessor
    {
        Row Row { get; }
        void Execute();
        bool? IsCompleted { get; }

    }
    public class EngineConfiguration
    {
        public int ConfidenceLevelThreshold { get; set; }
        public int DataFetchFrequency { get; set; }
        public int NumberOfRecords { get; set; }
        // "DataFetchFrequency": "90", // minutes
        // "NumberOfRecords": "10"  

        public EngineConfiguration(int confidenceLevel, int FetchFreq=30, int noOfRec =100)
        {
            ConfidenceLevelThreshold = confidenceLevel;
            DataFetchFrequency = FetchFreq;
            NumberOfRecords = noOfRec;
        }
    }
}
