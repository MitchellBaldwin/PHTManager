using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHTManager
{
    public class PHTMDataPoint
    {
        private double dataTime;
        public double DataTime
        {
            get { return dataTime; }
            set { dataTime = value; }
        }

        private Int32 dataTimeMS;
        public Int32 DataTimeMS
        {
            get { return dataTimeMS; }
            set { dataTimeMS = value; }
        }
        
        private int pPG1;
        public int PPG1
        {
            get { return pPG1; }
            set { pPG1 = value; }
        }

        private int pPG2;
        public int PPG2
        {
            get { return pPG2; }
            set { pPG2 = value; }
        }

        private ushort cPRaw = StaticPHTMDataPoint.CPZero;  // Cuff pressure in ADC counts
        public ushort CPRaw { get => cPRaw; set => cPRaw = value; }

        private double cP;                                     // Cuff pressure in mmHg
        public double CP
        {
            get
            {
                cP = (double)((CPRaw - StaticPHTMDataPoint.CPZero) * (StaticPHTMDataPoint.CPGain / 100.0));
                return cP;
            }
            //set
            //{
            //    cP = value;
            //}
        }

        int cuffPID = 127;
        public int CuffPID
        {
            get { return cuffPID; }
            set { cuffPID = value; }
        }

        int bPM = 60;
        public int BPM
        {
            get { return bPM; }
            set { bPM = value; }
        }

        int iBI = 600;
        public int IBI
        {
            get { return iBI; }
            set { iBI = value; }
        }

        // Default constructor
        public PHTMDataPoint()
        {
            dataTime = 0.0;
            dataTimeMS = 0;
            pPG1 = 0;
            pPG2 = 0;
            cPRaw = StaticPHTMDataPoint.CPZero;
        }

        public PHTMDataPoint(double time, int ppg1, int cp)
        {
            dataTime = time;
            dataTimeMS = 0;
            pPG1 = ppg1;
            pPG2 = 0;
            cPRaw = (ushort)((int)(cp * 100.0 / StaticPHTMDataPoint.CPGain) + StaticPHTMDataPoint.CPZero);
        }

        public PHTMDataPoint(double time, Int32 timeMS, int ppg1, int ppg2, int cp)
        {
            dataTime = time;
            dataTimeMS = timeMS;
            pPG1 = ppg1;
            pPG2 = ppg2;
            cPRaw = (ushort)((int)(cp * 100.0 / StaticPHTMDataPoint.CPGain) + StaticPHTMDataPoint.CPZero);
        }
    }

    public class PHTMDataPoints : List<PHTMDataPoint>
    {
        public PHTMDataPoint dataPoint { get; set; }
    }
}
