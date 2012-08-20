using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace EcoSysTAASConfigurator
{
    public static class BackgroundWorkerExtensions
    {
        public delegate void DoWorkDelegate(DoWorkEventArgs dwe);
        public delegate void ProgressChangedDelegate(ProgressChangedEventArgs pce);
        public delegate void RunWorkerCompletedDelegate(RunWorkerCompletedEventArgs rwce);

        public static BackgroundWorker WithHandlers(this BackgroundWorker bw, DoWorkDelegate doWorkDelegate, RunWorkerCompletedDelegate runWorkerCompletedDelegate)
        {
            bw.DoWork += new DoWorkEventHandler((sender, dwe) => { doWorkDelegate(dwe); });
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler((sender, rwce) => { runWorkerCompletedDelegate(rwce); });
            return bw;
        }

        public static BackgroundWorker WithHandlers(this BackgroundWorker bw, DoWorkDelegate doWorkDelegate, ProgressChangedDelegate progressChangedDelegate, RunWorkerCompletedDelegate runWorkerCompletedDelegate)
        {
            bw.DoWork += new DoWorkEventHandler((sender, dwe) => { doWorkDelegate(dwe); });
            bw.ProgressChanged += new ProgressChangedEventHandler((sender, pce) => { progressChangedDelegate(pce); });
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler((sender, rwce) => { runWorkerCompletedDelegate(rwce); });
            return bw;
        }

        public static BackgroundWorker Run(this BackgroundWorker bw)
        {
            bw.RunWorkerAsync();
            return bw;
        }
    }
}
