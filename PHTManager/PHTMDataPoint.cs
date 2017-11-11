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

        public ushort CPZero = 29;
        public ushort CPRaw = 29;
        //public ushort CPZero = 0;
        public double CPGain = 22.7692;     // mmHg/count from measurement on 11 Nov 2017
        //public double CPGain = 20.3467;     // mmHg/count from MPVX7025DP with 2x scaling circuit
        //public double CPGain = 28.47;
        //public double CPGain = 26.85;
        //public double CPGain = 20.0;

        private int cP;
        public int CP
        {
            get
            {
                cP = (int)((CPRaw - CPZero) * (CPGain / 100.0));
                return cP;
            }
            set
            {
                cP = value;
            }
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

        private int targetCuffPressure = 90;
        public int TargetCuffPressure
        {
            get { return targetCuffPressure; }
            set
            {
                targetCuffPressure = value;
            }
        }

        public int TargetCuffPressureToRaw()
        {
            return (targetCuffPressure * 100) / (int)CPGain + CPZero;
        }

        // Default constructor
        public PHTMDataPoint()
        {
            dataTime = 0.0;
            dataTimeMS = 0;
            pPG1 = 0;
            pPG2 = 0;
            cP = 0;
        }

        public PHTMDataPoint(double time, int ppg1, int cp)
        {
            dataTime = time;
            dataTimeMS = 0;
            pPG1 = ppg1;
            pPG2 = 0;
            cP = cp;
        }

        public PHTMDataPoint(double time, Int32 timeMS, int ppg1, int ppg2, int cp)
        {
            dataTime = time;
            dataTimeMS = timeMS;
            pPG1 = ppg1;
            pPG2 = ppg2;
            cP = cp;
        }
    }

    public class PHTMDataPoints : List<PHTMDataPoint>
    {
        public PHTMDataPoint dataPoint { get; set; }
    }
}
