using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShenmueHDTools.Main
{
    public class FinishedArgs : EventArgs
    {
        public bool Successful { get; set; }

        public FinishedArgs(bool successful)
        {
            Successful = successful;
        }
    }

    public class ProgressChangedArgs : EventArgs
    {
        public int Progress
        {
            get
            {
                return (int)((float)Stage / (float)MaxStage * 100.0f);
            }
        }
        public int Stage { get; set; }
        public int MaxStage { get; set; }

        public ProgressChangedArgs(int stage, int maxStage)
        {
            Stage = stage;
            MaxStage = maxStage;
        }
    }

    public class DescriptionChangedArgs : EventArgs
    {
        public string Description { get; set; }

        public DescriptionChangedArgs(string description)
        {
            Description = description;
        }
    }

    public class ErrorArgs : EventArgs
    {
        public string Error { get; set; }

        public ErrorArgs(string error)
        {
            Error = error;
        }
    }

    public delegate void FinishedEventHandler(object sender, FinishedArgs e);
    public delegate void ProgressChangedEventHandler(object sender, ProgressChangedArgs e);
    public delegate void DescriptionChangedEventHandler(object sender, DescriptionChangedArgs e);
    public delegate void ErrorEventHandler(object sender, ErrorArgs e);

    public interface IProgressable
    {
        event FinishedEventHandler Finished;
        event ProgressChangedEventHandler ProgressChanged;
        event DescriptionChangedEventHandler DescriptionChanged;
        event ErrorEventHandler Error;

        void Abort();
    }
}
